using exMedicamentos.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exMedicamentos.ModuloFornecedor
{
    public class Fornecedor : Entidade
    {
        static private int id = 0;

        public string Nome { get; set; }

        public string Cnpj { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }
        public string Endereco { get; set; }

        public Fornecedor()
        {
            ObterId(ref id);
        }

        public override string[] ObterAtributos()
        {
            string[] atributos = { (Id + ""), Nome, Cnpj, Telefone, Email, Endereco };
            return atributos;
        }

        public override void Atualizar(Entidade entidade)
        {
            Fornecedor fornecedor = (Fornecedor)entidade;
            Nome = fornecedor.Nome;
            Cnpj = fornecedor.Cnpj;
            Telefone = fornecedor.Telefone;
            Email = fornecedor.Email;
            Endereco = fornecedor.Endereco;
        }

        public override Entidade ObterClasse()
        {
            return new Fornecedor();
        }
    }
}
