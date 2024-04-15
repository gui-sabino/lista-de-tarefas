using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    class Program
    {
        // Coleção genérica para as Tasks
        private static List<string> tasks = new List<string>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Lista de Tarefas");
                Console.WriteLine("-===============-");
                Console.WriteLine("1. Adicionar uma Tarefa");
                Console.WriteLine("2. Editar Tarefa Existente");
                Console.WriteLine("3. Ver Lista Completa");
                Console.WriteLine("4. Excluir uma Tarefa");
                Console.WriteLine("5. Sair");
                Console.Write("\nO que deseja fazer? ");

                string choice = Console.ReadLine();
                if (string.IsNullOrEmpty(choice))
                {
                    Console.WriteLine("Inválido. Selecione uma das opções existentes.");
                    Console.Write("Pressione qualquer tecla para retornar...");
                    Console.ReadKey();
                    continue;
                }
                int.TryParse(choice, out int index);
                switch (index)
                {
                    case 1:
                        AdicionarTask();
                        break;
                    case 2:
                        EditarTask();
                        break;
                    case 3:
                        VerTasks();
                        Console.ReadKey();
                        break;
                    case 4:
                        ExcluirTask();
                        break;
                    case 5:
                        Environment.Exit(0); // Encerra a aplicação de forma mais explícita do que o return
                        break;
                    default:
                        Console.WriteLine("Escolha inválida. Tente novamente.");
                        Console.ReadKey(); // aguarda o usuário pressionar uma tecla para continuar
                        break;
                }
            }
        }

        private static void AdicionarTask()
        {
            Console.Clear();
            Console.Write("Insira o nome da tarefa: ");
            string taskName = Console.ReadLine();
            tasks.Add(taskName);
            Console.WriteLine($"Tarefa '{taskName}' foi adicionada à lista.");
            Console.WriteLine("\n-------------------");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        private static void EditarTask()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Sem tarefas para editar. Crie uma tarefa!");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.Write("Insira o índice(número) da tarefa a editar: ");

            string choice = Console.ReadLine();
            if (string.IsNullOrEmpty(choice))
            {
                Console.WriteLine("Inválido. Selecione uma das opções existentes.");
                Console.Write("Pressione qualquer tecla para retornar...");
                Console.ReadKey();
                return;
            }

            int.TryParse(choice, out int index);

            if (index < 1 || index > tasks.Count)
            {
                Console.WriteLine("Índice inválido. Tente novamente.");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.Write("Insira o novo nome da tarefa: ");
            string newTaskName = Console.ReadLine();

            tasks[index - 1] = newTaskName;
            Console.WriteLine($"Tarefa '{newTaskName}' atualizada.");
            Console.WriteLine("\n-------------------");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        private static void ExcluirTask() // excluir task
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Não há tarefas para excluir. Crie uma tarefa!");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.Write("Insira o índice(número) da tarefa a excluir: ");
            string choice = Console.ReadLine();
            if (string.IsNullOrEmpty(choice))
            {
                Console.WriteLine("Inválido. Selecione uma das opções existentes.");
                Console.Write("Pressione qualquer tecla para retornar...");
                Console.ReadKey();
                return;
            }

            int.TryParse(choice, out int index);

            if (index < 1 || index > tasks.Count)
            {
                Console.WriteLine("Índice inválido. Tente novamente.");
                Console.ReadKey();
                return;
            }

            string taskName = tasks[index - 1];
            tasks.RemoveAt(index - 1);
            Console.WriteLine($"Tarefa '{taskName}' apagada com sucesso.");
            Console.WriteLine("\n-------------------");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        private static void VerTasks() // mostra lista de tasks
        {
            Console.Clear();
            Console.WriteLine("Todas as Tarefas");
            Console.WriteLine("-------------------");

            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }

            Console.WriteLine("-------------------");
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
        }
    }
}