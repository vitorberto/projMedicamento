using System;

namespace projMedicamento
{
    class Program
    {
        static void Main(string[] args)
        {
            int selection = 0;
            Medicamentos medicamentos = new Medicamentos();

            do
            {
                Console.WriteLine("Digite sua escolha: ");
                Console.WriteLine("0. Finalizar processo");
                Console.WriteLine("1. Cadastrar medicamento");
                Console.WriteLine("2. Consultar medicamento (sintético)");
                Console.WriteLine("3. Consultar medicamento (analítico)");
                Console.WriteLine("4. Comprar medicamento");
                Console.WriteLine("5. Vender medicamento");
                Console.WriteLine("6. Listar medicamento");

                selection = int.Parse(Console.ReadLine());
                
                if (selection == 1)
                {
                    string nome, laboratorio;
                    Console.Clear();
                    Console.Write("Digite o nome do medicamento: ");
                    nome = Console.ReadLine();

                    Console.Write("Digite o nome do laboratorio: ");
                    laboratorio = Console.ReadLine();

                    Medicamento medicamento = new Medicamento(medicamentos.QuantidadeMedicamentos() + 1, nome, laboratorio);
                    medicamentos.Adicionar(medicamento);

                    Console.Clear();
                    Console.WriteLine("Medicamento cadastrado com sucesso!");
                } else if (selection == 2)
                {
                    Console.Clear();
                    int id;
                    Console.Write("Digite o id do medicamento que deseja consultar: ");
                    id = int.Parse(Console.ReadLine());

                    Medicamento medicamento = medicamentos.Pesquisar(id);
                    Console.WriteLine("Resultado da pesquisa {0}", medicamento.toString());
                } else if (selection == 3)
                {
                    Console.Clear();
                    int id;
                    Console.Write("Digite o id do medicamento que deseja consultar: ");
                    id = int.Parse(Console.ReadLine());

                    Medicamento medicamento = medicamentos.Pesquisar(id);
                    Console.WriteLine("Medicamento encontrado: {0}", medicamento.toString());

                    Console.WriteLine("Lotes do medicamento encontrado: ");
                    foreach (Lote lote in medicamento.Lotes )
                    {
                        Console.WriteLine(lote.toString());
                    }
                } else if (selection == 4)
                {
                    Console.Clear();
                    int id;
                    Console.Write("Digite o id do medicamento que deseja comprar: ");
                    id = int.Parse(Console.ReadLine());

                    Medicamento medicamento = medicamentos.Pesquisar(id);
                    if (medicamento.Id != 0)
                    {
                        Console.Write("Digite a quantidade que deseja comprar do lote: ");
                        int qtde = int.Parse(Console.ReadLine());

                        Console.Write("Agora digite o ano de vencimento do lote: ");
                        int ano = int.Parse(Console.ReadLine());

                        Console.Write("Agora digite o mes de vencimento do lote: ");
                        int mes = int.Parse(Console.ReadLine());

                        Console.Write("Agora digite o dia de vencimento do lote: ");
                        int dia = int.Parse(Console.ReadLine());

                        DateTime venc = new DateTime(ano, mes, dia);

                        Lote lote = new Lote(id, qtde, venc);

                        medicamento.Comprar(lote);
                    } else
                    {
                        Console.Clear();
                        Console.WriteLine("Erro! Nenhum medicamento encontrado com id fornecido");
                    }  
                } else if (selection == 5) 
                {
                    Console.Clear();
                    int id;
                    Console.Write("Digite o id do medicamento que deseja comprar: ");
                    id = int.Parse(Console.ReadLine());

                    Medicamento medicamento = medicamentos.Pesquisar(id);
                    if (medicamento.Id != 0)
                    {
                        Console.Write("Digite a quantidade de medicamentos que deseja vender: ");
                        int qtde = int.Parse(Console.ReadLine());

                        if (medicamento.vender(qtde))
                        {
                            Console.Clear();
                            Console.WriteLine("Sucesso! medicamentos vendidos");
                        } else
                        {
                            Console.Clear();
                            Console.WriteLine("Erro! o número de medicamentos que você deseja vender excede a quantidade de medicamentos disponíveis");
                        }
                    } else
                    {
                        Console.Clear();
                        Console.WriteLine("Erro! Nenhum medicamento encontrado com id fornecido");
                    }
                } else if (selection == 6)
                {
                    medicamentos.Listar();
                }
            } while (selection != 0);
        }
    }
}
