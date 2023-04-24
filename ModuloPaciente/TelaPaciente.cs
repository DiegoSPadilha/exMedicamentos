using exMedicamentos.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exMedicamentos.ModuloPaciente
{
    public class TelaPaciente : Tela
    {
        public TelaPaciente(Repositorio repositorio) : base(repositorio)
        {
            titulo = "Pacientes";
            string[] cabecalho = { "Id:", "Nome:", "CPF:", "Cartão do SUS:", "Telefone", "Endereço:" };
            Cabecalho = cabecalho;
        }

        public void Opcoes()
        {
            string[] opcoes =
            {
            "Tela Paciente",
            "0-Sair",
            "1-Registrar Paciente",
            "2-Mostrar Pacientes",
            "3-Atualizar Paciente",
            "4-Remover Paciente"
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
                        repositorio.InserirRegistro(RegistrarEntidade());
                        Console.WriteLine("Paciente registrado!");
                        Console.ReadLine();
                        break;
                    case "2":
                        MostrarEntidades();
                        Console.ReadLine();
                        break;
                    case "3":
                        if (repositorio.Lista.Count > 0)
                        {
                            AtualizarEntidade();
                            Console.WriteLine("Paciente atualizado!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Não existe pacientes registrados no sistema!");
                            Console.ReadLine();
                        }
                        break;
                    case "4":
                        if (repositorio.Lista.Count > 0)
                        {
                            RemoverEntidade();
                            Console.WriteLine("Paciente removido!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Não existe pacientes registrados no sistema!");
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
            Paciente paciente = new Paciente();
            PreencherAtributos(paciente);
            return paciente;
        }

        public override void PreencherAtributos(Entidade entidade)
        {
            Paciente paciente = (Paciente)entidade;
            Console.Write("Digite o nome do paciente: ");
            string nome = Console.ReadLine();
            paciente.Nome = nome;
            Console.Write("Digite o CPF do paciente: ");
            string cpf = Console.ReadLine();
            paciente.Cpf = cpf;
            Console.Write("Digite o cartão do SUS do paciente: ");
            string cartao = Console.ReadLine();
            paciente.Cartao = cartao;
            Console.Write("Digite o telefone do paciente: ");
            string telefone = Console.ReadLine();
            paciente.Telefone = telefone;
            Console.Write("Digite o endereço do paciente: ");
            string endereco = Console.ReadLine();
            paciente.Endereco = endereco;
        }
    }
}
