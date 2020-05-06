using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisorPedidosFacturados.Clases
{
	public class DatosParaLaInterfaz : INotifyPropertyChanged
	{
		ObservableCollection<Pedido> ListaPedidosProperty { get; set; }

		public ObservableCollection<Pedido> ListaPedidos
		{
			get
			{
				if (ListaPedidosProperty == null)
					ListaPedidosProperty = new ObservableCollection<Pedido>();
				return ListaPedidosProperty;
			}
			set { ListaPedidosProperty = value; }
		}

		private DateTime Fecha = DateTime.Today;

		public event PropertyChangedEventHandler PropertyChanged;

		public DateTime FechaOrdenes
		{
			get
			{
				return Fecha;
			}
			set
			{
				Fecha = value;

				OnPropertyChanged("FechaOrdenes");
			}
		}

		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
