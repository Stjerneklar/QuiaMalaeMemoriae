<%@ Page Title="QuMalMem - Excercise 10" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Exercise10.aspx.cs" Inherits="Exercise10.Exercise10" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
            <div>
        </div>
        <asp:ListBox ID="ListBox1" runat="server" Height="295px" Width="552px"></asp:ListBox>
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Add the 3 doooogs" />
        <br />
        <br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server">5</asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server">4</asp:TextBox>
        <asp:TextBox ID="TextBox3" runat="server" Text="1"></asp:TextBox>
        <asp:TextBox ID="TextBox4" runat="server">2</asp:TextBox>
        <asp:TextBox ID="TextBox5" runat="server">3</asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Sort em" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="ASKW Sort em" />
&nbsp;
        <br />
</asp:Content>