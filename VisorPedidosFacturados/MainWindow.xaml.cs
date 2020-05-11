using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VisorPedidosFacturados.Clases;

namespace VisorPedidosFacturados
{
	public partial class MainWindow : Window
	{
		SqlConnectionStringBuilder StringConexion = new SqlConnectionStringBuilder
		{
			DataSource = "192.168.0.240\\X3V7",
			InitialCatalog = "x3v7",
			UserID = "sa",
			Password = "sql2012",
			MultipleActiveResultSets = true
		};

		DatosParaLaInterfaz DatosInterfaz = new DatosParaLaInterfaz();

		public MainWindow()
		{
			InitializeComponent();
			DataContext = DatosInterfaz;
			DatosInterfaz.FechaOrdenes = DateTime.Today;
			CargaPedidos();
		}

		public void CargaPedidos()
		{
			DatosInterfaz.ListaPedidos.Clear();
			using (SqlConnection Conexion = new SqlConnection(StringConexion.ConnectionString))
			{
				Conexion.Open();

				String Query = "SELECT LASINVNUM_0 , SOHNUM_0, BPCNAM_0, LASDLVNUM_0, BPCORD_0 FROM GIMAR.SORDER WHERE SHIDAT_0 = '" + DatosInterfaz.FechaOrdenes.ToString() + "' ORDER BY BPCORD_0";
				//							0			1		  2			3				4

				using (var dr = new SqlCommand(Query, Conexion).ExecuteReader())
				{
					while (dr.Read())
					{
						DatosInterfaz.ListaPedidos.Add(new Pedido
						{
							IdPedido = dr.GetString(1),
							NombreCliente = dr.GetString(2),
							NumeroFactura = dr.GetString(0),
							NumeroEntrega = dr.GetString(3),
							CodigoCliente = dr.GetString(4)
						}) ;
					}
				}
				Conexion.Close();
			}
		}

		private void BotonRestarUnoFecha_Click(object sender, RoutedEventArgs e)
		{
			DatosInterfaz.FechaOrdenes = DatosInterfaz.FechaOrdenes.AddDays(-1);
			CargaPedidos();
		}

		private void BotonSumarUnoFecha_Click(object sender, RoutedEventArgs e)
		{
			DatosInterfaz.FechaOrdenes = DatosInterfaz.FechaOrdenes.AddDays(1);
			CargaPedidos();
		}

		private void TextoFecha_MouseUp(object sender, MouseButtonEventArgs e)
		{
			CargaPedidos();
		}
	}
}
