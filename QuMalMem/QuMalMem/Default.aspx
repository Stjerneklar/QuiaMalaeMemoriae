<%@ Page Title="QuMalMem" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="QuMalMem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>QuMalMem <small> - Quia malae memoriae</small></h1>
        <small>"Because bad memory"</small>
            <p>
                <!--<a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>-->
            </p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Simple Code Caller</h2>
            <asp:ListBox ID="ListBoxSCC" runat="server" AutoPostBack="True">
                <asp:ListItem Text="LINQ to XML 'DB' StoryTeller All" Value="StoryTellerA"/>
                <asp:ListItem Text="LINQ to XML 'DB' StoryTeller 3 options" Value="StoryTellerB"/>
                <asp:ListItem Text="LINQ to XML 'DB' StoryTeller of type" Value="StoryTellerC"/>
                <asp:ListItem Text="BasicTypes"                   Value="BasicTypes"/>
                <asp:ListItem Text="CountryCodes (Customized)"    Value="CountryCodes"/>
                <asp:ListItem Text="AbstractShapes"               Value="AbstractShapes"/>
                <asp:ListItem Text="BirdInheritance"              Value="BirdInheritance"/>
                <asp:ListItem Text="Excercise1"                   Value="Excercise1"/>
                <asp:ListItem Text="MyFirstObject"                Value="MyFirstObject"/>
            </asp:ListBox>
            <h2>Todo:</h2>
            <ul>
                <li>try setting up smoothstateJS for smooth page transitions</li>
                <li>lable inputs in various excercises better</li>
                <li>StoryTeller XML CRUD</li>
            </ul>
        </div>
        <div class="col-md-8">
            <h2>SCC Results Display</h2>
            <asp:ListBox ID="ListBoxResults" runat="server" OnSelectedIndexChanged="ListBoxResults_SelectedIndexChanged"></asp:ListBox>
        </div>
    </div>

</asp:Content>
