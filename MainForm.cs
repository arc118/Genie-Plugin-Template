using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGenieTemplate
{
    //The below class is used to create functionality for any pop-up windows you want to use with
    //Genie. 

    public partial class MainForm : Form
    {
        //Required Method for Form
        public MainForm()
        {
            InitializeComponent();
        }

        //Required Method for Form
        private void MainForm_Load(object sender, EventArgs e)
        {
           
        }

        //Optional Method, this controls what happens to the "Close Window" button for the Example Plug-in Window.
        // this.Close() will close the pop-up window when the user clicks the "Close Window" button
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
