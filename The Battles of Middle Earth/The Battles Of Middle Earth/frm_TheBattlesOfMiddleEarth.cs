using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Battles_Of_Middle_Earth
{

    public partial class frm_TheBattlesOfMiddleEarth : Form
    {
        //-------------------------------Declaration of Global Variables-------------------------------\\

        Player playerOne;
        Player playerTwo;

        Random rnd = new Random();

        Unit firstUnitClicked = null;

        int unitTypeOfFirstUnitClicked = 0;

        string unitTypeOfFirstUnitClickedString = null;

        PictureBox firstPictureBoxClicked = null;

        decimal currentSupplyPlayer1 = 0;

        decimal currentSupplyPlayer2 = 0;

        static int supplyLimit = 36;

        int previousPositionOnBoard = 0;

        int player1CurrentScore = 0;
        int player2CurrentScore = 0;

        //Supply numbers
        int archerSupplyMultiplier = 2;
        int bruiserSupplyMultiplier = 4;
        int heroSupplyMultiplier = 20;
        int remainingArmySupply = 36;

        //number of units allocated to the board
        int player1ArmyAllocated = 0;
        int player2ArmyAllocated = 0;

        //health for units
        double swordsmanHealthP1 = 20;
        double swordsmanHealthP2 = 20;
        double archerHealthP1 = 10;
        double archerHealthP2 = 10;
        double bruiserHealthP1 = 25;
        double bruiserHealthP2 = 25;
        double heroHealthP1 = 30;
        double heroHealthP2 = 30;

        //Damage for units
        double swordsmanMinDamageP1 = 3;
        double swordsmanMaxDamageP1 = 7;

        double swordsmanMinDamageP2 = 3;
        double swordsmanMaxDamageP2 = 7;

        double archerMinDamageP1 = 7;
        double archerMaxDamageP1 = 11;

        double archerMinDamageP2 = 7;
        double archerMaxDamageP2 = 11;

        double bruiserMinDamageP1 = 13;
        double bruiserMaxDamageP1 = 17;

        double bruiserMinDamageP2 = 13;
        double bruiserMaxDamageP2 = 17;

        double heroMinDamageP1 = 14;
        double heroMaxDamageP1 = 18;

        double heroMinDamageP2 = 14;
        double heroMaxDamageP2 = 18;

        //icon for each unit ie position in image list
        int swordsmanIconP1 = 0;
        int archerIconP1 = 4;
        int bruiserIconP1 = 8;
        int heroIconP1 = 12;

        int swordsmanIconP2 = 16;
        int archerIconP2 = 20;
        int bruiserIconP2 = 24;
        int heroIconP2 = 28;

        //Range of units
        int baseRange = 1;
        int archerRange = 2;

        //Range variables
        int[] capableOfHitting = new int[25];
        int rangeArrayPosition = 0;

        //Player turn
        int turnOfPlayer = 1;

        Unit[] boardPositions = new Unit[109];
        Unit[] Player1Army = new Unit[supplyLimit];
        Unit[] Player2Army = new Unit[supplyLimit];

        bool Player1Ready = false;
        bool Player2Ready = false;
        bool firstUnitClickedBool = false;



        //-------------------------------End of Declaration of Global Variables-------------------------------\\

        public frm_TheBattlesOfMiddleEarth()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }

        }//End Default constructor


        //Overload the constructor
        public frm_TheBattlesOfMiddleEarth(Player newPlayer1, Player newPlayer2)
        {
            try
            {
                InitializeComponent();

                //Assign to global fo access
                playerOne = newPlayer1;
                playerTwo = newPlayer2;

            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }  

        }//End frm_ArmyBuildingScreen constructor



        private void frm_TheBattlesOfMiddleEarth_Load(object sender, EventArgs e)
        {
            //  Method Name:            frm_TheBattlesOfMiddleEarth_Load

            //  Method Purpose:         To Load in the player details from the user registration form

            //  Called by Method:       frm_TheBattlesOfMiddleEarth Program loading event

            //  Call to Method(s):      None

            //  Date Last Revised:      22/02/15

            //  Author:                 AC

            try
            {
                //Display Name
                lbl_Player1Name.Text = lbl_Player1Name.Text + playerOne.Username;

                //Display Avatar
                pbx_AvatarPlayer1.Image = imglst_UserAvatars.Images[playerOne.Avatar];

                //Display Current supply
                lbl_SupplyPlayer1.Text = lbl_SupplyPlayer1.Text + currentSupplyPlayer1.ToString() + "/" + supplyLimit.ToString();

                //Display Name
                lbl_Player2Name.Text = lbl_Player2Name.Text + playerTwo.Username;

                //Display Avatar
                pbx_AvatarPlayer2.Image = imglst_UserAvatars.Images[playerTwo.Avatar];

                //Display Current supply
                lbl_SupplyPlayer2.Text = lbl_SupplyPlayer2.Text + currentSupplyPlayer2.ToString() + "/" + supplyLimit.ToString();

                //Set unit stats
                swordsmanMinDamageP1 = swordsmanMinDamageP1 * playerOne.Handicap;
                swordsmanMaxDamageP1 = swordsmanMaxDamageP1 * playerOne.Handicap;
                swordsmanHealthP1 = swordsmanHealthP1 * playerOne.Handicap;

                swordsmanMinDamageP2 = swordsmanMinDamageP2 * playerTwo.Handicap;
                swordsmanMaxDamageP2 = swordsmanMaxDamageP2 * playerTwo.Handicap;
                swordsmanHealthP2 = swordsmanHealthP2 * playerTwo.Handicap;

                archerMinDamageP1 = archerMinDamageP1 * playerOne.Handicap;
                archerMaxDamageP1 = archerMaxDamageP1 * playerOne.Handicap;
                archerHealthP1 = archerHealthP1 * playerOne.Handicap;

                archerMinDamageP2 = archerMinDamageP2 * playerTwo.Handicap;
                archerMaxDamageP2 = archerMaxDamageP2 * playerTwo.Handicap;
                archerHealthP2 = archerHealthP2 * playerTwo.Handicap;

                bruiserMinDamageP1 = bruiserMinDamageP1 * playerOne.Handicap;
                bruiserMaxDamageP1 = bruiserMaxDamageP1 * playerOne.Handicap;
                bruiserHealthP1 = bruiserHealthP1 * playerOne.Handicap;

                bruiserMinDamageP2 = bruiserMinDamageP2 * playerTwo.Handicap;
                bruiserMaxDamageP2 = bruiserMaxDamageP2 * playerTwo.Handicap;
                bruiserHealthP2 = bruiserHealthP2 * playerTwo.Handicap;

                heroMinDamageP1 = heroMinDamageP1 * playerOne.Handicap;
                heroMaxDamageP1 = heroMaxDamageP1 * playerOne.Handicap;
                heroHealthP1 = heroHealthP1 * playerOne.Handicap;

                heroMinDamageP2 = heroMinDamageP2 * playerTwo.Handicap;
                heroMaxDamageP2 = heroMaxDamageP2 * playerTwo.Handicap;
                heroHealthP2 = heroHealthP2 * playerTwo.Handicap;

                //Set values for textbox
                lbl_SwordsmanStatsP1.Text = "A: " + swordsmanMinDamageP1.ToString("N1") + " - " + swordsmanMaxDamageP1.ToString("N1") + " H: " + swordsmanHealthP1.ToString("N1");
                lbl_SwordsmanStatsP2.Text = "A: " + swordsmanMinDamageP2.ToString("N1") + " - " + swordsmanMaxDamageP2.ToString("N1") + " H: " + swordsmanHealthP2.ToString("N1");
                lbl_ArcherStatsP1.Text = "A: " + archerMinDamageP1.ToString("N1") + " - " + archerMaxDamageP1.ToString("N1") + " H: " + archerHealthP1.ToString("N1");
                lbl_ArcherStatsP2.Text = "A: " + archerMinDamageP2.ToString("N1") + " - " + archerMaxDamageP2.ToString("N1") + " H: " + archerHealthP2.ToString("N1");
                lbl_BruiserStatsP1.Text = "A: " + bruiserMinDamageP1.ToString("N1") + " - " + bruiserMaxDamageP1.ToString("N1") + " H: " + bruiserHealthP1.ToString("N1");
                lbl_BruiserStatsP2.Text = "A: " + bruiserMinDamageP2.ToString("N1") + " - " + bruiserMaxDamageP2.ToString("N1") + " H: " + bruiserHealthP2.ToString("N1");
                lbl_HeroStatsP1.Text = "A: " + heroMinDamageP1.ToString("N1") + " - " + heroMaxDamageP1.ToString("N1") + " H: " + heroHealthP1.ToString("N1");
                lbl_HeroStatsP2.Text = "A: " + heroMinDamageP2.ToString("N1") + " - " + heroMaxDamageP2.ToString("N1") + " H: " + heroHealthP2.ToString("N1");

            }
            catch (Exception ex)
            {
                //Show error
                ShowErrorMessage(ex);
            }
            
        }//End frm_ArmyBuildingScreen_Load



        private void CreateBoard()
        {
            //  Method Name:            CreateBoard

            //  Method Purpose:         Create the board and assign all the units to the board array
            
            //  Called by Method:       btn_Player1Ready_Click or btn_Player2Ready_Click
            
            //  Call to Method(s):      None
            
            //  Date Last Revised:      22/02/15

            //  Author:                 AC

            //-------------------------------Declaration of Variables-------------------------------\\
            int maxBoxes = 108;
            int boxHeight = 60;

            //-------------------------------End of Declaration of Variables-------------------------------\\

            try
            {
                for (int currentBox = 1; currentBox <= maxBoxes; currentBox++)
                {
                    //Create a pbx
                    PictureBox pbxCreated = new PictureBox();

                    //Creates a sqaure pbx
                    pbxCreated.Width = boxHeight;
                    pbxCreated.Height = boxHeight;


                    //temp colour
                    //pbxCreated.BackColor = Color.Black;

                    //If the pbx is one which is on player 1's side of the battlefield
                    if (currentBox <= 36 && Player1Army[player1ArmyAllocated] != null)
                    {
                      
                        //Assign image and unit according to the unit type
                        switch (Player1Army[player1ArmyAllocated].IconForUnit)
                        {
                            case 0:

                                //Assign Image
                                pbxCreated.Image = imglst_UnitIcons.Images[0];

                                //Assign to Board
                                boardPositions[currentBox] = Player1Army[player1ArmyAllocated];

                                //Unit type and owner - 0, 0 = no unit in square
                                pbxCreated.Tag = "1,1";

                                break;

                            case 4:

                                pbxCreated.Image = imglst_UnitIcons.Images[4];

                                boardPositions[currentBox] = Player1Army[player1ArmyAllocated];

                                //Unit type and owner - 0, 0 = no unit in square
                                pbxCreated.Tag = "2,1";

                                break;

                            case 8:

                                pbxCreated.Image = imglst_UnitIcons.Images[8];

                                boardPositions[currentBox] = Player1Army[player1ArmyAllocated];

                                //Unit type and owner - 0, 0 = no unit in square
                                pbxCreated.Tag = "3,1";

                                break;

                            case 12:

                                pbxCreated.Image = imglst_UnitIcons.Images[12];

                                boardPositions[currentBox] = Player1Army[player1ArmyAllocated];

                                //Unit type and owner - 0, 0 = no unit in square
                                pbxCreated.Tag = "4,1";

                                break;

                            default:
                                //If image doesn't exist
                                //Make picturebox identifiable
                                pbxCreated.BackColor = Color.Red;

                                //Inform users
                                MessageBox.Show("An icon for one of your units has not loaded correctly", "Icon Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                break;

                        }//End Switch
                                               
                        //Increment array position
                        player1ArmyAllocated++;

                    } // Else If the pbx is one which is on player 2's side of the battlefield
                    else if (currentBox >= 73 && Player2Army[player2ArmyAllocated] != null)
                    {
                        
                        //Assign image and unit according to the unit type
                        switch (Player2Army[player2ArmyAllocated].IconForUnit)
                        {
                            case 16:

                                pbxCreated.Image = imglst_UnitIcons.Images[16];

                                boardPositions[currentBox] = Player2Army[player2ArmyAllocated];

                                //Unit type and owner - 0, 0 = no unit in square
                                pbxCreated.Tag = "1,2";

                                break;

                            case 20:

                                pbxCreated.Image = imglst_UnitIcons.Images[20];

                                boardPositions[currentBox] = Player2Army[player2ArmyAllocated];

                                //Unit type and owner - 0, 0 = no unit in square
                                pbxCreated.Tag = "2,2";

                                break;

                            case 24:

                                pbxCreated.Image = imglst_UnitIcons.Images[24];

                                boardPositions[currentBox] = Player2Army[player2ArmyAllocated];

                                //Unit type and owner - 0, 0 = no unit in square
                                pbxCreated.Tag = "3,2";

                                break;

                            case 28:

                                pbxCreated.Image = imglst_UnitIcons.Images[28];

                                boardPositions[currentBox] = Player2Army[player2ArmyAllocated];

                                //Unit type and owner - 0, 0 = no unit in square
                                pbxCreated.Tag = "4,2";

                                break;

                            default: 
                                //If image doesn't exist
                                //Make picturebox identifiable
                                pbxCreated.BackColor = Color.Red;

                                //Inform users
                                MessageBox.Show("An icon for one of your units has not loaded correctly", "Icon Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;

                        }//End Switch

                        //Increment array position
                        player2ArmyAllocated++;

                    }//End If

                    //If tag is not set then there is no unit there
                    if (pbxCreated.Tag == null)
                    {
                        //Set tag to unoccupied
                        pbxCreated.Tag = "0, 0";
                    }


                    //Unit placement in array
                    pbxCreated.Name = currentBox.ToString();

                    //Display on battlefield
                    flp_Battlefield.Controls.Add(pbxCreated);

                    //Add Mouse click handler
                    pbxCreated.MouseClick += pbxCreated_MouseClick;

                }//End For

            }
            catch (Exception ex)
            {
                //Show error
                ShowErrorMessage(ex);
            }



        }//End CreateBoard



        public void pbxCreated_MouseClick(object sender, MouseEventArgs e)
        {
            //  Method Name:            pbxCreated_MouseClick

            //  Method Purpose:         To react to the user has clicked on e.g clicked on their unit to move or attack the other player

            //  Called by Method:       Mouse Click

            //  Call to Method(s):      GetRandomDouble, CalculateRange, CreateRangeArray, NextPlayer, DamagedUnitImageSwitch

            //  Date Last Revised:      22/03/15

            //  Author:                 AC

            //-------------------------------Declaration of Variables-------------------------------\\


            PictureBox pbxClicked = sender as PictureBox;

            Unit unitSelected = new Unit();

            //Unit stats
            int player = 0;
            int unitType = 0;
            int positionOnBoard = 0;

            int scoreToAdd = 0;

            double attackingUnitMinDamage = 0;
            double attackingUnitMaxDamage = 0;
            double attackingUnitDamage = 0;

            double defendingUnitMinDamage = 0;
            double defendingUnitMaxDamage = 0;
            double defendingUnitDamage = 0;

            int unitSupply = 0;

            string tagInStringForm = "";
            string unitTypeString = "";

            string[] splitTag = new string[2];

            

            //-------------------------------End of Declaration of Variables-------------------------------\\

            try
            {
                //Determine unit type, player and position on board
                
                //get position on the board from the name (i.e. to locate it in the array)
                positionOnBoard = Convert.ToInt32(pbxClicked.Name);

                //Assign unit selected to a variable for easier use
                unitSelected = boardPositions[positionOnBoard];

                //Convert to string for formatting
                tagInStringForm = pbxClicked.Tag.ToString();

                //Split
                splitTag = tagInStringForm.Split(new char[] { ',' });

                //Convert to int
                unitType = Convert.ToInt32(splitTag[0]);

                switch (unitType)
                {
                    //Set variable to swordsman to be used later in the program
                    case 1: unitTypeString = "Swordsman";
                        break;

                    //Set variable to Archer to be used later in the program
                    case 2: unitTypeString = "Archer";
                        break;

                    //Set variable to Bruiser to be used later in the program
                    case 3: unitTypeString = "Bruiser";
                        break;

                    //Set variable to Hero to be used later in the program
                    case 4: unitTypeString = "Hero";
                        break;
                }

                //Convert to int
                player = Convert.ToInt32(splitTag[1]);

                //First unit clicked
                if (!firstUnitClickedBool)
                {
                    //If the player owns that unit
                    if (turnOfPlayer == player)
                    {
                        //if unit has a range of 1 it would be able to hit squares the adjacent squares
                        //if it has a range of 2 it will be able to hit everything in a 2 radius square
                        CalculateRange(capableOfHitting, ref rangeArrayPosition, unitSelected.Range, positionOnBoard);

                        //The global variable = the unit
                        firstUnitClicked = unitSelected;

                        //Get previous position
                        previousPositionOnBoard = positionOnBoard;

                        //Set the global picturebox
                        firstPictureBoxClicked = pbxClicked;

                        //Set bool to true
                        firstUnitClickedBool = true;

                        //Assign unit type to global
                        unitTypeOfFirstUnitClicked = unitType;
                        unitTypeOfFirstUnitClickedString = unitTypeString;
                    }
                    else
                    {
                        //Inform user of mistake
                        MessageBox.Show("That is not your unit\nTry Again.", "Incorrect Unit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        
                    }//End if

                }//Else if it is the second unit clicked
                else
                {   
                    //If the second square clicked is empty and within range
                    if (unitType == 0 && capableOfHitting.Contains(positionOnBoard))
                    {
                        //Make the previous square null
                        boardPositions[previousPositionOnBoard] = null;

                        //Set the empty square to have the properties of the unit that is moving
                        pbxClicked.Image = firstPictureBoxClicked.Image;
                        pbxClicked.Tag = firstPictureBoxClicked.Tag;

                        //set the square that the unit was previously in to blank
                        firstPictureBoxClicked.Image = null;
                        firstPictureBoxClicked.Tag = "0,0";

                        //Change the array so it is up to date on the unit's position
                        boardPositions[positionOnBoard] = firstUnitClicked;

                        //Reset the necessary variables
                        firstUnitClickedBool = false;

                        //Make next player's turn
                        nextPlayer();

                    }// if the second box is the opponent's unit and within range
                    else if (player != firstUnitClicked.Owner && capableOfHitting.Contains(positionOnBoard))
                    {
                        //Assign the player's unit's stats
                        attackingUnitMinDamage = firstUnitClicked.MinDamage;

                        //+1 beacause the random function uses exclusive upper limits
                        attackingUnitMaxDamage = firstUnitClicked.MaxDamage + 1;

                        //Generate the damage to deal
                        attackingUnitDamage = GetRandomDouble(attackingUnitMinDamage, attackingUnitMaxDamage);

                        //Attack the other unit
                        unitSelected.Health = unitSelected.Health - attackingUnitDamage;

                        //If the attacking unit is player 1's
                        if (firstUnitClicked.Owner == 1)
                        {
                            //Write to log
                            rtxt_Player1BattleLog.Text = rtxt_Player1BattleLog.Text + "Your " + unitTypeOfFirstUnitClickedString + " dealt " + attackingUnitDamage.ToString() + " damage to " + unitTypeString + "\n";

                            //Round for the score
                            scoreToAdd = Convert.ToInt32(Math.Round(attackingUnitDamage));

                            //Add score
                            player1CurrentScore = player1CurrentScore + scoreToAdd;

                            //Write to screen
                            lbl_Player1Score.Text = "Score: " + player1CurrentScore.ToString();

                        }
                        else// or player 2's unit
                        {
                            //Write to log
                            rtxt_Player2BattleLog.Text = rtxt_Player2BattleLog.Text + "Your " + unitTypeOfFirstUnitClickedString + " dealt " + attackingUnitDamage.ToString() + " damage to " + unitTypeString + "\n";

                            //Round for the score
                            scoreToAdd = Convert.ToInt32(Math.Round(attackingUnitDamage));

                            //Add score
                            player2CurrentScore = player2CurrentScore + scoreToAdd;

                            //Write to screen
                            lbl_Player2Score.Text = "Score: " + player2CurrentScore.ToString();                            

                        }//End if
                        
                        //If the attacker doesn't "kill" the unit with the first strike the unit can retaliate
                        if (unitSelected.Health > 0)
                        {
                            //if the first player is attacking
                            if (unitSelected.Owner == 1)
                            {
                                //Change image of unit on screen
                                DamagedUnitImageSwitch(pbxClicked, unitSelected, unitType, swordsmanHealthP1, archerHealthP1, bruiserHealthP1, heroHealthP1);

                            }
                            else //If the second player
                            {
                                //Change image of unit on screen
                                DamagedUnitImageSwitch(pbxClicked, unitSelected, unitType, swordsmanHealthP2, archerHealthP2, bruiserHealthP2, heroHealthP2);

                            }//End if
                            

                            //Assign the defending unit's stats
                            defendingUnitMinDamage = unitSelected.MinDamage / 2;
                            defendingUnitMaxDamage = unitSelected.MaxDamage / 2;

                            //Generate the damage to deal
                            defendingUnitDamage = GetRandomDouble(defendingUnitMinDamage, defendingUnitMaxDamage);

                            //Retaliate
                            firstUnitClicked.Health = firstUnitClicked.Health - defendingUnitDamage;

                            //if it is player 1's turn
                            if (turnOfPlayer == 1)
                            {
                                //Change image of unit on screen
                                DamagedUnitImageSwitch(firstPictureBoxClicked, firstUnitClicked, unitType, swordsmanHealthP1, archerHealthP1, bruiserHealthP1, heroHealthP1);

                            }
                            else
                            {
                                //Change image of unit on screen
                                DamagedUnitImageSwitch(firstPictureBoxClicked, firstUnitClicked, unitType, swordsmanHealthP2, archerHealthP2, bruiserHealthP2, heroHealthP2);

                            }//End if


                            //If the unit retaliating is player 1's unit
                            if (unitSelected.Owner == 1)
                            {
                                //Write to log
                                rtxt_Player1BattleLog.Text = rtxt_Player1BattleLog.Text + "Your " + unitTypeString + " dealt " + defendingUnitDamage.ToString("N1") + " damage to " + unitTypeOfFirstUnitClickedString + "\n";

                                //Round for the score
                                scoreToAdd = Convert.ToInt32(Math.Round(defendingUnitDamage));

                                //allocate score
                                player1CurrentScore = player1CurrentScore + scoreToAdd;

                                //Write to screen
                                lbl_Player1Score.Text = "Score: " + player1CurrentScore.ToString();
                            }
                            else //else if it is player 2's unit
                            {
                                //Write to log
                                rtxt_Player2BattleLog.Text = rtxt_Player2BattleLog.Text + "Your " + unitTypeString + " dealt " + defendingUnitDamage.ToString("N1") + " damage to " + unitTypeOfFirstUnitClickedString + "\n";

                                //Round for the score
                                scoreToAdd = Convert.ToInt32(Math.Round(defendingUnitDamage));

                                //Allocate score
                                player2CurrentScore = player2CurrentScore + scoreToAdd;

                                //Write to screen
                                lbl_Player2Score.Text = "Score: " + player2CurrentScore.ToString();

                            }//End if


                            //If the retaliation "kills" the attacking unit (i.e the user who ordered the attack)
                            if (firstUnitClicked.Health <= 0)
                            {
                                //Make the previous square null
                                boardPositions[previousPositionOnBoard] = null;

                                //Set the previous square to have the properties of the unit that is moving
                                firstPictureBoxClicked.Image = null;
                                firstPictureBoxClicked.Tag = "0,0";

                                //Work out how much supply to subtract
                                switch (unitTypeOfFirstUnitClicked)
                                {
                                    //if the unit killed is a swordsman then supply = 1
                                    case 1: unitSupply = 1;
                                        break;

                                    //if the unit killed is an archer then supply = 2
                                    case 2: unitSupply = archerSupplyMultiplier;
                                        break;

                                    //if the unit killed is a bruiser then supply = 4
                                    case 3: unitSupply = bruiserSupplyMultiplier;
                                        break;

                                    //if the unit killed is a hero then supply = 20
                                    case 4: unitSupply = heroSupplyMultiplier;
                                        break;

                                }//End switch

                                //Calculate new supply and score

                                //If the unit killed in retaliation is player 1's unit
                                if (firstUnitClicked.Owner == 1)
                                {
                                    //Calculate the supply
                                    currentSupplyPlayer1 = currentSupplyPlayer1 - unitSupply;

                                    //Add to the score
                                    player2CurrentScore = player2CurrentScore + unitSupply;

                                    //Write to screen
                                    lbl_SupplyPlayer1.Text = "Supply: " + currentSupplyPlayer1.ToString() + "/" + supplyLimit;
                                    lbl_Player2Score.Text = "Score: " + player2CurrentScore.ToString();

                                }
                                else //If the unit killed in retaliation is player 2's unit
                                {
                                    //Calculate the supply
                                    currentSupplyPlayer2 = currentSupplyPlayer2 - unitSupply;

                                    //Add to the score
                                    player1CurrentScore = player1CurrentScore + unitSupply;

                                    //Write to screen
                                    lbl_SupplyPlayer2.Text = "Supply: " + currentSupplyPlayer2.ToString() + "/" + supplyLimit;
                                    lbl_Player1Score.Text = "Score: " + player1CurrentScore.ToString();

                                }//End if

                            }//End if

                        }
                        else // if it does "kill" the unit then the attacking unit takes no damage and moves into that position
                        {
                            //Make the previous square null
                            boardPositions[previousPositionOnBoard] = null;

                            //Set the square to have the properties of the unit that is moving
                            pbxClicked.Image = firstPictureBoxClicked.Image;
                            pbxClicked.Tag = firstPictureBoxClicked.Tag;

                            //Set the previous square to have the properties of an empty square
                            firstPictureBoxClicked.Image = null;
                            firstPictureBoxClicked.Tag = "0,0";

                            //Change the array so it is up to date on the unit's position
                            boardPositions[positionOnBoard] = firstUnitClicked;

                            //Work out how much supply to subtract
                            switch (unitType)
                            {
                                case 1: unitSupply = 1;
                                    break;

                                case 2: unitSupply = archerSupplyMultiplier;
                                    break;

                                case 3: unitSupply = bruiserSupplyMultiplier;
                                    break;

                                case 4: unitSupply = heroSupplyMultiplier;
                                    break;

                            }//End switch
                            
                            //Calculate new supply and score
                            //If the unit killed is player 1's unit
                            if (unitSelected.Owner == 1)
                            {
                                //Calculate the supply
                                currentSupplyPlayer1 = currentSupplyPlayer1 - unitSupply;

                                //Add to the score
                                player2CurrentScore = player2CurrentScore + unitSupply;

                                //Write to screen
                                lbl_SupplyPlayer1.Text = "Supply: " + currentSupplyPlayer1.ToString() + "/" + supplyLimit;
                                lbl_Player2Score.Text = "Score: " + player2CurrentScore.ToString();
                                rtxt_Player1BattleLog.Text = rtxt_Player1BattleLog.Text + "Your " + unitTypeString + " was killed";

                            }
                            else //If the unit killed is player 2's unit
                            {
                                //Calculate the supply
                                currentSupplyPlayer2 = currentSupplyPlayer2 - unitSupply;

                                //Add to the score
                                player1CurrentScore = player1CurrentScore + unitSupply;

                                //Write to screen
                                lbl_SupplyPlayer2.Text = "Supply: " + currentSupplyPlayer2.ToString() + "/" + supplyLimit;
                                lbl_Player1Score.Text = "Score: " + player1CurrentScore.ToString();
                                rtxt_Player2BattleLog.Text = rtxt_Player2BattleLog.Text + "Your " + unitTypeString + " was killed";

                            }//End if

                        }//End if

                        CheckWinCondition();

                        //Reset the variables
                        firstUnitClickedBool = false;

                        //Make next player's turn
                        nextPlayer();

                    }
                    else if (player == firstUnitClicked.Owner)
                    {
                        MessageBox.Show("This is your own unit\nTry Again", "Invalid Unit", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        firstUnitClickedBool = false;

                    }
                    else
                    {
                        MessageBox.Show("This is not a valid unit.\nCheck if it is in range and try again", "Invalid Unit", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        firstUnitClickedBool = false;

                    }//End If

                }//End if

            }//End try
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }

        }//End pbxCreated_MouseClick



        private void DamagedUnitImageSwitch(PictureBox pbxClicked, Unit unitImageToChange, int unitType, double swordsmanMaxHealth, double archerMaxHealth, double bruiserMaxHealth, double heroMaxHealth)
        {
            //Instatiate sound clips
            System.Media.SoundPlayer swordClash = new System.Media.SoundPlayer(@"Swords Clash.wav");
            System.Media.SoundPlayer bowfire = new System.Media.SoundPlayer(@"Bow Fire.wav");
            System.Media.SoundPlayer maceSwing = new System.Media.SoundPlayer(@"Mace Swing.wav");

            try
            {
                //Switch on if it is a Swordsman, archer, bruiser or hero
                switch (unitType)
                {
                    //Check if the visible image of the unit is correct, i.e. does the unit have less than 25% to 75%
                    //And Play a sound
                    case 1:
                        changeImageWhenDamaged(unitImageToChange, swordsmanMaxHealth, pbxClicked, imglst_UnitIcons);
                        swordClash.Play();
                        break;

                    //Check if the visible image of the unit is correct, i.e. does the unit have less than 25% to 75%
                    //And Play a sound
                    case 2:
                        changeImageWhenDamaged(unitImageToChange, archerMaxHealth, pbxClicked, imglst_UnitIcons);
                        bowfire.Play();
                        break;

                    //Check if the visible image of the unit is correct, i.e. does the unit have less than 25% to 75%
                    //And Play a sound
                    case 3:
                        changeImageWhenDamaged(unitImageToChange, bruiserMaxHealth, pbxClicked, imglst_UnitIcons);
                        maceSwing.Play();
                        break;

                    //Check if the visible image of the unit is correct, i.e. does the unit have less than 25% to 75%
                    case 4:
                        changeImageWhenDamaged(unitImageToChange, heroMaxHealth, pbxClicked, imglst_UnitIcons);
                        break;

                }//End switch
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }
            
        }//End ChangeDamagedUnitImage



        private void CheckWinCondition()
        {
            //  Method Name:            CheckWinCondition

            //  Method Purpose:         Checks if either supply is 0

            //  Called by Method:       pbxCreated_MouseClick

            //  Call to Method(s):      UpdatePlayer, playerOne.CheckTopScore, playerTwo.CheckTopScore

            //  Date Last Revised:      23/03/15

            //  Author:                 AC

            try
            {
                //If player 1 has no units
                if (currentSupplyPlayer1 <= 0)
                {
                    //Inform them of win
                    MessageBox.Show("Congratulations " + playerTwo.Username + "\nYou have won", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Update players
                    UpdatePlayer(playerOne, 1);
                    UpdatePlayer(playerTwo, 2);

                    //Create the new form
                    frm_HighScoreScreen frm_EndScreen = new frm_HighScoreScreen(2);

                    //Swap focus
                    frm_EndScreen.Show();

                    //Hide this form
                    this.Hide();

                }//If player 2 has no units
                else if (currentSupplyPlayer2 <= 0)
                {
                    //Inform them of win
                    MessageBox.Show("Congratulations " + playerOne.Username + "\nYou have won", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Update players
                    UpdatePlayer(playerOne, 1);
                    UpdatePlayer(playerTwo, 2);

                    //Create the new form
                    frm_HighScoreScreen frm_EndScreen = new frm_HighScoreScreen(1);

                    //Swap focus
                    frm_EndScreen.Show();

                    //Hide this form
                    this.Hide();

                }//End if
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }
            
        }//End CheckWinCondition



        private void CalculateRange(int[] capableOfHitting, ref int rangeArrayPosition, int rangeOfUnit, int positionOnBoard)
        {
            //  Method Name:            CalculateRange

            //  Method Purpose:         Calculates the range of a selected unit

            //  Called by Method:       pbxCreated_MouseClick

            //  Call to Method(s):      CreateRangeArray

            //  Date Last Revised:      12/03/15

            //  Author:                 AC

            try
            {
                //---------------------------------------- Declaration of Variables ----------------------------------------\\
                int beginningOfRangeBoundaryL1 = 0;
                int beginningOfRangeBoundaryL2 = 0;
                //Line 3 is already set
                int beginningOfRangeBoundaryL4 = 0;
                int beginningOfRangeBoundaryL5 = 0;
                //---------------------------------------- End of Declaration of Variables ----------------------------------------\\

                //if the attacking unit's range is one
                if (rangeOfUnit == 1)
                {

                    //This means it is only capable of hitting the squares directly adjacent and diagonal
                    //E.G. If X = capable of hitting and O is the unit
                    //  X X X
                    //  X O X
                    //  X X X
                    capableOfHitting[0] = positionOnBoard - 1;
                    capableOfHitting[1] = positionOnBoard + 1;
                    capableOfHitting[2] = positionOnBoard + 11;
                    capableOfHitting[3] = positionOnBoard + 12;
                    capableOfHitting[4] = positionOnBoard + 13;
                    capableOfHitting[5] = positionOnBoard - 11;
                    capableOfHitting[6] = positionOnBoard - 12;
                    capableOfHitting[7] = positionOnBoard - 13;

                }
                else
                {
                    //Line 3 range values - These are the values for the two sides of the unit
                    capableOfHitting[0] = positionOnBoard - 2;
                    capableOfHitting[1] = positionOnBoard - 1;
                    capableOfHitting[2] = positionOnBoard + 1;
                    capableOfHitting[3] = positionOnBoard + 2;

                    //Set variables for beginning of range in a row
                    beginningOfRangeBoundaryL1 = positionOnBoard - 26;
                    beginningOfRangeBoundaryL2 = positionOnBoard - 14;
                    beginningOfRangeBoundaryL4 = positionOnBoard + 10;
                    beginningOfRangeBoundaryL5 = positionOnBoard + 22;

                    //Range starts 4 because 4 of the points have already been set
                    rangeArrayPosition = 4;

                    //Line 1 range values
                    rangeArrayPosition = CreateRangeArray(ref capableOfHitting, beginningOfRangeBoundaryL1, rangeArrayPosition);

                    //Line 2 range values                   
                    rangeArrayPosition = CreateRangeArray(ref capableOfHitting, beginningOfRangeBoundaryL2, rangeArrayPosition);

                    //Line 4 range values            
                    rangeArrayPosition = CreateRangeArray(ref capableOfHitting, beginningOfRangeBoundaryL4, rangeArrayPosition);

                    //Line 5 range values            
                    rangeArrayPosition = CreateRangeArray(ref capableOfHitting, beginningOfRangeBoundaryL5, rangeArrayPosition);

                }//End if
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }

            

        }//End CalculateRange



        private static int CreateRangeArray(ref int[] capableOfHitting, int beginningOfRangeBoundary, int rangeArrayPosition)
        {
            //  Method Name:            CreateRangeArray

            //  Method Purpose:         Sets the units range i.e. creates an array which contains all of the squares it can hit

            //  Called by Method:       CalculateRange

            //  Call to Method(s):      N/A

            //  Date Last Revised:      25/02/15

            //  Author:                 AC

            try
            {
                //Range Set                   
                for (int squaresAllocated = 0; squaresAllocated < 5; squaresAllocated++)
                {
                    //assign to range array
                    capableOfHitting[rangeArrayPosition] = beginningOfRangeBoundary + squaresAllocated;

                    //increment range
                    rangeArrayPosition++;

                }//End For
                
            }
            catch (Exception e)
            {
                ShowErrorMessage(e);
            }

            return rangeArrayPosition;

        }//End CreateRangeArray
         
        

        private void btn_Player1Ready_Click(object sender, EventArgs e)
        {
            //  Method Name:            btn_Player1Ready_Click

            //  Method Purpose:         Check if valid amount of supply is selected, if valid assign to user army

            //  Called by Method:       Clicking on btn_Player1Ready

            //  Call to Method(s):      CreateBoard

            //  Date Last Revised:      22/03/15

            //  Author:                 AC

            //This is for the assigning of units
            int armyArrayPosition = 0;

            try
            {      
                //Recalculate supply to ensure it is correctly calculated
                //Find total supply - increase by supply amount for each unit - i.e archer supply is * by 2 because it is 2 supply
                currentSupplyPlayer1 = nud_Player1SwordsmanAmount.Value + nud_Player1ArcherAmount.Value * archerSupplyMultiplier + nud_Player1BruiserAmount.Value * bruiserSupplyMultiplier + nud_Player1HeroAmount.Value * heroSupplyMultiplier;

                //Write to string
                lbl_SupplyPlayer1.Text = "Supply: " + currentSupplyPlayer1.ToString() + "/" + supplyLimit.ToString();


                //If supply is correct the player is ready
                if (currentSupplyPlayer1 == supplyLimit)
                {
                    //Hide and disable button
                    btn_Player1Ready.Visible = false;
                    btn_Player1Ready.Enabled = false;

                    //Disable the numeric up-down control
                    nud_Player1SwordsmanAmount.Enabled = false;
                    nud_Player1ArcherAmount.Enabled = false;
                    nud_Player1BruiserAmount.Enabled = false;
                    nud_Player1HeroAmount.Enabled = false;

                    //Allocate user is ready
                    Player1Ready = true;

                    //Hide all unit information and army building controls
                    pbx_Archer.Visible = false;
                    pbx_Bruiser.Visible = false;
                    pbx_Hero.Visible = false;
                    pbx_Swordsmen.Visible = false;

                    lbl_ArcherTitle.Visible = false;
                    lbl_ArcherSupply.Visible = false;
                    lbl_ArcherStatsP1.Visible = false;

                    lbl_BruiserTitle.Visible = false;
                    lbl_BruiserSupply.Visible = false;
                    lbl_BruiserStatsP1.Visible = false;

                    lbl_HeroTitle.Visible = false;
                    lbl_HeroSupply.Visible = false;
                    lbl_HeroStatsP1.Visible = false;

                    lbl_SwordsmanTitle.Visible = false;
                    lbl_SwordsmanSupply.Visible = false;
                    lbl_SwordsmanStatsP1.Visible = false;

                    nud_Player1ArcherAmount.Visible = false;
                    nud_Player1BruiserAmount.Visible = false;
                    nud_Player1HeroAmount.Visible = false;
                    nud_Player1SwordsmanAmount.Visible = false;

                    //makes the battle log visible
                    rtxt_Player1BattleLog.Visible = true;
                    rtxt_Player1BattleLog.Text = "Your army awaits your command\n";


                    //Assign the user's swordsmen to their army array
                    armyArrayPosition = AssignUnitsToArmyArray(nud_Player1SwordsmanAmount.Value, swordsmanHealthP1, swordsmanMinDamageP1, swordsmanMaxDamageP1, swordsmanIconP1, Player1Army, armyArrayPosition, 1, baseRange);

                    //Assign the user's archers to their army array
                    armyArrayPosition = AssignUnitsToArmyArray(nud_Player1ArcherAmount.Value, archerHealthP1, archerMinDamageP1, archerMaxDamageP1, archerIconP1, Player1Army, armyArrayPosition, 1, archerRange);

                    //Assign the user's bruisers to their army array
                    armyArrayPosition = AssignUnitsToArmyArray(nud_Player1BruiserAmount.Value, bruiserHealthP1, bruiserMinDamageP1, bruiserMaxDamageP1, bruiserIconP1, Player1Army, armyArrayPosition, 1, baseRange);

                    //Assign the user's hero
                    if (nud_Player1HeroAmount.Value == 1)
                    {
                        Unit Hero = new Unit(heroHealthP1, heroMinDamageP1, heroMaxDamageP1, heroIconP1, 1);

                        Player1Army[armyArrayPosition] = Hero;

                    }

                    //If the other player is ready                    
                    if (Player2Ready == true)
                    {
                        //Create the board
                        CreateBoard();

                    }//End if
                }
                else
                {
                    //Calculate differnce of supply is it too much or too little
                    remainingArmySupply = supplyLimit - Convert.ToInt32(currentSupplyPlayer1);


                    if (remainingArmySupply < 0)
                    {   //if it is too much inform them   //Multiply by -1 to make positive
                        MessageBox.Show("Please remove " + (remainingArmySupply * -1).ToString() + " supply", "Incorrect Supply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //If it is too little inform them
                        MessageBox.Show("Please allocate " + remainingArmySupply.ToString() + " supply", "Incorrect Supply", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }//End If

                }//End if
            }
            catch (Exception ex)
            {
                //Show error
                ShowErrorMessage(ex);
            }



        }//End btn_Player1Ready_Click



        private void btn_Player2Ready_Click(object sender, EventArgs e)
        {
            //  Method Name:            btn_Player2Ready_Click

            //  Method Purpose:         Check if valid amount of supply is selected, if valid assign to user army

            //  Called by Method:       Clicking on btn_Player1Ready

            //  Call to Method(s):      CreateBoard

            //  Date Last Revised:      22/03/15

            //  Author:                 AC

            //This is for the assigning of units
            int armyArrayPosition = 0;
            double player2Handicap = playerTwo.Handicap;

            try
            {                
                //Recalculate supply to ensure it is correctly calculated
                //Find total supply - increase by supply amount for each unit - i.e archer supply is * by 2 because it is 2 supply
                currentSupplyPlayer2 = nud_Player2SwordsmanAmount.Value + nud_Player2ArcherAmount.Value * archerSupplyMultiplier + nud_Player2BruiserAmount.Value * bruiserSupplyMultiplier + nud_Player2HeroAmount.Value * heroSupplyMultiplier;

                //Write to string
                lbl_SupplyPlayer2.Text = "Supply: " + currentSupplyPlayer2.ToString() + "/" + supplyLimit.ToString();

                //If supply is correct the player is ready
                if (currentSupplyPlayer2 == supplyLimit)
                {
                    //Hide and disable button
                    btn_Player2Ready.Visible = false;
                    btn_Player2Ready.Enabled = false;

                    //Disable the numeric up-down control
                    nud_Player2SwordsmanAmount.Enabled = false;
                    nud_Player2ArcherAmount.Enabled = false;
                    nud_Player2BruiserAmount.Enabled = false;
                    nud_Player2HeroAmount.Enabled = false;

                    //Allocate user is ready
                    Player2Ready = true;

                    //Hide all unit information and army building controls
                    pbx_ArcherP2.Visible = false;
                    pbx_BruiserP2.Visible = false;
                    pbx_HeroP2.Visible = false;
                    pbx_SwordsmenP2.Visible = false;

                    lbl_ArcherTitleP2.Visible = false;
                    lbl_ArcherSupplyP2.Visible = false;
                    lbl_ArcherStatsP2.Visible = false;

                    lbl_BruiserTitleP2.Visible = false;
                    lbl_BruiserSupplyP2.Visible = false;
                    lbl_BruiserStatsP2.Visible = false;

                    lbl_HeroTitleP2.Visible = false;
                    lbl_HeroSupplyP2.Visible = false;
                    lbl_HeroStatsP2.Visible = false;

                    lbl_SwordsmanTitleP2.Visible = false;
                    lbl_SwordsmanSupplyP2.Visible = false;
                    lbl_SwordsmanStatsP2.Visible = false;

                    nud_Player2ArcherAmount.Visible = false;
                    nud_Player2BruiserAmount.Visible = false;
                    nud_Player2HeroAmount.Visible = false;
                    nud_Player2SwordsmanAmount.Visible = false;

                    //Make the battle log visible
                    rtxt_Player2BattleLog.Visible = true;
                    rtxt_Player2BattleLog.Text = "Your army awaits your command\n";


                    //Assign the user's swordsmen to their army array                                                                                                                               
                    armyArrayPosition = AssignUnitsToArmyArray(nud_Player2SwordsmanAmount.Value, swordsmanHealthP2 , swordsmanMinDamageP2 , swordsmanMaxDamageP2 , swordsmanIconP2, Player2Army, armyArrayPosition, 2, baseRange);

                    //Assign the user's archers to their army array
                    armyArrayPosition = AssignUnitsToArmyArray(nud_Player2ArcherAmount.Value, archerHealthP2 , archerMinDamageP2 , archerMaxDamageP2 , archerIconP2, Player2Army, armyArrayPosition, 2, archerRange);

                    //Assign the user's bruisers to their army array
                    armyArrayPosition = AssignUnitsToArmyArray(nud_Player2BruiserAmount.Value, bruiserHealthP2 , bruiserMinDamageP2 , bruiserMaxDamageP2 , bruiserIconP2, Player2Army, armyArrayPosition, 2, baseRange);

                    //Assign the user's hero
                    if (nud_Player2HeroAmount.Value == 1)
                    {
                        Unit Hero = new Unit(heroHealthP2 , heroMinDamageP2 , heroMaxDamageP2 , heroIconP2, 2);

                        Player2Army[armyArrayPosition] = Hero;

                    } //If the other player is ready

                    if (Player1Ready == true)
                    {
                        //Create the board
                        CreateBoard();

                    }//End if

                }
                else
                {
                    //Calculate differnce of supply is it too much or too little
                    remainingArmySupply = supplyLimit - Convert.ToInt32(currentSupplyPlayer2);

                    if (remainingArmySupply < 0)
                    {
                        //if it is too much inform them   //Multiply by -1 to make positive
                        MessageBox.Show("Please remove " + (remainingArmySupply * -1).ToString() + " supply", "Incorrect Supply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //If it is too little inform them
                        MessageBox.Show("Please allocate " + remainingArmySupply.ToString() + " supply", "Incorrect Supply", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }//End If

                }//End If
            }
            catch (Exception ex)
            {
                //Show error
                ShowErrorMessage(ex);
            }



        }//End btn_Player2Ready_Click



        private static int AssignUnitsToArmyArray(decimal unitsRequired, double health, double minDamage, double maxDamage, int iconForUnit, Unit[] ArmyArray, int armyArrayPosition, int owner, int range)
        {
            //  Method Name:            AssignUnitsToArmyArray

            //  Method Purpose:         Assigns the units of a player to an array i.e. creates an array which contains all of the units in it

            //  Called by Method:       btn_Player1Ready_Click, btn_Player2Ready_Click

            //  Call to Method(s):      N/A

            //  Date Last Revised:      25/02/15

            //  Author:                 AC

            try
            {
                //Assign the units to the appropiate array
                for (int unitsCreated = 0; unitsCreated < unitsRequired; unitsCreated++)
                {
                    Unit unit = new Unit(health, minDamage, maxDamage, iconForUnit, owner, range);

                    ArmyArray[armyArrayPosition] = unit;

                    armyArrayPosition++;

                }//End For loop

            }
            catch (Exception ex)
            {
                //Show error
                ShowErrorMessage(ex);
            }

            return armyArrayPosition;

        }//End AssignSwordsmanToArmyArray



        private void nud_Player1SwordsmanAmount_ValueChanged(object sender, EventArgs e)
        {
            //  Method Name:            nud_Player1SwordsmanAmount_ValueChanged

            //  Method Purpose:         recalculates supply

            //  Called by Method:       Value being changed

            //  Call to Method(s):      N/A

            //  Date Last Revised:      12/03/15

            //  Author:                 AC

            try
            {
                //Find total supply - increase by supply amount for each unit - i.e archer supply is * by 2 because it is 2 supply
                currentSupplyPlayer1 = nud_Player1SwordsmanAmount.Value + nud_Player1ArcherAmount.Value * archerSupplyMultiplier + nud_Player1BruiserAmount.Value * bruiserSupplyMultiplier + nud_Player1HeroAmount.Value * heroSupplyMultiplier;

                //Write to string
                lbl_SupplyPlayer1.Text = "Supply: " + currentSupplyPlayer1.ToString() + "/" + supplyLimit.ToString();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }            

        }//End nud_Player1SwordsmanAmount_ValueChanged



        private void nud_Player2SwordsmanAmount_ValueChanged(object sender, EventArgs e)
        {
            //  Method Name:            nud_Player2SwordsmanAmount_ValueChanged

            //  Method Purpose:         recalculates supply

            //  Called by Method:       Value being changed

            //  Call to Method(s):      N/A

            //  Date Last Revised:      12/03/15

            //  Author:                 AC

            try
            {
                //Find total supply - increase by supply amount for each unit - i.e archer supply is * by 2 because it is 2 supply
                currentSupplyPlayer2 = nud_Player2SwordsmanAmount.Value + nud_Player2ArcherAmount.Value * archerSupplyMultiplier + nud_Player2BruiserAmount.Value * bruiserSupplyMultiplier + nud_Player2HeroAmount.Value * heroSupplyMultiplier;

                //Write to string
                lbl_SupplyPlayer2.Text = "Supply: " + currentSupplyPlayer2.ToString() + "/" + supplyLimit.ToString();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);                
            }            

        }//End nud_Player2SwordsmanAmount_ValueChanged



        private void nud_Player1ArcherAmount_ValueChanged(object sender, EventArgs e)
        {
            //  Method Name:            nud_Player1ArcherAmount_ValueChanged

            //  Method Purpose:         recalculates supply

            //  Called by Method:       Value being changed

            //  Call to Method(s):      N/A

            //  Date Last Revised:      12/03/15

            //  Author:                 AC

            try
            {
                //Find total supply - increase by supply amount for each unit - i.e archer supply is * by 2 because it is 2 supply
                currentSupplyPlayer1 = nud_Player1SwordsmanAmount.Value + nud_Player1ArcherAmount.Value * archerSupplyMultiplier + nud_Player1BruiserAmount.Value * bruiserSupplyMultiplier + nud_Player1HeroAmount.Value * heroSupplyMultiplier;

                //Write to string
                lbl_SupplyPlayer1.Text = "Supply: " + currentSupplyPlayer1.ToString() + "/" + supplyLimit.ToString();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }

            

        }//End nud_Player1ArcherAmount_ValueChanged



        private void nud_Player2ArcherAmount_ValueChanged(object sender, EventArgs e)
        {
            //  Method Name:            nud_Player2ArcherAmount_ValueChanged

            //  Method Purpose:         recalculates supply

            //  Called by Method:       Value being changed

            //  Call to Method(s):      N/A

            //  Date Last Revised:      12/03/15

            //  Author:                 AC

            try
            {
                //Find total supply - increase by supply amount for each unit - i.e archer supply is * by 2 because it is 2 supply
                currentSupplyPlayer2 = nud_Player2SwordsmanAmount.Value + nud_Player2ArcherAmount.Value * archerSupplyMultiplier + nud_Player2BruiserAmount.Value * bruiserSupplyMultiplier + nud_Player2HeroAmount.Value * heroSupplyMultiplier;

                //Write to string
                lbl_SupplyPlayer2.Text = "Supply: " + currentSupplyPlayer2.ToString() + "/" + supplyLimit.ToString();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }

            

        }//End nud_Player2ArcherAmount_ValueChanged



        private void nud_Player1BruiserAmount_ValueChanged(object sender, EventArgs e)
        {
            //  Method Name:            nud_Player1BruiserAmount_ValueChanged

            //  Method Purpose:         recalculates supply

            //  Called by Method:       Value being changed

            //  Call to Method(s):      N/A

            //  Date Last Revised:      12/03/15

            //  Author:                 AC

            try
            {
                //Find total supply - increase by supply amount for each unit - i.e archer supply is * by 2 because it is 2 supply
                currentSupplyPlayer1 = nud_Player1SwordsmanAmount.Value + nud_Player1ArcherAmount.Value * archerSupplyMultiplier + nud_Player1BruiserAmount.Value * bruiserSupplyMultiplier + nud_Player1HeroAmount.Value * heroSupplyMultiplier;

                //Write to string
                lbl_SupplyPlayer1.Text = "Supply: " + currentSupplyPlayer1.ToString() + "/" + supplyLimit.ToString();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }

            

        }//End nud_Player1BruiserAmount_ValueChanged



        private void nud_Player2BruiserAmount_ValueChanged(object sender, EventArgs e)
        {
            //  Method Name:            nud_Player2BruiserAmount_ValueChanged

            //  Method Purpose:         recalculates supply

            //  Called by Method:       Value being changed

            //  Call to Method(s):      N/A

            //  Date Last Revised:      12/03/15

            //  Author:                 AC

            try
            {
                //Find total supply - increase by supply amount for each unit - i.e archer supply is * by 2 because it is 2 supply
                currentSupplyPlayer2 = nud_Player2SwordsmanAmount.Value + nud_Player2ArcherAmount.Value * archerSupplyMultiplier + nud_Player2BruiserAmount.Value * bruiserSupplyMultiplier + nud_Player2HeroAmount.Value * heroSupplyMultiplier;

                //Write to string
                lbl_SupplyPlayer2.Text = "Supply: " + currentSupplyPlayer2.ToString() + "/" + supplyLimit.ToString();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }

            

        }//End nud_Player2BruiserAmount_ValueChanged



        private void nud_Player1HeroAmount_ValueChanged(object sender, EventArgs e)
        {
            //  Method Name:            nud_Player1HeroAmount_ValueChanged

            //  Method Purpose:         recalculates supply

            //  Called by Method:       Value being changed

            //  Call to Method(s):      N/A

            //  Date Last Revised:      12/03/15

            //  Author:                 AC

            try
            {
                //Find total supply - increase by supply amount for each unit - i.e archer supply is * by 2 because it is 2 supply
                currentSupplyPlayer1 = nud_Player1SwordsmanAmount.Value + nud_Player1ArcherAmount.Value * archerSupplyMultiplier + nud_Player1BruiserAmount.Value * bruiserSupplyMultiplier + nud_Player1HeroAmount.Value * heroSupplyMultiplier;

                //Write to string
                lbl_SupplyPlayer1.Text = "Supply: " + currentSupplyPlayer1.ToString() + "/" + supplyLimit.ToString();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }

            

        }//End nud_Player1HeroAmount_ValueChanged



        private void nud_Player2HeroAmount_ValueChanged(object sender, EventArgs e)
        {
            //  Method Name:            nud_Player2HeroAmount_ValueChanged

            //  Method Purpose:         recalculates supply

            //  Called by Method:       Value being changed

            //  Call to Method(s):      N/A

            //  Date Last Revised:      12/03/15

            //  Author:                 AC

            try
            {
                //Find total supply - increase by supply amount for each unit - i.e archer supply is * by 2 because it is 2 supply
                currentSupplyPlayer2 = nud_Player2SwordsmanAmount.Value + nud_Player2ArcherAmount.Value * archerSupplyMultiplier + nud_Player2BruiserAmount.Value * bruiserSupplyMultiplier + nud_Player2HeroAmount.Value * heroSupplyMultiplier;

                //Write to string
                lbl_SupplyPlayer2.Text = "Supply: " + currentSupplyPlayer2.ToString() + "/" + supplyLimit.ToString();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }

            

        }//End nud_Player2HeroAmount_ValueChanged



        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //  Method Name:            exitToolStripMenuItem_Click

            //  Method Purpose:         Exits the application

            //  Called by Method:       Selecting the option on the menu

            //  Call to Method(s):      N/A

            //  Date Last Revised:      22/03/15

            //  Author:                 AC

            try
            {
                //Ask if they are sure they want to quit
                DialogResult answer = MessageBox.Show("Are you sure you want to quit?", "Quit?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (answer == DialogResult.Yes)
                {
                    //Exit application
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }

            

        }//End exitToolStripMenuItem_Click



        private static void ShowErrorMessage(Exception ex)
        {
            //  Method Name:            ShowErrorMessage

            //  Method Purpose:         Reads in and displays an error message on screen

            //  Called by Method:       frm_TheBattlesOfMiddleEarth_Load, CreateBoard, pbxCreated_MouseClick, CalculateRange, CreateRangeArray
            //                          btn_Player1Ready_Click, btn_Player2Ready_Click, AssignUnitsToArmyArray, exitToolStripMenuItem_Click
            //                          changeImageWhenDamaged, GetRandomDouble, UpdatePlayer, showHighscoresToolStripMenuItem_Click, updatePlayer1ToolStripMenuItem_Click
            //                          updatePlayer2ToolStripMenuItem_Click, openHelpScreenToolStripMenuItem_Click, CheckWinCondition, exitToolStripMenuItem_Click

            //  Call to Method(s):      N/A

            //  Date Last Revised:      18/03/15

            //  Author:                 AC

            //Show error
            MessageBox.Show(ex.ToString(), "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }//End ShowErrorMessage



        private static void changeImageWhenDamaged(Unit unitToChange, double maxhealthForUnitType, PictureBox pbxToBeAffected, ImageList imglst_UnitIcons)
        {
            //  Method Name:            changeImageWhenDamaged

            //  Method Purpose:         Checks if the correct image is displaying

            //  Called by Method:       pbxCreated_MouseClick

            //  Call to Method(s):      N/A

            //  Date Last Revised:      12/03/15

            //  Author:                 AC

            try
            {
                //if unit is less than or equal to
                //25% health remaining
                if (unitToChange.Health <= maxhealthForUnitType / 4)
                {
                    //Change to a more damaged version of the image
                    pbxToBeAffected.Image = imglst_UnitIcons.Images[unitToChange.IconForUnit + 3];

                }//if at 50% health remaining
                else if (unitToChange.Health <= maxhealthForUnitType / 2)
                {
                    //Change to a more damaged version of the image
                    pbxToBeAffected.Image = imglst_UnitIcons.Images[unitToChange.IconForUnit + 2];

                }//if at 75% health remaining
                else if (unitToChange.Health <= maxhealthForUnitType * 3 / 4)
                {
                    //Change to a more damaged version of the image
                    pbxToBeAffected.Image = imglst_UnitIcons.Images[unitToChange.IconForUnit + 1];

                }//End if
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }
            

        }//End changeImageWhenDamaged



        public double GetRandomDouble(double minAttack, double maxAttack)
        {           
            //Generate double and round to 1 d.p.
            return Math.Round(rnd.NextDouble() * (maxAttack - minAttack) + minAttack, 1);

        }//End GetRandomDouble



        private void nextPlayer()
        {
            //  Method Name:            nextPlayer

            //  Method Purpose:         Makes changes player turn

            //  Called by Method:       Value being changed

            //  Call to Method(s):      N/A

            //  Date Last Revised:      12/03/15

            //  Author:                 AC

            try
            {
                if (turnOfPlayer == 1)
                {
                    turnOfPlayer++;

                    lbl_TurnInformation.Text = "Player 2's Turn";
                }
                else
                {
                    turnOfPlayer--;

                    lbl_TurnInformation.Text = "Player 1's Turn";

                }//End if
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }

        }//End NextPlayer



        private void UpdatePlayer(Player thisPlayer, int playerNumber)
        {
            //  Method Name:            UpdatePlayer

            //  Method Purpose:         Updates player details

            //  Called by Method:       updatePlayer1ToolStripMenuItem_Click, updatePlayer2ToolStripMenuItem_Click, pbxCreated_MouseClick

            //  Call to Method(s):      N/A

            //  Date Last Revised:      18/03/15

            //  Author:                 AC

            //Declare variables
            long positionOfPlayerRecordInFile = -1;
            bool playerFound = false;
            Player currentPlayer;

            try
            {
                //open file for read/write operation
                Stream st = File.Open("Player.bin", FileMode.Open, FileAccess.ReadWrite);

                BinaryFormatter bf = new BinaryFormatter();

                //read player details from file 

                //search through file and find a record                
                while (st.Position < st.Length && playerFound == false)
                {
                    //Record position of current player in file
                    positionOfPlayerRecordInFile = st.Position;

                    //read player object 
                    currentPlayer = (Player)bf.Deserialize(st);

                    //update player object if player is found 
                    if (currentPlayer.Username.Trim() == thisPlayer.Username.Trim())
                    {
                        //updates username and avatar 
                        currentPlayer = thisPlayer;

                        //updates score and highscore                        
                        if (playerNumber == 1)
                        {
                            currentPlayer.CheckTopScore(player1CurrentScore);
                        }
                        else
                        {
                            currentPlayer.CheckTopScore(player2CurrentScore);
                        }
                        
                        //from start of file seek position of player object 
                        st.Seek(positionOfPlayerRecordInFile, SeekOrigin.Begin);

                        //write updated player details back to position on file 
                        bf.Serialize(st, currentPlayer);

                        //set boolean flag to true - player found
                        playerFound = true;

                    }//End if

                }//End while
                
                //Free up RAM and close I/O channel
                st.Close();
                st.Dispose();

                //Check if a player was found
                if (playerFound)
                {
                    //If found say success
                    MessageBox.Show("Player " + playerNumber.ToString() + " record updated successfully", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //If not found say no player found
                    MessageBox.Show("No matching player record found for Player " + playerNumber.ToString(), "No Player Found", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }//End if

            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);

            }//End try catch

        }//End UpdatePlayer



        private void showHighscoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  Method Name:            showHighscoresToolStripMenuItem_Click

            //  Method Purpose:         Updates users and opens highscore screen

            //  Called by Method:       Click on the menu

            //  Call to Method(s):      UpdatePlayer

            //  Date Last Revised:      22/03/15

            //  Author:                 AC

            try
            {
                //Update players
                UpdatePlayer(playerOne, 1);
                UpdatePlayer(playerTwo, 2);

                if (player1CurrentScore > player2CurrentScore)
                {
                    //Open highscore screen
                    frm_HighScoreScreen frm_Highscores = new frm_HighScoreScreen(1);

                    //Show screen
                    frm_Highscores.Show();
                }
                else
                {
                    //Open highscore screen
                    frm_HighScoreScreen frm_Highscores = new frm_HighScoreScreen(2);

                    //Show screen
                    frm_Highscores.Show();
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }
    
        }//End showHighscoresToolStripMenuItem_Click



        private void updatePlayer1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  Method Name:            updatePlayer1ToolStripMenuItem_Click

            //  Method Purpose:         Updates player 1's details

            //  Called by Method:       click on the menu option

            //  Call to Method(s):      UpdatePlayer

            //  Date Last Revised:      18/03/15

            //  Author:                 AC

            try
            {
                //update Player File
                UpdatePlayer(playerOne, 1);
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }

            

        }//End updatePlayer1ToolStripMenuItem_Click



        private void updatePlayer2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  Method Name:            updatePlayer2ToolStripMenuItem_Click

            //  Method Purpose:         Updates player 2's details

            //  Called by Method:       click on the menu option

            //  Call to Method(s):      UpdatePlayer

            //  Date Last Revised:      18/03/15

            //  Author:                 AC

            try
            {
                //Update Player File
                UpdatePlayer(playerTwo, 2);
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }

            

        }//End updatePlayer2ToolStripMenuItem_Click



        protected override bool ProcessCmdKey(ref Message msg, Keys keyPressed)
        {

            //Check if F1 has been pressed
            if (keyPressed == Keys.F1)
            {
                //Open help screen
                frm_HelpScreen frm_help = new frm_HelpScreen();

                //Show screem
                frm_help.Show();

                //return showing the key press was handled
                return true;

            }//End If

            //Call the base class
            return base.ProcessCmdKey(ref msg, keyPressed);

        }//End ProcessCmdKey



        private void openHelpScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  Method Name:            openHelpScreenToolStripMenuItem_Click

            //  Method Purpose:         Opens help screen

            //  Called by Method:       click on the menu option

            //  Call to Method(s):      N/A

            //  Date Last Revised:      18/03/15

            //  Author:                 AC

            try
            {
                //Open help screen
                frm_HelpScreen frm_help = new frm_HelpScreen();

                //Show screen
                frm_help.Show();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }

        }//End openHelpScreenToolStripMenuItem_Click


    }//End class
}
