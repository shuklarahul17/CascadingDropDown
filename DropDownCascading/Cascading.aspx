<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cascading.aspx.cs" Inherits="Cascading" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Continent  
            <asp:DropDownList ID="ddlcontinent" runat="server"  Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlcontinent_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div>
            Country  
            <asp:DropDownList ID="ddlcountry" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div>
            City     
            <asp:DropDownList ID="ddlcity" runat="server" Width="150px"></asp:DropDownList>
        </div>
    </form>
</body>
</html>
