<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ExemploMVP.Web._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>Exemplo de utilização do padrão MVP</h1>
            </hgroup>
            <p>
                Esta aplicação tem como objetivo demonstrar a utilização do padrão MVP. tAlgumas técnicas utilizadas tem caráter ilustrativo de forma a facilitar o aprendizado e explicação do padrão.</p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Dúvidas, Críticas ou sugestões:</h3>
    <ol class="round">
        <li class="one">
            <h5>Contatos</h5>
            Albert Sena Tanure<br />
            tanure@live.com
        </li>       
    </ol>

    <img src="Images/DiagramaClasse.png" />
</asp:Content>
