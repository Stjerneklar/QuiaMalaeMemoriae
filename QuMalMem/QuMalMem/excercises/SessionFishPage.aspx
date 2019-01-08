<%@ Page Title="QuMalMem - SessionFish" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SessionFishPage.aspx.cs" Inherits="SessionFish.FishFront" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <div>
        </div>
        <asp:ListBox ID="ListBoxTank" runat="server" Height="225px" Width="299px"></asp:ListBox>
        <asp:Button ID="ButtonUpdateTank" runat="server" OnClick="ButtonUpdateTank_Click" Text="Update" />
        <br />
        <br />
        <asp:TextBox ID="TextBoxFishType" runat="server" ToolTip="Type of fish eg. Cod, Herring,.."></asp:TextBox>
        <asp:TextBox ID="TextBoxFishLength" runat="server" ToolTip="Length in cm"></asp:TextBox>
        <asp:TextBox ID="TextBoxFishWeight" runat="server" ToolTip="Weight in gram"></asp:TextBox>
        <asp:Button ID="ButtonAddFish" runat="server" OnClick="ButtonAddFish_Click" Text="Add" />
        <br />
</asp:Content>