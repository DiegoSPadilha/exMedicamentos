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
    public class TelaRequisicao : Tela
    {
        private TelaPaciente telaPaciente;
        private TelaFuncionario telaFuncionario;

        private TelaMedicamento telaMedicamento;

        public TelaRequisicao(Repositorio repositorio, TelaPaciente telaPaciente, TelaFuncionario telaFuncionario, TelaMedicamento telaMedicamento) : base(repositorio)
        {
            titulo = "Requisições:";
            string[] cabecalho = {"Id:","Paciente:","Medicamento:","Funcionário:",
        "Data:","Medicamentos:"};
            Cabecalho = cabecalho;
            this.telaPaciente = telaPaciente;
            this.telaFuncionario = telaFuncionario;
            this.telaMedicamento = telaMedicamento;
        }

        public void Opcoes()
        {
            string[] opcoes =
            {
            "Tela Requisição",
            "0-Sair",
            "1-Registrar Requisição",
            "2-Mostrar Requisições",
            "3-Remover Requisição"
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
                        if (telaPaciente.Quantidade == 0)
                        {
                            Console.WriteLine("Não existe fornecedores registrados no sistema!");
                            Console.ReadLine();
                            break;
                        }
                        if (telaMedicamento.ObterMedicamentosDisponiveis().Count == 0)
                        {
                            Console.WriteLine("Não existe medicamentos disponíveis no sistema!");
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
                        Console.WriteLine("Requisição registrada!");
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
                            Console.WriteLine("Requisição removida!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Não existe requisições registradas no sistema!");
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
            Requisicao requisicao = new Requisicao();
            PreencherAtributos(requisicao);
            return requisicao;
        }

        public override void PreencherAtributos(Entidade entidade)
        {
            Requisicao requisicao = (Requisicao)entidade;
            Paciente paciente = (Paciente)telaPaciente.ValidarId();
            requisicao.RequisicaoPaciente = paciente;
            Medicamento medicamento = (Medicamento)telaMedicamento.ValidarIdDisponivel();
            requisicao.RequisicaoMedicamento = medicamento;
            requisicao.RequisicaoFuncionario = funcionarioLogado;
            int quantidade = ValidarQuantidade("Digite o número de medicamentos: ", medicamento.Quantidade);
            requisicao.QuantidadeMedicamento = quantidade;
            medicamento.Quantidade -= quantidade;
            if (!medicamento.Requisicoes.Contains(requisicao))
            {
                medicamento.Requisicoes.Add(requisicao);
            }
            string data = DateTime.Now.ToString("dd/MM/yyyy");
            requisicao.Data = DateTime.ParseExact(data, "dd/MM/yyyy", null);
        }

        private int ValidarQuantidade(string mensagem, int quantidade)
        {
            while (true)
            {
                int numero = ValidarInt(mensagem);
                if (numero <= quantidade)
                {
                    return numero;
                }
                Console.WriteLine("Digite uma quantidade menor de medicamentos!");
                Console.ReadLine();
            }
        }
    }
}
