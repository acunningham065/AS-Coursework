using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Battles_Of_Middle_Earth
{
    //Feeback
    //Module header missing

    public partial class frm_SplashScreen : Form
    {
        public frm_SplashScreen()
        {
            InitializeComponent();
        }

        private void tmr_SplashScreen_Tick(object sender, EventArgs e)
        {
            //  Method Name:            tmr_SplashScreen_Tick

            //  Method Purpose:         Instantiate user registration form

            //  Called by Method:       tick event

            //  Call to Method(s):      N/A

            //  Date Last Revised:      09/03/15

            //  Author:                 AC

            //Exception handler

            try//Try to perform this task
            {
                //this code will run after 3 seconds has elapsed

                //1. Disable the timer
                tmr_SplashScreen.Enabled = false;

                //Test Stub
                //MessageBox.Show("Three seconds elapsed\nTick event fired");

                //2. Create and display the user registration form
                frm_UserRegistration frm_NewUserRegistration = new frm_UserRegistration();

                //3. Show the user reg screen
                frm_NewUserRegistration.Show();

                //4. Hide the splash screen
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }//End Try catch


        }//End tmr_SplashScreen_Tick
    }
}
