using ExemploMVP.Presenter;
using ExemploMVP.Presenter.InterfacesView;
using ExemploMVP.Presenter.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploMVP.ConsoleApplication
{
    /// <summary>
    /// View em formato de Console Application
    /// 
    /// Implementa o contrato ou interface IGerenciarPessoaView
    /// </summary>
    public class GerenciarPessoaView : IGerenciarPessoaView
    {
        #region Constantes

        /// <summary>
        /// Padrão de Mensagem de erro
        /// </summary>
        private const string MSG_ERRO = "ERRO: {0}";

        #endregion

        #region Atributos

        private int _codigo;
        private string _name;
        private DateTime _dataAniversario;
        private List<PessoaViewModel> _listaPessoas;
        private GerenciarPessoaPresenter _presenter;

        #endregion
        
        #region Propriedades

        public int Codigo
        {
            get
            {
                return this._codigo;
            }
            set
            {
                this._codigo = value;
            }
        }

        public string Nome
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        public DateTime DataAniversario
        {
            get
            {
                return this._dataAniversario;
            }
            set
            {
                this._dataAniversario = value;
            }
        }

        public List<Presenter.ViewModel.PessoaViewModel> ListaDePessoas
        {
            set { this._listaPessoas = value; }
        }

        #endregion
        
        #region Construtores

        public GerenciarPessoaView()
        {
            _presenter = new GerenciarPessoaPresenter(this);
        }

        #endregion

        #region Metodos

        public void CadastrarPessoa()
        {
            string cabecalho = @"
                      ===========================================
                                      NOVA PESSOA                           
                      ===========================================";

            Console.WriteLine(cabecalho);

            Console.Write("Informe o Nome: ");
            this._name = Console.ReadLine(); 

            Console.Write("Informe a data de aniversário no formato dd/MM/yyyy: ");
            this._dataAniversario = Convert.ToDateTime(Console.ReadLine()); // Para evolução, antes da conversão, seria interessante validar o valor informado

            try
            {
                Console.WriteLine(this._presenter.SalvarPessoa());
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format(MSG_ERRO, ex.Message));
            }

            Console.ReadKey();
        }

        public void AlterarPessoa()
        {
            string cabecalho = @"
                      ===========================================
                                    EDIATAR PESSOA                           
                      ===========================================";

            Console.WriteLine(cabecalho);

            Console.Write("Informe o código da pessoa a ser editada: ");
            int codigoPessoaAAlterar = Convert.ToInt32(Console.ReadLine()); // Para evolução, antes da conversão, seria interessante validar o valor informado

            try
            {
                _presenter.ObterPessoa(codigoPessoaAAlterar);

                Console.WriteLine("Confirma a edição do seguinte registro(S/N)?\n {0} - {1} -{2:dd/MM/yyyy}", this.Codigo, this.Nome, this.DataAniversario);
                string opcao = Console.ReadLine();

                if (opcao.ToLower() == "s")
                {
                    Console.Write("Informe o novo Nome: ");
                    this._name = Console.ReadLine();

                    Console.Write("Informe a nova data de aniversário no formato dd/MM/yyyy: ");
                    this._dataAniversario = Convert.ToDateTime(Console.ReadLine()); // Para evolução, antes da conversão, seria interessante validar o valor informado

                    Console.WriteLine(this._presenter.SalvarPessoa());

                    Console.ReadKey();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(string.Format(MSG_ERRO, ex.Message));

                Console.ReadKey();
            }
        }

        public void DeletarPessoa()
        {
            string cabecalho = @"
                      ===========================================
                                    DELETAR PESSOA                           
                      ===========================================";

            Console.WriteLine(cabecalho);

            Console.Write("Informe o código da pessoa a ser excluída: ");
            int codigoPessoaAAlterar = Convert.ToInt32(Console.ReadLine()); // Para evolução, antes da conversão, seria interessante validar o valor informado

            try
            {
                _presenter.ObterPessoa(codigoPessoaAAlterar);

                Console.WriteLine("Confirma a exclusão do seguinte registro(S/N)?\n {0} - {1} -{2:dd/MM/yyyy}", this.Codigo, this.Nome, this.DataAniversario);
                string opcao = Console.ReadLine();

                if (opcao.ToLower() == "s")
                {   
                    Console.WriteLine(this._presenter.DeletarPessoa(this.Codigo));

                    Console.ReadKey();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(string.Format(MSG_ERRO, ex.Message));

                Console.ReadKey();
            }
        }

        public void ListarPessoas()
        {
            string cabecalho = @"
                      ===========================================
                                  PESSOAS CADASTRADAS                           
                      ===========================================";

            Console.WriteLine(cabecalho);

            this._presenter.ObterTodasPessoas();

            Console.WriteLine("------------------------------------------------------------");

            if (this._listaPessoas.Count > 0)
            {
                foreach (PessoaViewModel model in this._listaPessoas.OrderBy(x => x.Codigo))
                    Console.WriteLine(model);
            }
            else
                Console.WriteLine("Não existem pessoas cadastradas");

            Console.WriteLine("------------------------------------------------------------");

            Console.ReadKey();
        }

        #endregion


    }
}
