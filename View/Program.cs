using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.DAL;
using TodoList.Model;

namespace TodoList.View
{
    class Program
    {
        static void Main(string[] args)
        {
            Tarefa tarefa = new Tarefa();
            string option = "";
            while(!option.Equals("0"))
            {
                Console.Clear();
                Console.WriteLine("Digite a opção desejada");
                Console.WriteLine("\n-------------------------------------------------------------------------------------------------------------\n");
                Console.WriteLine("| 1 - Adicionar tarefa | 2 - Finalizar tarefa | 3- Reabrir tarefa | 4 - Visualizar tarefas pendentes | 5- Excluir tarefa |0 - Sair ");
                Console.WriteLine("\n-------------------------------------------------------------------------------------------------------------\n");


                //listar todas as tarefas

                foreach (Tarefa tarefaIn in TarefaDAO.ListarTarefas())
                 {
                    Console.WriteLine(tarefaIn);
                 }

                //início das opções
                option = Console.ReadLine();
                switch(option)
                {
                    case "1":
                        Console.Clear();
                        tarefa = new Tarefa();
                        Console.WriteLine("Digite o nome da tarefa:");
                        tarefa.Nome = Console.ReadLine().ToUpper();
                        Console.WriteLine("Digite a data de início:");

                        //valida a data
                        try
                        {
                        
                            tarefa.DataIncio = DateTime.Parse(Console.ReadLine());
                            if (TarefaDAO.AdicionarTarefa(tarefa) != false)
                            {
                                Console.WriteLine("tarefa adicionada com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Não foi possível adicoinar a tarefa. Revise os dados e tente novamente");
                            }
                            
                        }
                        catch(FormatException)
                        {
                            Console.WriteLine("Digite uma data válida");
                            
                        }

                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        tarefa = new Tarefa();
                        Console.WriteLine("Digite o nome da Tarefa: ");
                        tarefa.Nome = Console.ReadLine().ToUpper();
                        Console.WriteLine("Digite a data de inicio da tarefa");
                        try
                        {
                            tarefa.DataIncio = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("deseja finalizar a tarefa? s/n");
                            string confirma = Console.ReadLine().ToUpper();
                            if (confirma.Equals("S"))
                            {
                                TarefaDAO.FinalizarTarefa(tarefa);
                                if (TarefaDAO.FinalizarTarefa(tarefa))
                                {
                                    Console.WriteLine("tarefa finalizada!");
                                }
                                else
                                {
                                    Console.WriteLine("Não foi possível finalizar a tarefa. \n verifique os dados e tente novamente.");
                                }
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Digite uma data válida");

                        }
                       

                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Clear();
                        tarefa = new Tarefa();
                        Console.WriteLine("Digite o nome da Tarefa: ");
                        tarefa.Nome = Console.ReadLine().ToUpper();
                        try {

                                Console.WriteLine("Digite a data de inicio da tarefa");
                                tarefa.DataIncio = Convert.ToDateTime(Console.ReadLine());
                                Console.WriteLine("deseja reabrir a tarefa? s/n");
                                string op = Console.ReadLine().ToUpper();
                                if (op.Equals("S"))
                                {
                                    TarefaDAO.ReabrirTarefa(tarefa);
                                    if (TarefaDAO.ReabrirTarefa(tarefa))
                                    {
                                        Console.WriteLine("tarefa reaberta!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Não foi possível reabrir a tarefa. \n verifique os dados e tente novamente.");
                                    }
                                }

                              }catch(FormatException)
                                      {
                                        Console.WriteLine("Digite uma data válida!");
                                      }
                              Console.ReadKey();
                              break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("tarefas pendentes:");
                        foreach (Tarefa tarefaInList in TarefaDAO.ListarTarefasPorStatus("PENDENTE"))
                        {
                            Console.WriteLine(tarefaInList);
                        }
                        Console.ReadKey();
                        break;

                    case "5":
                        Console.Clear();
                        tarefa = new Tarefa();
                        Console.WriteLine("Digite o nome da tarefa");
                        tarefa.Nome = Console.ReadLine().ToUpper();
                        Console.WriteLine("Deseja realmente excluir a tarefa? s/n");
                        string confirm = Console.ReadLine().ToUpper();
                        tarefa = TarefaDAO.BuscarTarefaPorNome(tarefa);
                        if(confirm.Equals("S") && tarefa != null)
                        {
                            TarefaDAO.DeletarTarefa(tarefa);
                            Console.WriteLine("Tarefa Deletada");
                        }else
                        {
                            Console.WriteLine("Não foi possível deletar a tarefa. Verifique se a mesma já existe");
                        }
                        Console.ReadKey();
                        break;
                        
                }
            }
        }
    }
}
