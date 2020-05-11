using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace VisorPedidosFacturados.Clases
{
	public class Pedido
	{
		public string IdPedido { get; set; }
		public string NombreCliente { get; set; }
		public string NumeroFactura { get; set; }
		public string NumeroEntrega { get; set; }
		public string CodigoCliente { get; set; }

		public System.Windows.Media.Brush ColorFondoPedido
		{
			get
			{

				if (!NumeroEntrega.Equals(" "))
				{
					if (!NumeroFactura.Equals(" "))
					{
						return Brushes.Green;
					}
					else
					{
						return Brushes.Red;
					}
				}
				else
				{
					return Brushes.Transparent;
				}
			}
		}


		public string TextoPedido
		{
			get
			{
				if (!NumeroEntrega.Equals(" "))
				{
					return NumeroEntrega;
				}
				else
				{
					return IdPedido;
				}
			}
		}
	}
}
