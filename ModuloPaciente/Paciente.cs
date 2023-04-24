using exMedicamentos.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exMedicamentos.ModuloPaciente
{
    public class Paciente : Entidade
    {
        static private int id = 0;

        public string Nome { get; set; }
        public string Cpf { get; set; }


        public string Cartao { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        public Paciente()
        {
            ObterId(ref id);
        }

        public override string[] ObterAtributos()
        {
            string[] atributos = { (Id + ""), Nome, Cpf, Cartao, Telefone, Endereco };
            return atributos;
        }

        public override void Atualizar(Entidade entidade)
        {
            Paciente paciente = (Paciente)entidade;
            Nome = paciente.Nome;
            Cpf = paciente.Cpf;
            Cartao = paciente.Cartao;
            Telefone = paciente.Telefone;
            Endereco = paciente.Endereco;
        }

        public override Entidade ObterClasse()
        {
            return new Paciente();
        }
    }
}
