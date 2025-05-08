using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Daycake
{
    public partial class Status : Form
    {
        public Status()
        {
            InitializeComponent();
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar e converter as datas
                if (!DateTime.TryParse(mtbDataPedido.Text, out DateTime dataPedido))
                {
                    MessageBox.Show("Data do pedido inválida. Use o formato dd/MM/yyyy");
                    mtbDataPedido.Focus();
                    return;
                }

                if (!DateTime.TryParse(mtbDataEntrega.Text, out DateTime dataEntrega))
                {
                    MessageBox.Show("Data de entrega inválida. Use o formato dd/MM/yyyy");
                    mtbDataEntrega.Focus();
                    return;
                }

                string statusSelecionado = cbxStatus.SelectedItem?.ToString();

                // Validar seleção do status
                if (string.IsNullOrEmpty(statusSelecionado))
                {
                    MessageBox.Show("Por favor, selecione um status.");
                    return;
                }

                // Consultar o banco de dados
                var dadosFiltrados = FiltrarDadosDoBanco(dataPedido, dataEntrega, statusSelecionado);

                // Preencher o ListView
                PreencherListView(dadosFiltrados);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao filtrar dados: {ex.Message}");
            }
        }

        private List<Pedido> FiltrarDadosDoBanco(DateTime dataPedido, DateTime dataEntrega, string status)
        {
            List<Pedido> resultados = new List<Pedido>();

            using (var connection = new SqlConnection("sua_string_de_conexao"))
            {
                connection.Open();

                string query = @"SELECT * FROM Pedidos 
                        WHERE DataPedido >= @DataPedidoInicio 
                        AND DataPedido <= @DataPedidoFim
                        AND DataEntrega >= @DataEntregaInicio
                        AND DataEntrega <= @DataEntregaFim
                        AND Status = @Status";

                using (var command = new SqlCommand(query, connection))
                {
                    // Ajuste para considerar todo o dia selecionado
                    command.Parameters.AddWithValue("@DataPedidoInicio", dataPedido.Date);
                    command.Parameters.AddWithValue("@DataPedidoFim", dataPedido.Date.AddDays(1).AddSeconds(-1));
                    command.Parameters.AddWithValue("@DataEntregaInicio", dataEntrega.Date);
                    command.Parameters.AddWithValue("@DataEntregaFim", dataEntrega.Date.AddDays(1).AddSeconds(-1));
                    command.Parameters.AddWithValue("@Status", status);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resultados.Add(new Pedido
                            {
                                Id = reader.GetInt32(0),
                                NumeroPedido = reader.GetString(1),
                                DataPedido = reader.GetDateTime(2),
                                DataEntrega = reader.GetDateTime(3),
                                Status = reader.GetString(4),
                                Cliente = reader.GetString(5)
                                // ... outros campos conforme sua tabela
                            });
                        }
                    }
                }
            }

            return resultados;
        }
        private void PreencherListView(List<Pedido> pedidos)
        {
            lstFiltro.Items.Clear();

            // Configurar colunas se ainda não estiverem configuradas
            if (lstFiltro.Columns.Count == 0)
            {
                lstFiltro.View = View.Details;
                lstFiltro.Columns.Add("ID", 50);
                lstFiltro.Columns.Add("Nº Pedido", 80);
                lstFiltro.Columns.Add("Data Pedido", 100);
                lstFiltro.Columns.Add("Data Entrega", 100);
                lstFiltro.Columns.Add("Status", 80);
                lstFiltro.Columns.Add("Cliente", 150);
                // ... outras colunas conforme necessário
            }

            // Adicionar os itens
            foreach (var pedido in pedidos)
            {
                var item = new ListViewItem(pedido.Id.ToString());
                item.SubItems.Add(pedido.NumeroPedido);
                item.SubItems.Add(pedido.DataPedido.ToString("dd/MM/yyyy"));
                item.SubItems.Add(pedido.DataEntrega.ToString("dd/MM/yyyy"));
                item.SubItems.Add(pedido.Status);
                item.SubItems.Add(pedido.Cliente);
                // ... outros campos

                lstFiltro.Items.Add(item);
            }
        }

        private void Status_Load(object sender, EventArgs e)
        {
            cbxStatus.Items.Add("Em andamento");
            cbxStatus.Items.Add("Finalizado");
            cbxStatus.Items.Add("Cancelado");
            cbxStatus.Items.Add("Entregue");

            cbxStatus.SelectedIndex = 0;
        }
    }
}
