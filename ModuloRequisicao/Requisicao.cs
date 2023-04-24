using exMedicamentos.Compartilhado;
using exMedicamentos.ModuloFuncionario;
using exMedicamentos.ModuloMedicamento;
using exMedicamentos.ModuloPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exMedicamentos.ModuloRequisicao
{
    public class Requisicao : Entidade
    {
        static private int id = 0;

        public Paciente RequisicaoPaciente { get; set; }
        public Medicamento RequisicaoMedicamento { get; set; }
        public Funcionario RequisicaoFuncionario { get; set; }

        public DateTime Data { get; set; }
        public int QuantidadeMedicamento { get; set; }

        public Requisicao()
        {
            ObterId(ref id);
        }

        public override string[] ObterAtributos()
        {
            string[] atributos = {(Id + ""), RequisicaoPaciente.Nome, RequisicaoMedicamento.Nome, RequisicaoFuncionario.Nome,
        Data.ToString("dd/MM/yyyy"), (QuantidadeMedicamento + "")};
            return atributos;
        }

        public override void Atualizar(Entidade entidade)
        {
            Requisicao requisicao = (Requisicao)entidade;
            RequisicaoPaciente = requisicao.RequisicaoPaciente;
            RequisicaoFuncionario = requisicao.RequisicaoFuncionario;
        }

        public override Entidade ObterClasse()
        {
            return new Requisicao();
        }
    }
}
