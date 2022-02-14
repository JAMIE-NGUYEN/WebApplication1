<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="WebApplication1.Create" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
         <asp:TextBox ID="txtDate" runat="server" TextMode="Date" CssClass="form-control input-sm" Width="345px"></asp:TextBox>
        <asp:DropDownList ID="ddlStartTime" runat="server" CssClass="form-control" AppendDataBoundItems="false" Width="350px">
                    <asp:ListItem></asp:ListItem>
                     <asp:ListItem Value="3:00">3:00 AM</asp:ListItem>

                    <asp:ListItem Value="9:00">9:00 AM</asp:ListItem>
                    <asp:ListItem Value="10:00">10:00 AM</asp:ListItem>
                    <asp:ListItem Value="11:00">11:00 AM</asp:ListItem>
                    <asp:ListItem Value="12:00">12:00 AM</asp:ListItem>
                    <asp:ListItem Value="13:00">1:00 PM</asp:ListItem>
                    <asp:ListItem Value="14:00">2:00 PM</asp:ListItem>
                    <asp:ListItem Value="15:00">3:00 PM</asp:ListItem>
                    <asp:ListItem Value="16:00">4:00 PM</asp:ListItem>
                    <asp:ListItem Value="17:00">5:00 PM</asp:ListItem>
                    <asp:ListItem Value="18:00">6:00 PM</asp:ListItem>
                    <asp:ListItem Value="19:00">7:00 PM</asp:ListItem>
                </asp:DropDownList>    <br />        
            <asp:Button ID="Button1" runat="server" Text="Create" OnClick="Button1_Click" />

        </div>
          <div>
            <h2>Host URL</h2>
            <asp:Label ID="Host" runat="server" Text="Link"></asp:Label>
            <h2>Join URL</h2>
            <asp:Label ID="Join" runat="server" Text="Link"></asp:Label>
            <h2>Response Code</h2>
            <asp:Label ID="Code" runat="server" Text="Code"></asp:Label>
            <br />
            <br />
         </div>
    </form>
</body>
</html>
