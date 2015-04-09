using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploMVP.Presenter.ViewModel
{
    /// <summary>
    /// Entidade de ViewModel para abstrair o Modelo de Domínio concreto e enviar para uma View somente os dados
    /// necessários para exibição de informações do modelo Pessoa.
    /// 
    /// A View Model é imutável
    /// </summary>
    public class PessoaViewModel
    {
         public int Codigo { get; private set; }

        public string Nome { get; private set; }

        public DateTime DataAniversario { get; private set; }        

        #region Construtores

        public PessoaViewModel(int id, string name, DateTime dateOfBirth)
        {
            this.Codigo = id;
            this.Nome = name;
            this.DataAniversario = dateOfBirth;
        }

        #endregion
        
        public override string ToString()
        {
            return string.Format("{0} - {1} - {2:dd/MM/yyyy}", this.Codigo, this.Nome, this.DataAniversario); 
        }
    }
}
