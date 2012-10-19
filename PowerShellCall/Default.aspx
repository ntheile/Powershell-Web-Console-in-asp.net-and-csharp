<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PowerShellCall._Default" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <form id="form1" runat="server">
    <center>
        <div>
            <table>
                <tr><td><h1>PowerShell Web Console</h1></td></tr>
                 <tr><td>
                    Server:<asp:TextBox ID="TextBoxServer" runat="server" BackColor="DarkBlue" ForeColor="White" Width="200px"></asp:TextBox>
                </td></tr>

                <tr><td>
                    <asp:TextBox ID="PowerShellCodeBox" runat="server" TextMode="MultiLine" 
                        BackColor="DarkBlue" ForeColor="White" Width=1022px Height=100px></asp:TextBox>
                </td></tr>

                <tr><td>
                    <asp:Button ID="ExecuteCode" runat="server" Text="Execute" Width=200 onclick="ExecuteCode_Click"/>
                    <br /><br />
                </td></tr>

                <tr><td>
                    <h3>Result</h3>
                    <asp:TextBox  ID="ResultBox" TextMode="MultiLine" Width=1036px Height=200px 
                        BackColor="DarkBlue" ForeColor="White" runat="server"></asp:TextBox>
                </td></tr>

                <tr><td>
                    Powershell Script Running as IIS App Pool Identity : <asp:label  ID="WhoAmI" runat="server"></asp:label>
                </td></tr>

            </table>
        </div>
    </center>
    </form>

</body>
</html>
