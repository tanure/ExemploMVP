using ExemploMVP.Presenter.ViewModel;
using System;
using System.Collections.Generic;

namespace ExemploMVP.Presenter.InterfacesView
{
    /// <summary>
    /// Interface que representa uma View para o gerenciamento de um modelo de pessoas.
    /// 
    /// Esta interface não visa a utilização de um front-end especíifico, mas define um contrato onde
    /// a implementação correspondente da View, seja Mobile, Web ou qualquer outro tipo de tecnologia utilizada
    /// para interação com usuário deverá seguir.
    /// Este contrato descreve todos os dados necessários em uma View de Gerenciamento para tarefas simples como um CURD
    /// 
    /// Representa o "V" no padrão MVP
    /// </summary>
    public interface IGerenciarPessoaView
    {
        /// <summary>
        /// Código que representa uma pessoa
        /// </summary>
        int Codigo { get; set; }

        /// <summary>
        /// Nome da Pessoa
        /// </summary>
        string Nome { get; set; }

        /// <summary>
        /// Data de Nascimento da pessoa
        /// </summary>
        DateTime DataAniversario { get; set; }

        /// <summary> 
        /// Lista de pessoas
        /// </summary>
        List<PessoaViewModel> ListaDePessoas { set; }
    }
}
