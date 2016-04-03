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

    public partial class frm_UserRegistration : Form
    {
        //----------------------------Declaration of Global Variables----------------------------\\
        int avatarChosenByPlayer = 0;

        double handicap = 0;

        List<Player> lstPlayers = new List<Player>();

        string fileName = "Player.bin";

        Player playerBeingCreated = new Player();

        Player player1 = new Player();

        Player player2 = new Player();

        bool indexChangedDueToPlayerCreation = false;

        //----------------------------End of Declaration of Global Variables----------------------------\\


        public frm_UserRegistration()
        {
            InitializeComponent();
        }
        

        private void pbx_AvatarChoice1_Click(object sender, EventArgs e)
        {
            //Exception Handler
            try
            {
                pbx_PlayerAvatar.Image = pbx_AvatarChoice1.Image;
                avatarChosenByPlayer = 0;
            }
            catch (Exception ex)
            {
                //Show error message
                MessageBox.Show(ex.Message);

            }//End Try Catch

            
        }//End pbx_AvatarChoice1_Click



        private void pbx_AvatarChoice2_Click(object sender, EventArgs e)
        {
            //Exception Handler
            try
            {
                pbx_PlayerAvatar.Image = pbx_AvatarChoice2.Image;
                avatarChosenByPlayer = 1;
            }
            catch (Exception ex)
            {
                //Show error message
                MessageBox.Show(ex.Message);
            }//End Try Catch

        }//End pbx_AvatarChoice2_Click



        private void pbx_AvatarChoice3_Click(object sender, EventArgs e)
        {
            //Exception Handler
            try
            {
                pbx_PlayerAvatar.Image = pbx_AvatarChoice3.Image;
                avatarChosenByPlayer = 2;
            }
            catch (Exception ex)
            {
                //Show error message
                MessageBox.Show(ex.Message);
            }//End Try Catch

        }//End pbx_AvatarChoice3_Click



        private void pbx_AvatarChoice4_Click(object sender, EventArgs e)
        {
            //Exception Handler
            try
            {
                pbx_PlayerAvatar.Image = pbx_AvatarChoice4.Image;
                avatarChosenByPlayer = 3;
            }
            catch (Exception ex)
            {
                //Show error message
                MessageBox.Show(ex.Message);

            }//End Try Catch

        }//End pbx_AvatarChoice4_Click



        private void pbx_AvatarChoice5_Click(object sender, EventArgs e)
        {
            //Exception Handler
            try
            {
                pbx_PlayerAvatar.Image = pbx_AvatarChoice5.Image;
                avatarChosenByPlayer = 4;
            }
            catch (Exception ex)
            {
                //Show error message
                MessageBox.Show(ex.Message);

            }//End Try Catch

        }//End pbx_AvatarChoice5_Click



        private void pbx_AvatarChoice6_Click(object sender, EventArgs e)
        {
            //Exception Handler
            try
            {
                pbx_PlayerAvatar.Image = pbx_AvatarChoice6.Image;
                avatarChosenByPlayer = 5;
            }
            catch (Exception ex)
            {
                //Show error message
                MessageBox.Show(ex.Message);

            }//End Try Catch

        }//End pbx_AvatarChoice6_Click



        private void btn_AddPlayer1_Click(object sender, EventArgs e)
        {
            //  Method Name:            btn_AddPlayer1_Click

            //  Method Purpose:         To validate player 1 details and send them to the Main game screen

            //  Called by Method:       clicking the btn_AddPlayer1

            //  Call to Method(s):      ValidateUserDetails, CreateNewGame

            //  Date Last Revised:      18/03/15

            //  Author:                 AC

            try
            {
                //Validate details
                ValidateUserDetails(1);

                //Check if the other user has been instantiated
                if (player2.Username != null)
                {
                    CreateNewGame();
                }

            }
            catch (Exception ex)
            {
                //Show error message
                MessageBox.Show(ex.Message);

            }//End try catch
            
        }//End btn_AddPlayer1_Click



        private void btn_AddPlayer2_Click(object sender, EventArgs e)
        {
            //  Method Name:            btn_AddPlayer2_Click

            //  Method Purpose:         To validate player 2 details and send them to the Main game screen

            //  Called by Method:       clicking the btn_AddPlayer2

            //  Call to Method(s):      ValidateUserDetails, CreateNewGame

            //  Date Last Revised:      18/03/15

            //  Author:                 AC

            try
            {
                //Validate details
                ValidateUserDetails(2);

                //Check if the other user has been instantiated
                if (player1.Username != null)
                {
                    CreateNewGame();
                }

            }
            catch (Exception ex)
            {
                //Show error message
                MessageBox.Show(ex.Message);

            }//End try catch


        }//End btn_AddPlayer2_Click



        private void ValidateUserDetails(int playerNumber)
        {
            //  Method Name:            ValidateUserDetails

            //  Method Purpose:         To validate player details and send them to the Main game screen

            //  Called by Method:       btn_AddPlayer1_Click or btn_AddPlayer2_Click

            //  Call to Method(s):      N/A

            //  Date Last Revised:      09/03/15

            //  Author:                 AC

            if (txt_Username.Text.Trim() != "" && txt_Username.Text.Trim().Length >= 3)
            {
                if (txt_Password.Text.Trim() != "" && txt_Password.Text.Trim().Length >= 4)
                {
                    if (pbx_PlayerAvatar.Image != null)
                    {
                        if (handicap != 0)
                        {
                            //Create a new object for the player with all of the details
                            Player newPlayer = new Player(txt_Username.Text, txt_Password.Text, avatarChosenByPlayer, handicap);

                            //Save Player
                            SavePlayerToFile(newPlayer);

                            //Clear fields
                            txt_Username.Clear();
                            txt_Password.Clear();
                            pbx_PlayerAvatar.Image = null;
                            cmb_HandicapNU.Text = "Please Select";
                            handicap = 0;
                            

                            if (playerNumber == 1)
                            {
                                //Assign Player details
                                player1 = newPlayer;

                                //Hide the relevant buttons
                                btn_AddExistingPlayer1.Visible = false;
                                btn_AddPlayer1.Visible = false;

                            }
                            else
                            {
                                //Assign Player details
                                player2 = newPlayer;

                                //Hide the relevant buttons
                                btn_AddExistingPlayer2.Visible = false;
                                btn_AddPlayer2.Visible = false;

                            }//End If


                        }
                        else
                        {
                            //Inform the user to set their handicap
                            MessageBox.Show("Please set your handicap", "Handicap not selected", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //sets focus to the avatar control
                            cmb_HandicapNU.Focus();

                        }//End if
                        
                    }
                    else
                    {
                        //Inform the user to enter a valid password
                        MessageBox.Show("Please choose an avatar", "Avatar Missing", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //sets focus to the avatar control
                        pbx_AvatarChoice1.Focus();

                    }//End Avatar if
                }
                else
                {
                    //Inform the user to enter a valid password
                    MessageBox.Show("Please enter a valid password (at least 8 characters long)", "Password Missing", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //sets focus to the password control
                    txt_Password.Focus();

                }//End Password If
            }
            else
            {
                //Inform the user to enter a valid username
                MessageBox.Show("Please enter a valid username (at least 3 characters long)", "User Name Missing", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Set focus to the username control
                txt_Username.Focus();

            }//End Username If

        }//End ValidateUserDetails



        private void SavePlayerToFile(Player newPlayer)
        {
            //  Method Name:            SavePlayerToFile

            //  Method Purpose:         To save player details to a binary file

            //  Called by Method:       ValidateUserDetails

            //  Call to Method(s):      ShowErrorMessage

            //  Date Last Revised:      09/03/15

            //  Author:                 AC

            try
            {
                //open I/O stream
                Stream st = File.Open(fileName, FileMode.Append);

                //set binary formatter
                BinaryFormatter bf = new BinaryFormatter();

                //write player object to file in binary format
                bf.Serialize(st, newPlayer);

                //close I/O stream and free up RAM
                st.Close();
                st.Dispose();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }

        }//End SavePlayerToFile



        private void frm_UserRegistration_Load(object sender, EventArgs e)
        {
            //  Method Name:            frm_UserRegistration_Load

            //  Method Purpose:         Loads players' details from the player.bin binary file

            //  Called by Method:       Form loading

            //  Call to Method(s):      ShowErrorMessage

            //  Date Last Revised:      09/03/15

            //  Author:                 AC

            try
            {
                //check file exists
                if (File.Exists(fileName))
                {
                    //open read stream
                    Stream st = File.Open(fileName, FileMode.Open);
                    
                    //define binary formatter
                    BinaryFormatter bf = new BinaryFormatter();

                    //read in player binary objects while not the end of file
                    while (st.Position < st.Length)
                    {
                        //read one player binary object
                        Player playerReadFromFile = (Player)bf.Deserialize(st);

                        //Add to screen list box
                        lst_ExistingUser.Items.Add(playerReadFromFile.Username);

                        //add player object to list
                        lstPlayers.Add(playerReadFromFile);

                    }//End While

                    //close I/O channel and free up RAM
                    st.Close();
                    st.Dispose();
                }
                else
                {
                    //Inform users
                    MessageBox.Show("No Player File Found", "No Player File", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //flag no player objects exists
                    lst_ExistingUser.Items.Add("No player details on file");

                }//End If

                //Set the drop-down boxes to show this message
                cmb_HandicapNU.Text = "Please select";
                cmb_HandicapEU.Text = "Please select";

                //Inform user that F1 key is help screen
                MessageBox.Show("You can press the F1 key at any time to access the help screen", "Help Screen", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);

            }//End Try Catch

        }//End frm_UserRegistration_Load



        private static void ShowErrorMessage(Exception ex)
        {
            //Show error
            MessageBox.Show(ex.ToString(), "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }//End ShowErrorMessage



        private void lst_ExistingUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  Method Name:            lst_ExistingUser_SelectedIndexChanged

            //  Method Purpose:         works out what set of player details are selected

            //  Called by Method:       Index change on the lst_ExistingUser

            //  Call to Method(s):      ShowErrorMessage

            //  Date Last Revised:      09/03/15

            //  Author:                 AC

            try
            {
                //If the selected index hasn't changed due to the user details being removed from the on screen list
                if (lst_ExistingUser.SelectedIndex != -1)
                {
                    if (!indexChangedDueToPlayerCreation)
                    {
                        //Set player details
                        playerBeingCreated = lstPlayers[lst_ExistingUser.SelectedIndex];

                        //Assign avatar to show on screen
                        pbx_AvatarEU.Image = imglst_UserAvatars.Images[playerBeingCreated.Avatar];
                    }
                    else
                    {
                        //Set player details        //+1 as the player created already has been deleted
                        playerBeingCreated = lstPlayers[lst_ExistingUser.SelectedIndex + 1];

                        //Assign avatar to show on screen
                        pbx_AvatarEU.Image = imglst_UserAvatars.Images[playerBeingCreated.Avatar];

                    }//End If

                }//End if
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }

        }//End lst_ExistingUser_SelectedIndexChanged



        private void btn_AddExistingPlayer1_Click(object sender, EventArgs e)
        {
            //  Method Name:            btn_AddExistingPlayer1_Click

            //  Method Purpose:         Saves the details to player 1

            //  Called by Method:       btn_AddExistingPlayer1 clicked

            //  Call to Method(s):      ShowErrorMessage

            //  Date Last Revised:      09/03/15

            //  Author:                 AC

            try
            {
                if (txt_PasswordEU.Text == playerBeingCreated.Password)
                {
                    if (handicap != 0)
                    {
                        //Assign the palyer
                        player1 = playerBeingCreated;
                        player1.Handicap = handicap;

                        //Hide the buttons relevant to player
                        btn_AddExistingPlayer1.Visible = false;
                        btn_AddPlayer1.Visible = false;

                        //Clear fields
                        txt_PasswordEU.Clear();
                        pbx_AvatarEU.Image = null;
                        cmb_HandicapEU.Text = "Please select";
                        handicap = 0;
                        indexChangedDueToPlayerCreation = true;

                        //Remove the user from the list
                        lst_ExistingUser.Items.RemoveAt(lst_ExistingUser.SelectedIndex);


                        //If the other user has entered their details then start a game
                        if (player2.Username != null)
                        {
                            CreateNewGame();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please select a handicap", "Handicap not selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }//End if

                }
                else
                {
                    MessageBox.Show("The password you entered is not valid for this user\nPlease try again", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    //Clear text box
                    txt_PasswordEU.Text = "";

                }//End if
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }

        }//End btn_AddExistingPlayer1_Click



        private void btn_AddExistingPlayer2_Click(object sender, EventArgs e)
        {
            //  Method Name:            btn_AddExistingPlayer2_Click

            //  Method Purpose:         Saves the details to player 2

            //  Called by Method:       btn_AddExistingPlayer2 clicked

            //  Call to Method(s):      ShowErrorMessage

            //  Date Last Revised:      09/03/15

            //  Author:                 AC

            try
            {
                if (txt_PasswordEU.Text == playerBeingCreated.Password)
                {
                    if (handicap != 0)
                    {
                        //Assign the player
                        player2 = playerBeingCreated;
                        player2.Handicap = handicap;

                        //Hide the buttons relevant to player
                        btn_AddExistingPlayer2.Visible = false;
                        btn_AddPlayer2.Visible = false;

                        //Clear fields
                        txt_PasswordEU.Clear();
                        pbx_AvatarEU.Image = null;
                        cmb_HandicapEU.Text = "Please select";
                        handicap = 0;
                        indexChangedDueToPlayerCreation = true;

                        //Remove the user from the list
                        lst_ExistingUser.Items.RemoveAt(lst_ExistingUser.SelectedIndex);

                        //If the other user has entered their details then start a game
                        if (player1.Username != null)
                        {
                            CreateNewGame();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a handicap", "Handicap not selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }//end if
                }
                else
                {
                    MessageBox.Show("The password you entered is not valid for this user\nPlease try again", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    //Clear text box
                    txt_PasswordEU.Text = "";

                }//End if
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }
                        
        }//End btn_AddExistingPlayer2_Click



        private void CreateNewGame()
        {
            //  Method Name:            CreateNewGame

            //  Method Purpose:         Instantiates form

            //  Called by Method:       btn_AddPlayer1_Click, btn_AddPlayer2_Click, btn_AddExistingPlayer1_Click, btn_AddExistingPlayer2_Click

            //  Call to Method(s):      ShowErrorMessage

            //  Date Last Revised:      09/03/15

            //  Author:                 AC

            try
            {
                //Create new game
                frm_TheBattlesOfMiddleEarth frm_NewGame = new frm_TheBattlesOfMiddleEarth(player1, player2);

                //Put focus to that screen
                frm_NewGame.Show();

                //Hide this one
                this.Hide();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }

        }//End CreateNewGame



        private void cmb_HandicapNU_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSelectedHandicap(cmb_HandicapNU.SelectedIndex);

        }//End cmb_HandicapNU_SelectedIndexChanged



        private void cmb_HandicapEU_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSelectedHandicap(cmb_HandicapEU.SelectedIndex);

        }//End cmb_HandicapEU_SelectedIndexChanged



        private void SetSelectedHandicap(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0: handicap = 0.7;
                    break;

                case 1: handicap = 0.8;
                    break;

                case 2: handicap = 0.9;
                    break;

                case 3: handicap = 1;
                    break;

            }//End Switch

        }//End SetSelectedHandicap



        protected override bool ProcessCmdKey(ref Message msg, Keys keyPressed)
        {
            //  Method Name:            ProcessCmdKey

            //  Method Purpose:         Checks if F1 has been pressed

            //  Called by Method:       Pressing F1

            //  Call to Method(s):      ShowErrorMessage

            //  Date Last Revised:      09/03/15

            //  Author:                 AC

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


    }
}
