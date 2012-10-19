using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PowerShellCall
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WhoAmI.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString();
        }

        protected void ExecuteCode_Click(object sender, EventArgs e)
        {
            // Clean the Result TextBox
            ResultBox.Text = string.Empty;
            ResultBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");

            string str = "";

            // Powershell
            Runspace runSpace = RunspaceFactory.CreateRunspace();
            runSpace.Open();
            Pipeline pipeline = runSpace.CreatePipeline();

            Command invokeScript = new Command("Invoke-Command");
            RunspaceInvoke invoke = new RunspaceInvoke();

            // invoke-command -computername compName -scriptblock { get-process }

            ScriptBlock sb = invoke.Invoke("{"+ PowerShellCodeBox.Text +"}")[0].BaseObject as ScriptBlock;
            invokeScript.Parameters.Add("scriptBlock", sb);
            invokeScript.Parameters.Add("computername", TextBoxServer.Text);

            pipeline.Commands.Add(invokeScript);
            Collection<PSObject> output = pipeline.Invoke();
            foreach (PSObject psObject in output)
            {

                str = str + psObject;
            }
            
            if (str == ""){
                str = "An error may have occured, check to make sure powershell remoting is turned on the remote server";
                str = str + "\r\n \r\n ";
                str = str + "\r\n To get powershell to work with an asp.net web page you must enable the following: ";
                str = str + "\r\n \r\n ";
                str = str + "\r\n 1. Run this > Enable-PSRemoting –force ";
                str = str + "\r\n 2. Add you remote computer to the trusted list >  winrm s winrm/config/client '@{TrustedHosts=``compName``}'";
                str = str + "\r\n 3. *note for windows server 2008 you just need to enable powershell remoting http://searchsystemschannel.techtarget.com/feature/PowerShell-remoting-in-Windows-Server-2008-R2 ";
                str = str + "\r\n 4. **You must have admin access on the remote server you are trying to execute the script on.**";
                str = str + "\r\n 5. ***This does not work on windows server 2003, unless you specifically installed powershell on it***"; 



                ResultBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
            }

            ResultBox.Text = str;

        }

    }

}