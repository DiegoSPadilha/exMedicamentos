using exMedicamentos.Compartilhado;
using exMedicamentos.ModuloFornecedor;
using exMedicamentos.ModuloRequisicao;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exMedicamentos.ModuloMedicamento
{
    public class Medicamento : Entidade
    {
        static private int id = 0;

        public string Nome { get; set; }

        public string Descricao { get; set; }
        public int Quantidade { get; set; }

        public ArrayList Requisicoes { get; set; }
        public int Limite { get; set; }
        public Fornecedor MedicamentoFornecedor { get; set; }

        public int Retiradas
        {
            get
            {
                int soma = 0;
                foreach (Requisicao requisicao in Requisicoes)
                {
                    soma += requisicao.QuantidadeMedicamento;
                }
                return soma;
            }
        }

        public Medicamento()
        {
            ObterId(ref id);
        }

        public override string[] ObterAtributos()
        {
            string[] atributos = {(Id + ""), Nome, Descricao, (Quantidade + ""),(Retiradas + ""),
       (Limite + ""), MedicamentoFornecedor.Nome};
            return atributos;
        }

        public override void Atualizar(Entidade entidade)
        {
            Medicamento medicamento = (Medicamento)entidade;
            Nome = medicamento.Nome;
            Descricao = medicamento.Descricao;
            Limite = medicamento.Limite;
            MedicamentoFornecedor = medicamento.MedicamentoFornecedor;
        }

        public override Entidade ObterClasse()
        {
            return new Medicamento();
        }
    }
}
