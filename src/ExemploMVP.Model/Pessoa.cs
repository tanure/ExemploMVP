using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploMVP.Model
{
    /// <summary>
    /// Classe que representa um model de pessoa
    /// 
    /// Esta classe não implementa nenhuma técnica avançada para um modelo de domínio ou utiliza DDD - Domain Drive Design
    /// Sua estrutura é utilizada como base da apresentação do modelo de desenvolvimento MVP de forma didática
    /// Representa o "M" no padrão MVP
    /// </summary>
    public class Pessoa
    {
        #region Propriedades

        public int Codigo { get; set; }

        public string Nome { get; set; }

        public DateTime DataAniversario { get; set; }

        #endregion

        #region Construtores

        public Pessoa()
        {
            this.Codigo = new Random().Next(1000) + 1;
        }

        public Pessoa(string name, DateTime dateOfBirth) : this()
        {
            this.Nome = name;
            this.DataAniversario = dateOfBirth;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Sobrescrita do método ToString para apresentação em um formato que descreve o objeto pessoa com seus 
        /// respectivos atributos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} - {1} - {2:dd/MM/yyyy}", this.Codigo, this.Nome, this.DataAniversario); 
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Pessoa)) return false;

            Pessoa pessoa = (Pessoa)obj;

            return this.Codigo.Equals(pessoa.Codigo);
        }

        public override int GetHashCode()
        {
            return this.Codigo.GetHashCode();
        }

        #endregion
    }
}
