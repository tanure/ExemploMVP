using ExemploMVP.Model;
using ExemploMVP.Presenter.InterfacesView;
using ExemploMVP.Presenter.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploMVP.Presenter
{
    /// <summary>
    /// Classe Presenter, responsável por ser o controlador.
    /// Tem como objetivo controlar a exibição das informações para o gerenciamento de pessoas e para obtenção dos
    /// dados de uma View para as demais camadas do projeto.
    /// 
    /// Esta classe é a mediadora entre o que acontece em uma View e o Model, tratando e delegando demais funcionalidades.
    /// Representa o "P" no padrão MVP
    /// </summary>
    public class GerenciarPessoaPresenter
    {
        #region Atributos

        /// <summary>
        /// Este atributo estático é utilizado apenas para fins didáticos neste projeto.
        /// Sua utilização em projetos reais é totalmente desencorajada.
        /// 
        /// Para facilitar a explicação do padrão MVP neste projeto, este atributo estático foi criado 
        /// para simular uma base de dados.
        /// Em aplicações reais, seria necessário a utilização de um padrão "Repository", por exemplo,
        /// para abstração da camada de dados ou até mesmo de outros padrões, como Service.
        /// </summary>
        private static List<Pessoa> _pessoasDb = new List<Pessoa>();

        /// <summary>
        /// Instância de uma View que representa a inclusão de pessoa
        /// </summary>
        private readonly IGerenciarPessoaView _view;

        #endregion

        #region Contrutores

        /// <summary>
        /// Construtor padrão da classe presenter
        /// </summary>
        /// <param name="view">Dependência da interface que representa a view</param>
        public GerenciarPessoaPresenter(IGerenciarPessoaView view)
        {
            this._view = view;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Carrega as informações iniciais da tela
        /// </summary>
        public void Carregar()
        {
            this.Limpar();
        }

        /// <summary>
        /// Cria uma nova pessoa na base de dados
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception">
        /// Retorna uma exceção caso exista algum campo obrigatório não preenchido
        /// </exception>
        private string CriarNovaPessoa()
        {
            // Validando campos obrigatórios
            if (!EstaValido())
                throw new Exception("Algumas informações são obrigatórias!");

            Pessoa novaPessoa = new Pessoa(this._view.Nome, this._view.DataAniversario);

            _pessoasDb.Add(novaPessoa); // Simula o envio de uma pessoa para a base de dados

            Limpar();

            return string.Format("Pessoa Cadastrada: {0}", novaPessoa);

        }

        /// <summary>
        /// Altera um objeto de pessoa na base de dados
        /// </summary>
        /// <param name="id">Código da pessoa a ser alterada</param>
        /// <returns></returns>
        private string AtualizarPessoa(int id)
        {
            // Validando campos obrigatórios
            if (!EstaValido())
                throw new Exception("Algumas informações são obrigatórias!");

            Pessoa pessoaAAlterar = _pessoasDb.FirstOrDefault(p => p.Codigo == id);

            if (pessoaAAlterar == null)
                throw new Exception("A pessoa solicitada para alteração não foi encontrada na base de dados!");

            pessoaAAlterar.Nome = this._view.Nome;
            pessoaAAlterar.DataAniversario = this._view.DataAniversario;

            // Em caso de aplicações reais, seria necessário uma chamada a um serviço para salvar a entidade alterada
            // em uma base de dados. Neste exemplo existe apenas a aletaração de uma referência de um objeto em nossa
            // variável estática _pessoasDb, por isso não há nenhuma chamada para algum método "Alterar" neste ponto

            Limpar();

            return string.Format("Pessoa Alterada com sucesso: {0}", pessoaAAlterar);
        }

        /// <summary>
        /// Este método tem como objetivo identificar o valor disponível no campo código na View para decidir 
        /// se deve haver a criação ou alteração de uma pessoa.
        /// 
        /// Se o código é igual a 0 significa que é uma inclusão, caso contrário, uma alteração
        /// </summary>
        /// <returns></returns>
        public string SalvarPessoa()
        {
            if (this._view.Codigo > 0)
                return AtualizarPessoa(this._view.Codigo);

            return CriarNovaPessoa();
        }

        /// <summary>
        /// Exclui uma pessoa da base de dados
        /// </summary>
        /// <param name="id">Código da pessoa que deseja excluir da base de dados</param>
        /// <returns></returns>
        public string DeletarPessoa(int id)
        {
            if (id <= 0)
                throw new Exception("Código da pessoa inválido!");

            Pessoa pessoaAExcluir = _pessoasDb.FirstOrDefault(p => p.Codigo == id);

            if (pessoaAExcluir == null)
                throw new Exception("A pessoa desejada para exclusão não foi encontrada na base de dados!");

            _pessoasDb.Remove(pessoaAExcluir);

            ObterTodasPessoas();

            return string.Format("A pessoa {0} foi excluída da base de dados com sucesso!", pessoaAExcluir);
        }

        /// <summary>
        /// Obtém todas as pessoas da base de dados
        /// </summary>        
        public void ObterTodasPessoas()
        {
            List<PessoaViewModel> pessoasViewModel = _pessoasDb.Select(p => new PessoaViewModel(p.Codigo, p.Nome, p.DataAniversario)).ToList();

            this._view.ListaDePessoas = pessoasViewModel;
        }

        /// <summary>
        /// Recupera uma pessoa para edição e seta os atributos da View com o valor da pessoa a ser recuperada
        /// </summary>
        /// <param name="id">Id da Pessoa que será obtida para edição</param>
        public void ObterPessoa(int id)
        {
            if (id <= 0)
                throw new Exception("Código da pessoa inválido!");

            Pessoa pessoaAEditar = _pessoasDb.FirstOrDefault(p => p.Codigo == id);

            if (pessoaAEditar == null)
                throw new Exception("A pessoa desejada para edição não foi encontrada na base de dados!");

            this._view.Codigo = pessoaAEditar.Codigo;
            this._view.DataAniversario = pessoaAEditar.DataAniversario;
            this._view.Nome = pessoaAEditar.Nome;

            ObterTodasPessoas();
        }

        /// <summary>
        /// Inicializa os atributos da View
        /// </summary>
        public void NovaPessoa()
        {
            this._view.Codigo = 0;
            this._view.Nome = string.Empty;
            this._view.DataAniversario = DateTime.MinValue;
        }

        /// <summary>
        /// Controla os atributos da View de forma inicializar os seus valores padrão
        /// </summary>
        public void Limpar()
        {
            NovaPessoa();

            ObterTodasPessoas();
        }

        /// <summary>
        /// Efetua uma validação nas informações da View de Pessoa
        /// </summary>
        /// <returns>Retorna false se algum elemento obrigatório não foi informado</returns>    
        private bool EstaValido()
        {
            return !string.IsNullOrWhiteSpace(this._view.Nome)
                && this._view.DataAniversario != DateTime.MinValue;
        }

        #endregion
    }
}
