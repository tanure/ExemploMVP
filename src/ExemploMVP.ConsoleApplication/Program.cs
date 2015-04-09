using ExemploMVP.Presenter;
using ExemploMVP.Presenter.InterfacesView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploMVP.ConsoleApplication
{
    class Program
    {

        private static int _opcaoMenu;

        static void Main(string[] args)
        {
            _opcaoMenu = 0;

            GerenciarPessoaView viewPessoa = new GerenciarPessoaView();

            while (_opcaoMenu != 5)
            {
                ExibirMenu();

                switch(_opcaoMenu)
                {
                    case 1: // Listar Pessoas
                        LimparTela();
                        viewPessoa.ListarPessoas();
                        break;
                    case 2: // Criar nova pessoa
                        LimparTela();
                        viewPessoa.CadastrarPessoa();
                        break;
                    case 3: // Alterar Pessoa
                        LimparTela();
                        viewPessoa.AlterarPessoa();
                        break;
                    case 4: // Deletar Pessoa
                        LimparTela();
                        viewPessoa.DeletarPessoa();
                        break;
                }
            }
        }

        /// <summary>
        /// Exibe um cabeçalho para a aplicação
        /// </summary>
        public static void ExibirCabecalho()
        {
            string cabecalho = @"
                      ===========================================
                                   GERENCIAR PESSOAS                           
                      ===========================================";

            Console.Write(cabecalho);
        }

        /// <summary>
        /// Exibe o menu da aplicação
        /// </summary>
        public static void ExibirMenu()
        {
            LimparTela();

            string menu = @"
                            ================================
                            |           MENU               |
                            ================================

                            1. Listar Pessoas
                            2. Criar Nova Pessoa
                            3. Alterar Pessoa
                            4. Excluir Pessoa
                            5. Sair";

            Console.WriteLine(menu);
            Console.Write("Op: ");

            string valorRetorno = Console.ReadLine();

            int.TryParse(valorRetorno, out _opcaoMenu);
        }

        /// <summary>
        /// Limpa toda a tela e exibe novamente o cabeçalho
        /// </summary>
        public static void LimparTela()
        {
            _opcaoMenu = 0;
            Console.Clear();
            ExibirCabecalho();
        }

    }
}
