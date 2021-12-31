using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeniePlugin.Interfaces;

namespace MyGenieTemplate
{

    // To work with Genie, the class must extend IPlugin, using GeniePlugin.Interfaces
    public class Program : IPlugin
    {
        //Constant variable for the Properties of the plugin
        //At the top for easy changes.
        readonly string _NAME = "MyGenieTemplate";
        readonly string _VERSION = "1.0";
        readonly string _AUTHOR = "Author";
        readonly string _DESCRIPTION = "Generic Description of a Genie Plug-In";

        public System.Windows.Forms.Form _parent;       //Required for plugin
        public IHost _host;                             //Required for plugin
        public MainForm _form;                          //Required for plugin and for using a pop-up Window in Genie

        private bool _enabled = true;                   //Required for plugin, for method Enabled

        #region iPlugin Required Properties

        //Required for Plugin - Name Called when Genie needs the name of the plugin (On menu)
        //Return Value:
        //              string: Text that is the name of the Plugin
        public string Name
        {
            get { return _NAME; }
        }

        //Required for Plugin - Called when Genie needs the plugin Author (plugins window)
        //Return Value:
        //              string: Text that is the Author of the plugin
        public string Author
        {
            get { return _AUTHOR; }
        }

        //Required for Plugin - Called when Genie needs the plugin version (error text
        //                      or the plugins window)
        //Return Value:
        //              string: Text that is the version of the plugin
        public string Version
        {
            get { return _VERSION; }
        }

        //Required for Plugin - Called when Genie needs the plugin Description (plugins window)
        //Return Value:
        //              string: Text that is the description of the plugin
        //                      This can only be up to 200 Characters long, else it will appear
        //                      "truncated"
        public string Description
        {
            get { return _DESCRIPTION; }
        }

        //Required for Plugin - Called when Genie needs disable/enable the plugin (Plugins window,
        //                      and from the CLI), or when Genie needs to know the status of the 
        //                      plugin (???)
        //Get:
        //      Not Known what it is used for
        //Set:
        //      Used by Plugins Window + CLI
        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }
        #endregion

        #region iPlugin Required Methods

        //Required for Plugin - Initialize() is called on first load
        //Parameters:
        //              IHost Host:  The host (instance of Genie) making the call
        public void Initialize(IHost Host)
        {
            _host = Host;
        }

        //Required for Plugin - Show() is called when clicking on the plugin 
        //name from the Menu item Plugins
        public void Show()
        {
            OpenWindow(_host.ParentForm);
        }

        //Required for Plugin - VariableChanged() is called when a global variable in genie
        //                      is changed
        //Parameters:
        //              string Text:  The variable name in Genie that changed
        public void VariableChanged(string Variable)
        {

        }

        //Required for Plugin - ParseText()
        //Parameters:
        //              string Text:    The DIRECT text comes from the game (non-"xml")
        //              string Window:  The Window the Text was received from
        //Return Value:
        //              string: Text that will be sent to the main window
        public string ParseText(string Text, string Window)
        {
            return Text;
        }

        //Required for Plugin - ParseInput() is called when user enters text in the command box
        //Parameters:
        //              string Text:  The text the user entered in the command box
        //Return Value:
        //              string: Text that will be sent to the game
        public string ParseInput(string Text)
        {
            //Example Text to input into Genie and example response
            if (Text == "/myplugin")
            {
                _host.SendText("This is a test response.");
                return "";
            }  
            return Text;
        }

        //Required for Plugin - ParseXML()
        //Parameters:
        //              string Text:  That "xml" text comes from the game
        public void ParseXML(string xml)
        {

        }

        //Required for Plugin - ParentClosing()
        public void ParentClosing()
        {

        }

        #endregion

        #region Custom Properties for your Plugin

        #endregion

        #region Custom Methods for your plugin

        //Opens the settings window.  Called when a user clicks on the menu item for 
        //this plugin (via above call)
        //
        //Parameters:
        //              Form Parent:  The parent form of the plugin.  Genie in this case
        public void OpenWindow(Form parent)
        {
            if (_form == null || _form.IsDisposed)
            {
                _form = new MainForm();
                _form.MdiParent = _parent;
            }
            _form.Show();
            _form.BringToFront();
        }

        //This can be removed if needed, used to compile a stand-alone plugin independent of launching Genie (for testing)
        //To compile as a stand-alone plug-in in Visual Basic (tested with VS 2019):
        //                   Under Properties, then Applications in Project, change compile from "Class Library" to "Windows Application"
        //                   "Class Library" compiles plug-in as DLL for Genie
        //                   "Windows Application" compiles plug-in as .EXE file (for testing outside of Genie)
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
        
        #endregion
    }
}
