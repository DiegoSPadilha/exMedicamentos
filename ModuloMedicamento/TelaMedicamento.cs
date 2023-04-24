using exMedicamentos.Compartilhado;
using exMedicamentos.ModuloFornecedor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exMedicamentos.ModuloMedicamento
{
    public class TelaMedicamento : Tela
    {
        private TelaFornecedor telaFornecedor;


        public TelaMedicamento(Repositorio repositorio, TelaFornecedor telaFornecedor) : base(repositorio)
        {
            titulo = "Medicamentos:";
            string[] cabecalho = {"Id:","Nome:","Descrição:","Quantidade:",
        "Retiradas:","Limite:","Fornecedor:"};
            Cabecalho = cabecalho;
            this.telaFornecedor = telaFornecedor;
        }

        public void Opcoes()
        {
            string[] opcoes =
            {
            "Tela Medicamento",
            "0-Sair",
            "1-Registrar Medicamento",
            "2-Mostrar Medicamentos",
            "3-Atualizar Medicamento",
            "4-Remover Medicamento",
            "5-Mostrar Medicamentos Requisitados",
            "6-Mostrar Medicamentos em Falta"
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
                        if (telaFornecedor.Quantidade > 0)
                        {
                            repositorio.InserirRegistro(RegistrarEntidade());
                            Console.WriteLine("Medicamento registrado!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Não existe fornecedores registrados no sistema!");
                            Console.ReadLine();
                        }
                        break;
                    case "2":
                        MostrarEntidades();
                        Console.ReadLine();
                        break;
                    case "3":
                        if (repositorio.Lista.Count > 0)
                        {
                            if (telaFornecedor.Quantidade > 0)
                            {
                                AtualizarEntidade();
                                Console.WriteLine("Medicamento atualizado!");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Não existe fornecedores registrados no sistema!");
                                Console.ReadLine();
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Não existe medicamentos registrados no sistema!");
                            Console.ReadLine();
                        }
                        break;
                    case "4":
                        if (repositorio.Lista.Count > 0)
                        {
                            RemoverEntidade();
                            Console.WriteLine("Medicamento removido!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Não existe medicamentos registrados no sistema!");
                            Console.ReadLine();
                        }
                        break;
                    case "5":
                        MostrarMedicamentosRequisitados();
                        Console.ReadLine();
                        break;
                    case "6":
                        MostrarMedicamentosEmFalta();
                        Console.ReadLine();
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
            Medicamento medicamento = new Medicamento();
            PreencherAtributos(medicamento);
            return medicamento;
        }

        public override void PreencherAtributos(Entidade entidade)
        {
            Medicamento medicamento = (Medicamento)entidade;
            Fornecedor fornecedor = (Fornecedor)telaFornecedor.ValidarId();
            medicamento.MedicamentoFornecedor = fornecedor;
            Console.Write("Digite o nome do medicamento: ");
            string nome = Console.ReadLine();
            medicamento.Nome = nome;
            Console.Write("Digite a descrição do medicamento: ");
            string descricao = Console.ReadLine();
            medicamento.Descricao = descricao;
            int limite = ValidarInt("Digite o número limite do medicamento: ");
            medicamento.Limite = limite;
            medicamento.Quantidade = 0;
            medicamento.Requisicoes = new ArrayList();
        }

        public ArrayList ObterMedicamentosDisponiveis()
        {
            ArrayList medicamentos = new ArrayList();
            foreach (Medicamento medicamento in repositorio.Lista)
            {
                if (medicamento.Quantidade > 0)
                {
                    medicamentos.Add(medicamento);
                }
            }
            return medicamentos;
        }

        public Entidade ValidarIdDisponivel()
        {
            Entidade entidade;
            while (true)
            {
                MostrarMedicamentosDisponiveis();
                int indice = ValidarInt("Digite o id: ");
                entidade = repositorio.EncontrarRegistro(indice, ObterMedicamentosDisponiveis());
                if (entidade == null)
                {
                    Console.WriteLine("O id escolhido não está disponível!");
                    Console.ReadLine();
                    continue;
                }
                return entidade;
            }
        }

        public void MostrarMedicamentosDisponiveis()
        {
            Console.Clear();
            Console.WriteLine(titulo);
            string cabecalho = "";
            foreach (string atributo in Cabecalho)
            {
                cabecalho += (atributo.PadRight(20) + "|");
            }
            Console.Write(cabecalho);
            Console.WriteLine();
            Console.WriteLine("".PadRight(cabecalho.Length, '-'));
            foreach (Medicamento medicamento in repositorio.Lista)
                if (medicamento.Quantidade > 0)
                {
                    {
                        foreach (string atributo in medicamento.ObterAtributos())
                        {
                            Console.Write(atributo.PadRight(20) + "|");
                        }
                        Console.WriteLine();
                    }
                }
        }
        public void MostrarMedicamentosEmFalta()
        {
            Console.Clear();
            Console.WriteLine(titulo);
            string cabecalho = "";
            foreach (string atributo in Cabecalho)
            {
                cabecalho += (atributo.PadRight(20) + "|");
            }
            Console.Write(cabecalho);
            Console.WriteLine();
            Console.WriteLine("".PadRight(cabecalho.Length, '-'));
            foreach (Medicamento medicamento in repositorio.Lista)
                if (medicamento.Limite > medicamento.Quantidade)
                {
                    {
                        foreach (string atributo in medicamento.ObterAtributos())
                        {
                            Console.Write(atributo.PadRight(20) + "|");
                        }
                        Console.WriteLine();
                    }
                }
        }

        public void MostrarMedicamentosRequisitados()
        {
            Console.Clear();
            Console.WriteLine(titulo);
            string cabecalho = "";
            foreach (string atributo in Cabecalho)
            {
                cabecalho += (atributo.PadRight(20) + "|");
            }
            Console.Write(cabecalho);
            Console.WriteLine();
            Console.WriteLine("".PadRight(cabecalho.Length, '-'));
            ArrayList ListaOrdenada = (ArrayList)repositorio.Lista.Clone();
            IComparer comparador = (IComparer)new ComparadorMedicamento();
            ListaOrdenada.Sort(comparador);
            foreach (Medicamento medicamento in ListaOrdenada)
                if (medicamento.Requisicoes.Count > 0)
                {
                    {
                        foreach (string atributo in medicamento.ObterAtributos())
                        {
                            Console.Write(atributo.PadRight(20) + "|");
                        }
                        Console.WriteLine();
                    }
                }
        }
    }

    public class ComparadorMedicamento : IComparer
    {
        public int Compare(object? a, object? b)
        {
            try
            {
                Medicamento x = (Medicamento)a;
                Medicamento y = (Medicamento)b;
                return y.Retiradas.CompareTo(x.Retiradas);
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return 0;
            }
        }
    }
}
