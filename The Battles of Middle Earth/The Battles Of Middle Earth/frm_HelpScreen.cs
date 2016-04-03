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
    public partial class frm_HelpScreen : Form
    {
        public frm_HelpScreen()
        {
            InitializeComponent();
        }



        private void frm_HelpScreen_Load(object sender, EventArgs e)
        {
            //  Method Name:            frm_HelpScreen_Load

            //  Method Purpose:         Load files to rtxts

            //  Called by Method:       form load

            //  Call to Method(s):      N/A

            //  Date Last Revised:      09/03/15

            //  Author:                 AC

            try
            {
                //Load the information for the user reg screen
                rtxt_UserRegHelp.LoadFile("userRegistrationHelp.rtf", RichTextBoxStreamType.RichText);

                //Load the information for the main game screen
                rtxt_MainGameHelp.LoadFile("mainGameScreenHelp.rtf", RichTextBoxStreamType.RichText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

        }



    }
}
