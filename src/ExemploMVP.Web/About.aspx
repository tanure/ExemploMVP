<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="ExemploMVP.Web.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Sobre a Aplicação</h2>
    </hgroup>

    <article>
        <p>
            Este projeto é um exemplo de aplicação para a demonstração do padrão MVP. 
        </p>
        <p>
            Muitas técnicas utilizadas em conjunto para a demonstração do padrão possuem codificações em formato didático. Tais codificações são sinalizadas em código através de comentários sugerindo a melhor aplicação da solução em questão.
        </p>
        <p>
            Mesmo em um formato didático, a essência de utilização do padrão MVP foi mantida. Desta forma, se o leitor desejar poderá aplicar todas as técnicas propostas pelo padrão em projetos reais.
        </p>

    </article>

    <aside>
        <h3>Contatos</h3>
        <ol class="round">
            <li class="one">
                <h5>Contatos</h5>
                Albert Sena Tanure<br />
                tanure@live.com
            </li>
        </ol>
    </aside>
</asp:Content>
