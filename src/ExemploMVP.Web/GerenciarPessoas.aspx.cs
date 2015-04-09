using ExemploMVP.Presenter;
using ExemploMVP.Presenter.InterfacesView;
using ExemploMVP.Presenter.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExemploMVP.Web
{
    /// <summary>
    /// Esta é uma View em formato WEB para implementação do nosso padrão.
    /// Esta View implementa um contrato IGerenciarPessoaView e este deve ser resolvido(implementado)
    /// </summary>
    public partial class GerenciarPessoas : System.Web.UI.Page, IGerenciarPessoaView
    {

        #region Constantes

        private const string COMANDO_EDITAR = "Editar";
        private const string COMANDO_EXCLUIR = "Excluir";

        #endregion

        #region Atributos

        private GerenciarPessoaPresenter _presenter;

        #endregion

        #region Construtores

        public GerenciarPessoas()
            : base()
        {
            _presenter = new GerenciarPessoaPresenter(this);
        }

        #endregion

        #region Propriedades e Resolvendo o Contrato

        public int Codigo
        {
            get
            {
                if (string.IsNullOrWhiteSpace(lblId.Text))
                    return 0;

                return Convert.ToInt32(lblId.Text);
            }
            set
            {
                lblId.Text = value.ToString();
            }
        }

        public string Nome
        {
            get
            {
                return txtNome.Text;
            }
            set
            {
                txtNome.Text = value;
            }
        }

        public DateTime DataAniversario
        {
            get
            {
                if (string.IsNullOrWhiteSpace(txtDtNascimento.Text))
                    return DateTime.MinValue;

                return Convert.ToDateTime(txtDtNascimento.Text);
            }
            set
            {
                if (value == DateTime.MinValue)
                    txtDtNascimento.Text = string.Empty;
                else
                    txtDtNascimento.Text = value.ToString("dd/MM/yyyy");
            }
        }

        public List<PessoaViewModel> ListaDePessoas
        {
            set
            {
                gvPessoas.DataSource = value;
                gvPessoas.DataBind();
            }
        }

        #endregion

        #region Eventos

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                this.EnviarMensagemRetorno(this._presenter.SalvarPessoa());
            }
            catch (Exception ex)
            {
                this.EnviarMensagemRetorno(ex.Message);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this._presenter.Limpar();
        }

        protected void gvPessoas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            try
            {
                if (e.CommandName == COMANDO_EDITAR)
                    this._presenter.ObterPessoa(id);
                else if (e.CommandName == COMANDO_EXCLUIR)
                {
                    string retorno = this._presenter.DeletarPessoa(id);

                    this.EnviarMensagemRetorno(retorno);
                }
            }
            catch (Exception ex)
            {
                this.EnviarMensagemRetorno(ex.Message);
            }
        }

        #endregion

        #region Metodos

        private void EnviarMensagemRetorno(string retorno)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "mensagemRetorno", string.Format("<script>alert('{0}');</script>", retorno));
        }

        #endregion

    }
}