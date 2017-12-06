<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Payment.aspx.cs" Inherits="Payment" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="myHead" ContentPlaceHolderID="head" runat="server">
    <style>
        input, select {
            float: left;
            margin: 0 auto;
        }

        td {
            text-align: left;
        }

        #dateCal {
            float: left;
        }
    </style>
</asp:Content>

<asp:Content ID="myBody" ContentPlaceHolderID="body" runat="server">
    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:TextBox ID="nameTB" PlaceHolder="Name" runat="server">
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="nameTBVLD" BackColor="red" ControlToValidate="nameTB" runat="server" ErrorMessage="Name is required"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:TextBox ID="addressTB" PlaceHolder="Address" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="addressTBVLD" BackColor="red" ControlToValidate="addressTB" runat="server" ErrorMessage="Address is required"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <input type="email" placeholder="Email" required="required" id="emailTB" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:FileUpload ID="signFU" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Calendar ID="dateCal" runat="server" OnSelectionChanged="dateCal_SelectionChanged"></asp:Calendar>
                <asp:TextBox ID="dateTB" runat="server" Visible="false"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Date need to be in the next 30 days" BackColor="Red" ControlToValidate="dateTB" runat="server"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Visa<asp:CheckBox ID="visaCB" runat="server" AutoPostBack="true" /></asp:TableCell>
            <asp:TableCell>
                Phone Payment
                <asp:CheckBox ID="phoneCB" runat="server" AutoPostBack="true" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="wow">
            <asp:TableCell ID="visaFields">
                <asp:DropDownList ID="paymentsDDL" runat="server">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <asp:TextBox ID="visaTB" PlaceHolder="VISA Number" runat="server"></asp:TextBox>
                <asp:RangeValidator ID="visaTBVLD" ErrorMessage="Only Visa Number" ControlToValidate="visaTB" BackColor="Red" runat="server" MinimumValue="10000000" MaximumValue="9999999999999999"></asp:RangeValidator>
                <br />
                <br />
                <asp:TextBox ID="idTB" PlaceHolder="ID" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="idTBVLD" runat="server" BackColor="red" ControlToValidate="idTB" ErrorMessage="ID is required"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="idTBVLD2" runat="server" BackColor="red" ControlToValidate="idTB" OnServerValidate="idTBVLD2_ServerValidate" ErrorMessage="ID Error"></asp:CustomValidator>
                <br />
                <br />
                <asp:DropDownList ID="typeDDL" runat="server">
                    <asp:ListItem>VISA</asp:ListItem>
                    <asp:ListItem>Mastercard</asp:ListItem>
                    <asp:ListItem>American Express</asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="phoneTB" PlaceHolder="Phone Number" runat="server"></asp:TextBox>
                <asp:RangeValidator ID="phoneTBVLDR" runat="server" BackColor="red" ControlToValidate="phoneTB" MinimumValue="0520000000" MaximumValue="0589999999" ErrorMessage="Only Cellphone"></asp:RangeValidator>
                <asp:RequiredFieldValidator ID="phoneTBVLD" runat="server" BackColor="red" ControlToValidate="phoneTB" ErrorMessage="Phone is required"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <br />
                <asp:Label ID="finalPrice" runat="server"></asp:Label>
                <br />
                <asp:Button Text="Pay" ID="payBTN" runat="server" OnClick="payBTN_Click" />
                <br />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
