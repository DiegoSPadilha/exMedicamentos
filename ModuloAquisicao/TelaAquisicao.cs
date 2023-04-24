using exMedicamentos.Compartilhado;
using exMedicamentos.ModuloFornecedor;
using exMedicamentos.ModuloFuncionario;
using exMedicamentos.ModuloMedicamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exMedicamentos.ModuloAquisicao
{
    public class TelaAquisicao : Tela
    {
        private TelaFornecedor telaFornecedor;
        private TelaFuncionario telaFuncionario;

        private TelaMedicamento telaMedicamento;

        public TelaAquisicao(Repositorio repositorio, TelaFornecedor telaFornecedor, TelaFuncionario telaFuncionario, TelaMedicamento telaMedicamento) : base(repositorio)
        {
            titulo = "Aquisições:";
            string[] cabecalho = {"Id:","Fornecedor:","Medicamento:","Funcionário:",
        "Data:","Medicamentos:"};
            Cabecalho = cabecalho;
            this.telaFornecedor = telaFornecedor;
            this.telaFuncionario = telaFuncionario;
            this.telaMedicamento = telaMedicamento;
        }

        public void Opcoes()
        {
            string[] opcoes =
            {
            "Tela Aquisição",
            "0-Sair",
            "1-Registrar Aquisição",
            "2-Mostrar Aquisições",
            "3-Remover Aquisição"
        };
            while (true)
            {
                MostrarMenu(opcoes);
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "0":
                        return;
                    case "1":
                        if (telaFornecedor.Quantidade == 0)
                        {
                            Console.WriteLine("Não existe fornecedores registrados no sistema!");
                            Console.ReadLine();
                            break;
                        }
                        if (telaMedicamento.Quantidade == 0)
                        {
                            Console.WriteLine("Não existe medicamentos registrados no sistema!");
                            Console.ReadLine();
                            break;
                        }
                        if (telaFuncionario.Quantidade == 0)
                        {
                            Console.WriteLine("Não existe funcionários registrados no sistema!");
                            Console.ReadLine();
                            break;
                        }
                        repositorio.InserirRegistro(RegistrarEntidade());
                        Console.WriteLine("Aquisição registrada!");
                        Console.ReadLine();
                        break;
                    case "2":
                        MostrarEntidades();
                        Console.ReadLine();
                        break;
                    case "3":
                        if (repositorio.Lista.Count > 0)
                        {
                            RemoverEntidade();
                            Console.WriteLine("Aquisição removida!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Não existe aquisições registradas no sistema!");
                            Console.ReadLine();
                        }
                        break;
                    default:
                        Console.WriteLine("Opção não encontrada!");
                        Console.ReadLine();
                        break;
                }
            }
        }

        public override Entidade RegistrarEntidade()
        {
            Aquisicao aquisicao = new Aquisicao();
            PreencherAtributos(aquisicao);
            return aquisicao;
        }

        public override void PreencherAtributos(Entidade entidade)
        {
            Aquisicao aquisicao = (Aquisicao)entidade;
            Medicamento medicamento = (Medicamento)telaMedicamento.ValidarId();
            aquisicao.AquisicaoMedicamento = medicamento;
            aquisicao.AquisicaoFornecedor = medicamento.MedicamentoFornecedor;
            Funcionario funcionario = funcionarioLogado;
            aquisicao.AquisicaoFuncionario = funcionario;
            int quantidade = ValidarInt("Digite o número de medicamentos: ");
            aquisicao.QuantidadeMedicamento = quantidade;
            medicamento.Quantidade += quantidade;
            string data = DateTime.Now.ToString("dd/MM/yyyy");
            aquisicao.Data = DateTime.ParseExact(data, "dd/MM/yyyy", null);
        }

    }
}
