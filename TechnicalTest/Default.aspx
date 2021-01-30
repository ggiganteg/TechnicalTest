<%@ Page Title="Technical Test" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="TechnicalTest.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >

    <div style="background-color:black">
        <h1 style="color:burlywood">Torre.co</h1>
        <h2 style="color:aqua">Technical Test</h2>
        <p style="color:aqua"> - Implemented by MVC Model</p>
        <p style="color:aqua"> - Implemented by Entity Framework</p>

    </div>

    <div class="row" style="background-color:black">
        <div class="col-md-4" style="background-color:black">
            <h2 style="color:burlywood">Candidate</h2>
            <p style="color:aqua">
                Gonzalo Gigante.
            </p>
            <p>
                <a class="btn alert-warning" href="Candidates/Details">Genome &raquo;</a>
            </p>
        </div>
       </div>

</asp:Content>
