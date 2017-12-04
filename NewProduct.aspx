<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewProduct.aspx.cs" Inherits="_Default" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="myBody" ContentPlaceHolderID="body" runat="server">
    <table style="width: 30%;">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
            </td>

            <td>
                <asp:TextBox ID="nameTB" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name is required" ControlToValidate="nameTB"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Price"></asp:Label></td>
            <td>
                <asp:TextBox ID="priceTB" runat="server"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Price is required" ControlToValidate="priceTB"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Category"></asp:Label></td>
            <td>
                <asp:DropDownList ID="categoryDDL" runat="server">
                </asp:DropDownList></td>

        </tr>

        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Info"></asp:Label>

            </td>
            <td>
                <textarea id="infoTA" cols="20" name="S1" rows="2" runat="server"></textarea>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Info is required" ControlToValidate="infoTA"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="sendBTN" runat="server" Text="Send" OnClick="sendBTN_Click" />
            </td>
        </tr>
        <%--        <tr>
            <td>
                <asp:Label ID="msgLBL" runat="server"></asp:Label>
            </td>
        </tr>--%>
    </table>
</asp:Content>

