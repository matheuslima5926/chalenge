using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Model;

namespace TodoList.DAL
{
    class TarefaDAO
    {
        private static List<Tarefa> tarefas = new List<Tarefa>();

		public static bool AdicionarTarefa(Tarefa tarefa) 
		{
            //valida se a tarefa já existe ou se o nome está em branco
            if (!String.IsNullOrEmpty(tarefa.Nome) && BuscarTarefaPorNome(tarefa) == null)
            {
                    tarefa.Status = "PENDENTE";
                    tarefa.DataFim = Convert.ToDateTime("01/01/0001");
                    tarefas.Add(tarefa);
                    return true;
                
            }
			return false;
		}

        public static bool FinalizarTarefa(Tarefa tarefa)
        {
            tarefa = BuscarTarefaPorDataENome(tarefa);
            if(tarefa != null)
            {
                foreach(Tarefa tarefaInList in ListarTarefas())
                {
                    if(tarefaInList.Nome.Equals(tarefa.Nome) && tarefaInList.DataIncio.Equals(tarefa.DataIncio))
                    {
                        tarefaInList.Status = "FINALIZADA";
                        tarefaInList.DataFim = DateTime.Now;
                    }
                }
                return true;
            }
            return false;
        }

        public static bool ReabrirTarefa(Tarefa tarefa)
        {
            tarefa = BuscarTarefaPorDataENome(tarefa);
            if (tarefa != null)
            {
                foreach (Tarefa tarefaInList in ListarTarefas())
                {
                    if (tarefaInList.Nome.Equals(tarefa.Nome) && tarefaInList.DataIncio.Equals(tarefa.DataIncio))
                    {
                        tarefaInList.Status = "PENDENTE";
                        tarefaInList.DataFim = Convert.ToDateTime("01/01/0001");
                    }
                }
                return true;
            }
            return false;
        }
        public static Tarefa BuscarTarefaPorNome(Tarefa tarefa) 
		{
			foreach(Tarefa tarefaInList in ListarTarefas())
			{
				if(tarefaInList.Nome.Equals(tarefa.Nome))
				{
                    return tarefaInList;
				}
			}
            return null;
		}

		public static List<Tarefa> ListarTarefas()
		 {
            return tarefas;
		 }

		 public static bool DeletarTarefa(Tarefa tarefa) 
		 {
		 try
		  {
            ListarTarefas().RemoveAll(x => x.Nome.Equals(tarefa.Nome));
            return true;
          }
          catch(Exception e) 
		  {
            throw e;
		  }
           
		 }

		 public static bool AlterarStatus (Tarefa tarefa)
		 {
            tarefa = BuscarTarefaPorNome(tarefa);
            if(tarefa != null) 
            {
                if(tarefa.Status.Equals("PENDENTE"))
                {
                    ReabrirTarefa(tarefa);
                    return true;
                }else if(tarefa.Status.Equals("FINALIZADA"))
                {
                    FinalizarTarefa(tarefa);
                    return true;
                }
            }
            return false;
		
		 }
         public static Tarefa BuscarTarefaPorDataENome(Tarefa tarefa)
         {
            foreach (Tarefa tarefaInList in ListarTarefas())
            {
                if(tarefaInList.DataIncio.Equals(tarefa.DataIncio) && tarefaInList.Nome.Equals(tarefa.Nome))
                {
                    return tarefaInList;
                }
            }
            return null;
         }

         public static List<Tarefa> ListarTarefasPorStatus(string status) 
         {
            List<Tarefa> tarefasAux = new List<Tarefa>();
            foreach(Tarefa tarefaInList in ListarTarefas())
            {
                if (tarefaInList.Status.Equals(status))
                {
                    tarefasAux.Add(tarefaInList);
                }
            }
            return tarefasAux;
         }
         
    }
}
