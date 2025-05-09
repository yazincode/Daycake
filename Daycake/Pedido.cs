using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daycake
{
    class Pedido
    {
        public int Id { get; set; }
        public string NumeroPedido { get; set; }
        public string DataPedido { get; set; }
        public string DataEntrega { get; set; }
        public string Status { get; set; }
        public string Cliente { get; set; }
    }
}
