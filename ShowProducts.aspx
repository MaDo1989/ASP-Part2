<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowProducts.aspx.cs" Inherits="ShowProducts" MasterPageFile="~/MasterPage.master" %>


<asp:Content ID="myHead" ContentPlaceHolderID="head" runat="server">
    <style>
        input[type=checkbox] {
            margin: auto;
        }

        div {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="myBody" ContentPlaceHolderID="body" runat="server">
   
    <asp:PlaceHolder runat="server" ID="ph"></asp:PlaceHolder>
    <asp:Button text="Checkout" runat="server" OnClick="Checkout_Click" />
    <br />
</asp:Content>
