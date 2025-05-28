using MySql.Data.MySqlClient;
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
        MySqlConnection Conexao;
        private string data_source = "datasource=localhost;username=root;password=1007;database=Daycake";
        public int? id_pedido_selecionado = null;

        public Status()
        {
            InitializeComponent();

            lstFiltro.View = View.Details;
            lstFiltro.Columns.Clear();
            lstFiltro.Items.Clear();

            lstFiltro.Columns.Add("ID Pedido", 100);
            lstFiltro.Columns.Add("ID Cliente", 100);
            lstFiltro.Columns.Add("Nome do Cliente", 100);
            lstFiltro.Columns.Add("Data do Pedido", 100);
            lstFiltro.Columns.Add("Data da Entrega", 100);
            lstFiltro.Columns.Add("Status", 180);

            carregar_pedido();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                Conexao = new MySqlConnection(data_source);
                Conexao.Open();

                string statusSelecionado = cbxStatus.SelectedItem?.ToString();
                string dataPedidoTexto = mtbDataPedido.Text.Trim();
                string dataEntregaTexto = mtbDataEntrega.Text.Trim();

                // Verificação de campos obrigatórios
                if (string.IsNullOrEmpty(statusSelecionado) ||
                    string.IsNullOrEmpty(dataPedidoTexto) ||
                    string.IsNullOrEmpty(dataEntregaTexto))
                {
                    MessageBox.Show("Preencha todos os campos: Data do Pedido, Data de Entrega e Status.");
                    return;
                }

                // Conversão segura de datas
                if (!DateTime.TryParse(dataPedidoTexto, out DateTime dataPedido))
                {
                    MessageBox.Show("Data do Pedido inválida.");
                    return;
                }

                if (!DateTime.TryParse(dataEntregaTexto, out DateTime dataEntrega))
                {
                    MessageBox.Show("Data da Entrega inválida.");
                    return;
                }

                string sql = @"SELECT idPedido, clienteid, nomeCliente, data_pedido, data_entrega, status 
                       FROM Pedido 
                       WHERE status = @Status AND data_pedido = @DataPedido AND data_entrega = @DataEntrega";

                MySqlCommand cmd = new MySqlCommand(sql, Conexao);
                cmd.Parameters.AddWithValue("@Status", statusSelecionado);
                cmd.Parameters.AddWithValue("@DataPedido", dataPedido.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@DataEntrega", dataEntrega.ToString("yyyy-MM-dd"));

                MySqlDataReader reader = cmd.ExecuteReader();
                lstFiltro.Items.Clear();

                while (reader.Read())
                {
                    string[] lin = new string[6];
                    lin[0] = reader["idPedido"].ToString();
                    lin[1] = reader["clienteid"].ToString();
                    lin[2] = reader["nomeCliente"].ToString();
                    lin[3] = Convert.ToDateTime(reader["data_pedido"]).ToString("dd/MM/yyyy");
                    lin[4] = Convert.ToDateTime(reader["data_entrega"]).ToString("dd/MM/yyyy");
                    lin[5] = reader["status"].ToString();

                    var linha_list_view = new ListViewItem(lin);
                    lstFiltro.Items.Add(linha_list_view);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao filtrar pedidos: " + ex.Message);
            }
            finally
            {
                Conexao.Close();
            }
        }

        private void Status_Load(object sender, EventArgs e)
        {
            cbxStatus.Items.Clear(); // Limpa itens existentes

            try
            {
                Conexao = new MySqlConnection(data_source);
                Conexao.Open();

                string sql = "SELECT DISTINCT status FROM Pedido ORDER BY status";

                MySqlCommand cmd = new MySqlCommand(sql, Conexao);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cbxStatus.Items.Add(reader["status"].ToString());
                }

                if (cbxStatus.Items.Count > 0)
                    cbxStatus.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar status do banco: " + ex.Message);
            }
            finally
            {
                Conexao.Close();
            }

            carregar_pedido();
        }
   

    private void carregar_pedido()
        {
            try
            {
                Conexao = new MySqlConnection(data_source);

                string sql = "SELECT idPedido, clienteid, nomeCliente, data_pedido, data_entrega, status FROM Pedido ORDER BY idPedido ASC";

                Conexao.Open();

                MySqlCommand buscar = new MySqlCommand(sql, Conexao);

                MySqlDataReader reader = buscar.ExecuteReader();

                lstFiltro.Items.Clear();

                while (reader.Read())
                {
                    string[] lin = new string[6];
                    lin[0] = reader["idPedido"].ToString();
                    lin[1] = reader["clienteid"].ToString();
                    lin[2] = reader["nomeCliente"].ToString();
                    lin[3] = Convert.ToDateTime(reader["data_pedido"]).ToString("dd/MM/yyyy");
                    lin[4] = Convert.ToDateTime(reader["data_entrega"]).ToString("dd/MM/yyyy");
                    lin[5] = reader["status"].ToString();

                    var linha_list_view = new ListViewItem(lin);
                    lstFiltro.Items.Add(linha_list_view);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conexao.Close();
            }
        }
    }
}

