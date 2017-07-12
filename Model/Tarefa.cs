using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Model
{
    class Tarefa
    {
        public string Nome { get; set; }
        public DateTime DataIncio { get; set; }
        public DateTime DataFim { get; set; }
        public string Status { get; set; }

        public override string ToString()
        {
            return " Nome: " + Nome + "\n Data de início: " + DataIncio + "\n Data de conclusão: " + DataFim + "\n Status atual: " + Status;
        }
    }
}
