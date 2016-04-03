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
    public partial class frm_HighScoreScreen : Form
    {
        //-----------------------Declaration of Global Variables-----------------------\\

        List<Player> lstPlayers = new List<Player>();

        string fileName = "Player.bin";

        int winningPlayer = 1;

        Point positionForElrond = new Point(352, 141);
        Point positionForSauron = new Point(311, 175);


        //-----------------------End of Declaration of Global Variables-----------------------\\


        public frm_HighScoreScreen()
        {
            try
            {
                InitializeComponent();

            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }

        }


        //Overloaded Constructor for passing current screen in
        public frm_HighScoreScreen(int winningPlayerPassedIn)
        {
            try
            {
                InitializeComponent();

                winningPlayer = winningPlayerPassedIn;
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }
            
        }
        

        private void frm_HighScoreScreen_Load(object sender, EventArgs e)
        {
            //  Method Name:            frm_HighScoreScreen_Load

            //  Method Purpose:         Assign correct gif and load in and display top scores

            //  Called by Method:       Loading of the form

            //  Call to Method(s):      N/A

            //  Date Last Revised:      23/03/15

            //  Author:                 AC

            try
            {
                winningPlayer = 2;

                //Select Gif
                if (winningPlayer == 1)
                {
                    //Change Picture
                    pbx_GifToShow.Image = Properties.Resources.Elrond;

                    //Change size
                    pbx_GifToShow.Height = 160;
                    pbx_GifToShow.Width = 160;

                    //Change location
                    pbx_GifToShow.Location = positionForElrond;
                }
                else
                {
                    //Change Picture
                    pbx_GifToShow.Image = Properties.Resources.Sauron;

                    //Change size
                    pbx_GifToShow.Height = 105;
                    pbx_GifToShow.Width = 250;

                    //Change location
                    pbx_GifToShow.Location = positionForSauron;
                }

                //open read stream
                Stream st = File.Open(fileName, FileMode.Open);

                //define binary formatter
                BinaryFormatter bf = new BinaryFormatter();

                //read in player binary objects while not the end of file
                while (st.Position < st.Length)
                {
                    //read one player binary object
                    Player playerReadFromFile = (Player)bf.Deserialize(st);

                    //add player object to list
                    lstPlayers.Add(playerReadFromFile);

                }//End While

                //close I/O channel and free up RAM
                st.Close();
                st.Dispose();

                //Order By Descending High score
                lstPlayers = lstPlayers.OrderByDescending(Player => Player.Highscore).ToList();

                //Add players to on screen
                for (int currentHighScore = 0; currentHighScore < lstPlayers.Count && currentHighScore < 5; currentHighScore++)
                {
                    //Write to the screen
                    lst_HighscoreList.Items.Add((currentHighScore + 1) + ". " + lstPlayers[currentHighScore].Username + "\t" + lstPlayers[currentHighScore].Highscore);

                }//End For
                
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);

            }//End Try Catch

        }//End frm_HighScoreScreen_Load



        private static void ShowErrorMessage(Exception ex)
        {
            //  Method Name:            ShowErrorMessage

            //  Method Purpose:         Show the error message

            //  Called by Method:       frm_HighScoreScreen, frm_HighScoreScreen, frm_HighScoreScreen_Load, btn_Replay_Click, btn_Exit_Click

            //  Call to Method(s):      N/A

            //  Date Last Revised:      23/03/15

            //  Author:                 AC

            //Show error
            MessageBox.Show(ex.ToString(), "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }//End ShowErrorMessage



        private void btn_Replay_Click(object sender, EventArgs e)
        {
            //  Method Name:            btn_Replay_Click

            //  Method Purpose:         Close current game and screen and open the user registration screen

            //  Called by Method:       Click on the btn_Replay

            //  Call to Method(s):      N/A

            //  Date Last Revised:      23/03/15

            //  Author:                 AC

            try
            {
                DialogResult answer = MessageBox.Show("Would you like to play again", "Play Again?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                if (answer == DialogResult.Yes)
                {
                    //Create a new form
                    frm_UserRegistration frm_RegistrationScreen = new frm_UserRegistration();

                    //Show screen
                    frm_RegistrationScreen.Show();

                    //Close this screen and main screen
                    this.Hide();

                    //Select current game
                    frm_TheBattlesOfMiddleEarth currentGame = (frm_TheBattlesOfMiddleEarth)Application.OpenForms["frm_TheBattlesOfMiddleEarth"];

                    //Close Current game
                    currentGame.Close();
                }

            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }
            

            

        }//End btn_Replay_Click



        private void btn_Exit_Click(object sender, EventArgs e)
        {
            //  Method Name:            btn_Exit_Click

            //  Method Purpose:         Closes the application

            //  Called by Method:       Click on the btn_Exit

            //  Call to Method(s):      N/A

            //  Date Last Revised:      23/03/15

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

        }//End btn_Exit_Click
    }
}
