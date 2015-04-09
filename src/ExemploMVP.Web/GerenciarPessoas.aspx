<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GerenciarPessoas.aspx.cs" Inherits="ExemploMVP.Web.GerenciarPessoas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <p class="validation-summary-errors">
        <asp:ValidationSummary ID="smCadastroPessoa" runat="server" />
    <fieldset>
      Dados da Pessoa</legend>
        <ol>
            <li>
                <asp:Label runat="server" AssociatedControlID="lblId">Id:</asp:Label>

                <asp:Label ID="lblId" runat="server" />
            </li>
            <li>
                <asp:Label runat="server" AssociatedControlID="txtNome">Nome:</asp:Label>
                <asp:TextBox ID="txtNome" runat="server" />
                <asp:RequiredFieldValidator ID="rfvNome" runat="server" CssClass="field-validation-error" ControlToValidate="txtNome" Text="*" ErrorMessage="Por favor informe um valor para o campo Nome" />

            </li>
            <li>
                <asp:Label runat="server" AssociatedControlID="txtDtNascimento">Data de nascimento:</asp:Label>
                <asp:TextBox ID="txtDtNascimento" runat="server" />
                <asp:RequiredFieldValidator ID="rfvDataNascimento" runat="server" CssClass="field-validation-error" ControlToValidate="txtDtNascimento" Text="*" ErrorMessage="Por favor informe um valor para o campo Data de Nascimento" />
                <asp:CompareValidator ID="cvDtNascimento" runat="server" ControlToValidate="txtDtNascimento" Type="Date" Operator="DataTypeCheck" CssClass="field-validation-error" Text="*" ErrorMessage="Por favor, informe uma data válida no formato dd/MM/yyyy no campo Data de nascimento"></asp:CompareValidator>
            </li>
        </ol>
        <asp:Button runat="server" ID="btnSalvar" Text="Salvar" OnClick="btnSalvar_Click" />
        <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" CausesValidation="false" OnClick="btnCancelar_Click" />
    </fieldset>

    <section>
        <header>
            <h3>Pessoas cadastradas:</h3>
        </header>
        <asp:GridView ID="gvPessoas" runat="server" Width="100%" AutoGenerateColumns="false" OnRowCommand="gvPessoas_RowCommand">
            <Columns>
                <asp:BoundField DataField="Codigo" HeaderText="Código" />
                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                <asp:BoundField DataField="DataAniversario" HeaderText="Nascimento" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEditar" runat="server" CausesValidation="false" CommandName="Editar" CommandArgument='<%# Bind("Codigo") %>' Text="Editar" />
                        <asp:LinkButton ID="lnkExcluir" runat="server" CommandName="Excluir" CausesValidation="false" CommandArgument='<%# Bind("Codigo") %>' Text="Excluir" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button runat="server" ID="btnNovaPessoa" Text="Nova Pessoa" />
    </section>
</asp:Content>
