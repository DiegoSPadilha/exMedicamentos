using exMedicamentos.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exMedicamentos.ModuloFuncionario
{
    public class TelaFuncionario : Tela
    {
        public TelaFuncionario(Repositorio repositorio) : base(repositorio)
        {
            titulo = "Funcionários:";
            string[] cabecalho = { "Id:", "Nome:", "CPF:", "Telefone", "Endereço:" };
            Cabecalho = cabecalho;
        }

        public void Opcoes()
        {
            string[] opcoes =
            {
            "Tela Funcionário",
            "0-Sair",
            "1-Registrar Funcionário",
            "2-Mostrar Funcionários",
            "3-Atualizar Funcionário",
            "4-Remover Funcionário"
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
                        Console.WriteLine("Funcionário registrado!");
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
                            Console.WriteLine("Funcionário atualizado!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Não existe funcionários registrados no sistema!");
                            Console.ReadLine();
                        }
                        break;
                    case "4":
                        if (repositorio.Lista.Count > 0)
                        {
                            RemoverEntidade();
                            Console.WriteLine("Funcionário removido!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Não existe funcionários registrados no sistema!");
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
            Funcionario funcionario = new Funcionario();
            PreencherAtributos(funcionario);
            return funcionario;
        }

        public override void PreencherAtributos(Entidade entidade)
        {
            Funcionario funcionario = (Funcionario)entidade;
            Console.Write("Digite o nome do funcionário: ");
            string nome = Console.ReadLine();
            funcionario.Nome = nome;
            Console.Write("Digite o CPF do funcionário: ");
            string cpf = Console.ReadLine();
            funcionario.Cpf = cpf;
            Console.Write("Digite o telefone do funcionário: ");
            string telefone = Console.ReadLine();
            Console.Write("Digite o login do funcionário: ");
            string login = Console.ReadLine();
            funcionario.Login = login;
            Console.Write("Digite a senha do funcionário: ");
            string senha = Console.ReadLine();
            funcionario.Senha = senha;
            funcionario.Telefone = telefone;
            Console.Write("Digite o endereço do funcionário: ");
            string endereco = Console.ReadLine();
            funcionario.Endereco = endereco;
        }

        public Funcionario VerificarLogin()
        {

            Console.Write("Digite o usuário (login): ");
            string usuario = Console.ReadLine();
            Console.Write("Digite a senha: ");
            string senha = Console.ReadLine();
            foreach (Funcionario funcionario in repositorio.Lista)
                if (funcionario.Login == usuario && funcionario.Senha == senha)
                {
                    Console.WriteLine("Login Sucedido!");
                    Console.ReadLine();
                    return funcionario;
                }
            return null;

        }
    }
}
