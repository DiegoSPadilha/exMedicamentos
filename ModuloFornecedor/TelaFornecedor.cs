using exMedicamentos.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exMedicamentos.ModuloFornecedor
{
    public class TelaFornecedor : Tela
    {
        public TelaFornecedor(Repositorio repositorio) : base(repositorio)
        {
            titulo = "Fornecedores:";
            string[] cabecalho = { "Id:", "Nome:", "CNPJ:", "Telefone:", "Email", "Endereço:" };
            Cabecalho = cabecalho;
        }

        public void Opcoes()
        {
            string[] opcoes =
            {
            "Tela Fornecedor",
            "0-Sair",
            "1-Registrar Fornecedor",
            "2-Mostrar Fornecedores",
            "3-Atualizar Fornecedor",
            "4-Remover Fornecedor"
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
                        Console.WriteLine("Fornecedor registrado!");
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
                            Console.WriteLine("Fornecedor atualizado!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Não existe fornecedores registrados no sistema!");
                            Console.ReadLine();
                        }
                        break;
                    case "4":
                        if (repositorio.Lista.Count > 0)
                        {
                            RemoverEntidade();
                            Console.WriteLine("Fornecedor removido!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Não existe fornecedores registrados no sistema!");
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
            Fornecedor fornecedor = new Fornecedor();
            PreencherAtributos(fornecedor);
            return fornecedor;
        }

        public override void PreencherAtributos(Entidade entidade)
        {
            Fornecedor fornecedor = (Fornecedor)entidade;
            Console.Write("Digite o nome do fornecedor: ");
            string nome = Console.ReadLine();
            fornecedor.Nome = nome;
            Console.Write("Digite o CNPJ do fornecedor: ");
            string cnpj = Console.ReadLine();
            fornecedor.Cnpj = cnpj;
            Console.Write("Digite o telefone do fornecedor: ");
            string telefone = Console.ReadLine();
            fornecedor.Telefone = telefone;
            Console.Write("Digite o email do fornecedor: ");
            string email = Console.ReadLine();
            fornecedor.Email = email;
            Console.Write("Digite o endereço do fornecedor: ");
            string endereco = Console.ReadLine();
            fornecedor.Endereco = endereco;
        }
    }
}
