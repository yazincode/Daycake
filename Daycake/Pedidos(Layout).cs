using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ListView = System.Windows.Forms.ListView;

namespace Daycake
{
    public partial class FormPedido : Form
    {
        MySqlConnection Conexao;
        private string data_source = "datasource=localhost;username=root;password=1007;database=Daycake";
        public int? id_pedido_selecionado = null;

        List<ClienteItem> ListaClientes = new List<ClienteItem>();
        private bool estaSelecionando = false;

        public FormPedido()
        {
            InitializeComponent();


            lstListaPedidos.View = View.Details;
            lstListaPedidos.Columns.Clear();
            lstListaPedidos.Items.Clear();

            // lstListaPedidos.Columns.Add("ID Pedido", 100);
            lstListaPedidos.Columns.Add("Cliente", 100);
            lstListaPedidos.Columns.Add("Nome do Cliente", 100);
            lstListaPedidos.Columns.Add("Data do Pedido", 100);
            lstListaPedidos.Columns.Add("Data da Entrega", 100);
            lstListaPedidos.Columns.Add("Tipo de Pedido", 180);
            lstListaPedidos.Columns.Add("Valor", 100);
            lstListaPedidos.Columns.Add("Descrição", 180);
            lstListaPedidos.Columns.Add("Forma de Pagamento", 100);
            lstListaPedidos.Columns.Add("Status", 150);

            lstTipoDoce.View = View.Details;
            lstTipoDoce.Columns.Add("Tipo Doce", 200);
            lstTipoDoce.Columns.Add("Preço", 80);
            lstTipoDoce.Columns.Add("Quantidade", 100);

            carregar_pedido();

        }


        private void carregar_pedido()
        {
            try
            {
                Conexao = new MySqlConnection(data_source);

                string sql = "SELECT * FROM pedido ORDER BY idPedido ASC";

                Conexao.Open();

                MySqlCommand buscar = new MySqlCommand(sql, Conexao);

                MySqlDataReader reader = buscar.ExecuteReader();

                lstListaPedidos.Items.Clear();

                while (reader.Read())
                {
                    string[] lin = new string[10];
                    //idPedido, clienteid, nomeCliente, data_pedido, data_entrega, valor, tipo_de_doce, descricao, forma_pagamento, status
                    lin[0] = reader["idPedido"].ToString();
                    lin[1] = reader["clienteid"].ToString();
                    lin[2] = reader["nomeCliente"].ToString();
                    lin[3] = reader["data_pedido"].ToString();
                    lin[4] = reader["data_entrega"].ToString();
                    lin[5] = reader["valor"].ToString();
                    lin[6] = reader["tipo_de_doce"].ToString();
                    lin[7] = reader["descricao"].ToString();
                    lin[8] = reader["forma_pagamento"].ToString();
                    lin[9] = reader["status"].ToString();

                    var linha_list_view = new ListViewItem(lin);
                    lstListaPedidos.Items.Add(linha_list_view);
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
      
        private void btnExcluirPedidos_Click(object sender, EventArgs e)
        {
            excluir_pedido();
        }

        private void zerar_forms()
        {
            id_pedido_selecionado = null;
            //txtNomeCliente.Clear();
            cbxNomeCliente.Text = "";
            mtbDataPedido.Text = "";
            mtbDataEntrega.Text = "";
            mtbValor.Text = "";
            txtDescricao.Text = "";
            lstTipoDoce.Items.Clear();
            cbxFormaPagamento.SelectedIndex = -1;
            cbxStatus.SelectedIndex = -1;


            // txtNomeCliente.Focus();

        }

        private void excluir_pedido()
        {
            try
            {

                DialogResult conf = MessageBox.Show("Deseja Excluir o Registro?",
                                                    "Certeza ?",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Warning);

                if (conf == DialogResult.Yes)
                {


                    Conexao = new MySqlConnection(data_source);
                    Conexao.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = Conexao;

                    cmd.Connection = Conexao;
                    cmd.CommandText = "DELETE FROM pedido WHERE idPedido=@id";
                    cmd.Parameters.AddWithValue("@id", id_pedido_selecionado);

                    cmd.ExecuteNonQuery();


                    MessageBox.Show(
                            "Contato Excluido com Sucesso!",
                            "Sucesso", MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                            );


                    carregar_pedido();

                    zerar_forms();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro " + ex.Number + "Ocorreu: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocorreu: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                Conexao.Close();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            zerar_forms();

        }

        private void btnBuscarPedidos_Click_1(object sender, EventArgs e)
        {
            try
            {
                string termoBusca = "%" + txtBuscarPedidos.Text + "%";

                Conexao = new MySqlConnection(data_source);

                string sql = @"SELECT idPedido, clienteid, nomeCliente, data_pedido, data_entrega, valor, tipo_de_doce, descricao, forma_pagamento, status
                FROM Pedido 
                WHERE nomeCliente LIKE @termo 
                OR valor LIKE @termo 
                OR status LIKE @termo";

                Conexao.Open();

                MySqlCommand cmd = new MySqlCommand(sql, Conexao);
                cmd.Parameters.AddWithValue("@termo", termoBusca);

                MySqlDataReader reader = cmd.ExecuteReader();

                lstListaPedidos.Items.Clear();

                while (reader.Read())
                {
                    string[] lin = new string[10];
                    //idPedido, clienteid, nomeCliente, data_pedido, data_entrega, valor, tipo_de_doce, descricao, forma_pagamento, status
                    lin[0] = reader["idPedido"].ToString();
                    lin[1] = reader["clienteid"].ToString();
                    lin[2] = reader["nomeCliente"].ToString();
                    lin[3] = reader["data_pedido"].ToString();
                    lin[4] = reader["data_entrega"].ToString();
                    lin[5] = reader["valor"].ToString();
                    lin[6] = reader["tipo_de_doce"].ToString();
                    lin[7] = reader["descricao"].ToString();
                    lin[8] = reader["forma_pagamento"].ToString();
                    lin[9] = reader["status"].ToString();

                    var linha_list_view = new ListViewItem(lin);
                    lstListaPedidos.Items.Add(linha_list_view);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na busca: " + ex.Message, "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (Conexao?.State == ConnectionState.Open)
                    Conexao.Close();
            }
        }

        private void excluirPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            excluir_pedido();
        }

        private void btnAtualizarPedido_Click(object sender, EventArgs e)
        {
            try
            {

                if (id_pedido_selecionado == null)
                {
                    MessageBox.Show("Selecione um cliente para atualizar.",
                                   "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Conexao = new MySqlConnection(data_source);
                Conexao.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao;


                cmd.CommandText =

                    "UPDATE pedido SET " +
                    "clienteid = @clienteid, " +
                    "nomeCliente = @nomeCliente, " +
                    "data_pedido = @data_pedido, " +
                    "data_entrega = @data_entrega, " +
                    "valor = @valor, " +
                    "tipo_de_doce = @tipoDoce, " +
                    "descricao = @descricao, " +
                    "forma_pagamento = @forma_pagamento, " +
                    "status = @status " +
                    "WHERE idPedido = @id";

                ClienteItem clienteItem = (ClienteItem)cbxNomeCliente.SelectedItem;
                int id = clienteItem.IDCliente;

                //cmd.Parameters.AddWithValue("@clienteid", txtNomeCliente.Text);
                cmd.Parameters.AddWithValue("@clienteid", id);
                cmd.Parameters.AddWithValue("@nomeCliente", cbxNomeCliente.Text);
                cmd.Parameters.AddWithValue("@data_pedido", mtbDataPedido.Text);
                cmd.Parameters.AddWithValue("@data_entrega", mtbDataEntrega.Text);
                cmd.Parameters.AddWithValue("@valor", mtbValor.Text);
                string tipoDeDoceConcatenado = ConcatenarDocesDoListView(lstTipoDoce);
                cmd.Parameters.AddWithValue("@tipoDoce", tipoDeDoceConcatenado);
                cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text);
                cmd.Parameters.AddWithValue("@forma_pagamento", cbxFormaPagamento.Text);
                cmd.Parameters.AddWithValue("@status", cbxStatus.Text);
                cmd.Parameters.AddWithValue("@id", id_pedido_selecionado);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Cliente atualizado com sucesso!",
                                "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro " + ex.Number + " ocorreu: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (Conexao != null)
                    Conexao.Close();
            }

        }

        private void lstListaPedidos_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ListView.SelectedListViewItemCollection itens_selecionados = lstListaPedidos.SelectedItems;


            foreach (ListViewItem item in itens_selecionados)
            {
                id_pedido_selecionado = Convert.ToInt32(item.SubItems[0].Text);
                cbxNomeCliente.Text = item.SubItems[1].Text;
                mtbDataPedido.Text = item.SubItems[2].Text;
                mtbDataEntrega.Text = item.SubItems[3].Text;
                mtbValor.Text = item.SubItems[4].Text;
                txtDescricao.Text = item.SubItems[5].Text;
                lstTipoDoce.Text = item.SubItems[6].Text;
                cbxFormaPagamento.Text = item.SubItems[7].Text;
                cbxStatus.Text = item.SubItems[8].Text;

            }

            btnExcluirPedido.Visible = true; // Exibe o botão de exclusãoualizarPedido.Visible = true;
        }
        




        // Eventos do combo box nome cliente e botão de fazer pedido

        private void CarregarCliente()
        {
            ListaClientes.Clear();
            cbxNomeCliente.Items.Clear();

            cbxNomeCliente.DropDownStyle = ComboBoxStyle.DropDown;
            cbxNomeCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbxNomeCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection nomes = new AutoCompleteStringCollection();

            using (MySqlConnection conexao = new MySqlConnection("datasource=localhost;username=root;password=1007;database=daycake"))
            {
                try
                {

                    conexao.Open();
                    string sql = "SELECT idCliente, nome FROM Cliente";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClienteItem cliente = new ClienteItem()
                            {
                                IDCliente = Convert.ToInt32(reader["idCliente"]),
                                nomeCliente = reader["nome"].ToString()
                            };

                            ListaClientes.Add(cliente);
                            cbxNomeCliente.Items.Add(cliente);
                            nomes.Add(cliente.nomeCliente);
                        }
                    }
                    cbxNomeCliente.AutoCompleteCustomSource = nomes;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Erro de banco de dados: {ex.Message}");
                    // Logar erro em um arquivo (ex: log4net)
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro inesperado: {ex.Message}");
                    // Logar erro
                }
            }
        }

        private void FormPedido_Load(object sender, EventArgs e)
        {
            cbxNomeCliente.DropDownStyle = ComboBoxStyle.DropDown;

            CarregarCliente();

            cbxNomeCliente.TextChanged += cbxNomeCliente_TextChanged;
            cbxNomeCliente.SelectedIndexChanged += cbxNomeCliente_SelectedIndexChanged;
            cbxNomeCliente.Enter += cbxNomeCliente_Enter;
            cbxNomeCliente.Leave += cbxNomeCliente_Leave;


            cbxStatus.Items.Add("Em andamento");
            cbxStatus.Items.Add("Finalizado");
            cbxStatus.Items.Add("Cancelado");
            cbxStatus.Items.Add("Entregue");

            cbxStatus.SelectedIndex = 0;

            cbxFormaPagamento.Items.Add("PIX");
            cbxFormaPagamento.Items.Add("Cartão de crédito");
            cbxFormaPagamento.Items.Add("Dinheiro");
            cbxFormaPagamento.Items.Add("Débito");

            cbxFormaPagamento.SelectedIndex = 0;

            cbxNomeCliente.DropDownStyle = ComboBoxStyle.DropDown;

            CarregarCliente();

            string connectionString = "datasource=localhost;username=root;password=1007;database=daycake";
            string query = "SELECT nome FROM Produto";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        // Adiciona o nome do produto no ComboBox
                        string nome = reader.GetString("nome");
                        cbxTipoDoce.Items.Add(nome);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar produtos: " + ex.Message);


                }
            }

        }

        private void btnFazerPedido_Click_1(object sender, EventArgs e)
        {
            if (cbxNomeCliente.SelectedItem == null)
            {
                MessageBox.Show("Selecione um cliente válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lstTipoDoce.Items.Count == 0)
            {
                MessageBox.Show("Adicione pelo menos um tipo de doce ao pedido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(mtbDataPedido.Text) || string.IsNullOrEmpty(mtbDataEntrega.Text))
            {
                MessageBox.Show("Preencha as datas do pedido e entrega.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ClienteItem clienteSelecionado = cbxNomeCliente.SelectedItem as ClienteItem;
            int clienteId = clienteSelecionado.IDCliente;

            try
            {
                using (MySqlConnection conexao = new MySqlConnection(data_source))
                {
                    conexao.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conexao;

                    if (id_pedido_selecionado == null) // Inserção de novo pedido
                    {
                        cmd.CommandText =
                            "INSERT INTO pedido (clienteid, nomeCliente, data_pedido, data_entrega, valor, tipo_de_doce, descricao, forma_pagamento, status) " +
                            "VALUES (@clienteid, @nomeCliente, @data_pedido, @data_entrega, @valor, @tipo_de_doce, @descricao, @forma_pagamento, @status)";

                        // Converter valor para decimal (tratando formatação monetária)
                        decimal valor;
                        if (!decimal.TryParse(mtbValor.Text.Replace("R$", "").Trim(), NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-BR"), out valor))
                        { 
                            cmd.Parameters.AddWithValue("@valor", valor);
                        }
                        else
                        {
                            MessageBox.Show("Formato de valor inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                            // Concatenar tipos de doces
                            string tipoDeDoceConcatenado = ConcatenarDocesDoListView(lstTipoDoce);

                        cmd.Parameters.AddWithValue("@clienteid", clienteId);
                        cmd.Parameters.AddWithValue("@nomeCliente", cbxNomeCliente.Text);
                        cmd.Parameters.AddWithValue("@data_pedido", mtbDataPedido.Text);
                        cmd.Parameters.AddWithValue("@data_entrega", mtbDataEntrega.Text);
                        cmd.Parameters.AddWithValue("@tipo_de_doce", tipoDeDoceConcatenado);
                        cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text);
                        cmd.Parameters.AddWithValue("@forma_pagamento", cbxFormaPagamento.Text);
                        cmd.Parameters.AddWithValue("@status", cbxStatus.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Pedido cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        carregar_pedido(); // Atualiza a lista de pedidos
                        zerar_forms(); // Limpa o formulário
                    }
                    else
                    {
                        // Código para atualização (já existente)
                        // ...
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erro ao cadastrar pedido no banco de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxNomeCliente_Enter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbxNomeCliente_Leave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbxNomeCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            estaSelecionando = true;
            ClienteItem clienteSelecionado = cbxNomeCliente.SelectedItem as ClienteItem;
            estaSelecionando = false;
        }

        private void cbxNomeCliente_TextChanged(object sender, EventArgs e)
        {
            if (estaSelecionando)
                return;

            string textoDigitado = cbxNomeCliente.Text.ToLower();

            if (!cbxNomeCliente.Focused)

                return;

            cbxNomeCliente.BeginUpdate();
            cbxNomeCliente.Items.Clear();

            foreach (ClienteItem cliente in ListaClientes)
            {
                if (cliente.nomeCliente.ToLower().Contains(textoDigitado))
                {
                    cbxNomeCliente.Items.Add(cliente);
                }
            }

            cbxNomeCliente.EndUpdate();
            if (cbxNomeCliente.Items.Count > 0)
            {
                cbxNomeCliente.DroppedDown = false;
            }
            cbxNomeCliente.SelectionStart = textoDigitado.Length;
            cbxNomeCliente.SelectionLength = 0;

            this.Cursor = Cursors.Default;
        }

        private void cbxNomeCliente_Enter_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbxNomeCliente_Leave_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }



        // Eventos da função do listview tipoDoce

        private void lstTipoDoce_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTipoDoce.SelectedItems.Count == 1)
            {
                txtQuantidade.Visible = true;

                ListViewItem itemSelecionado = lstTipoDoce.SelectedItems[0];
                txtQuantidade.Text = itemSelecionado.SubItems[2].Text;

                txtQuantidade.Focus();
                txtQuantidade.SelectAll();
            }
        }

        private void cbxTipoDoce_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = "datasource=localhost;username=root;password=1007;database=daycake";
            string produtoSelecionado = cbxTipoDoce.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(produtoSelecionado))
            {
                MessageBox.Show("Selecione um produto válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "SELECT nome, preco, qtd FROM Produto WHERE nome = @nome";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", produtoSelecionado);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int qtdIndex = reader.GetOrdinal("qtd");
                                int quantidade = reader.IsDBNull(qtdIndex) ? 1 : reader.GetInt32(qtdIndex);

                                string nome = reader["nome"].ToString();
                                decimal preco;

                                if (!decimal.TryParse(reader["preco"].ToString(), out preco))
                                {
                                    MessageBox.Show("Formato de preço inválido no banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                bool produtoJaAdicionado = false;
                                foreach (ListViewItem item in lstTipoDoce.Items)
                                {
                                    if (item.Text == nome)
                                    {
                                        produtoJaAdicionado = true;
                                        break;
                                    }
                                }

                                if (produtoJaAdicionado)
                                {
                                    MessageBox.Show("Este produto já foi adicionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }

                                // Adiciona o novo item
                                ListViewItem newItem = new ListViewItem(nome);
                                newItem.SubItems.Add(preco.ToString("C"));
                                newItem.SubItems.Add(quantidade.ToString());
                                newItem.SubItems.Add("0"); // SubItem para o valor total do item
                                lstTipoDoce.Items.Add(newItem);

                                AtualizarTotalGeral();
                            }
                            else
                            {
                                MessageBox.Show("Produto não encontrado no banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AtualizarTotalGeral()
        {
            decimal totalGeral = 0;

            foreach (ListViewItem item in lstTipoDoce.Items)
            {
                if (item.SubItems.Count >= 4 &&
                    decimal.TryParse(item.SubItems[1].Text.Replace("R$", "").Trim(), out decimal preco) &&
                    int.TryParse(item.SubItems[2].Text, out int quantidade))
                {
                    decimal totalItem = preco * quantidade;
                    item.SubItems[3].Text = totalItem.ToString("C"); // Atualiza o valor total do item
                    totalGeral += totalItem;

                }
            }
            mtbValor.Text = totalGeral.ToString("C");

        }

        private string ConcatenarDocesDoListView(ListView listView)
        {
            List<string> docesConcatenados = new List<string>();

            foreach (ListViewItem item in listView.Items)
            {
                string nome = item.SubItems[0].Text;
                string preco = item.SubItems[1].Text;
                string quantidade = item.SubItems[2].Text;

                string linha = $"{nome} - {preco} - {quantidade}";
                docesConcatenados.Add(linha);
            }

            return string.Join("; ", docesConcatenados);
        }

        private void lstTipoDoce_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && lstTipoDoce.SelectedItems.Count > 0)
            {
                lstTipoDoce.Items.Remove(lstTipoDoce.SelectedItems[0]);
            }
        }

        private void txtQuantidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (lstTipoDoce.SelectedItems.Count > 0)
                {
                    ListViewItem selectedItem = lstTipoDoce.SelectedItems[0];
                    selectedItem.SubItems[2].Text = txtQuantidade.Text;

                    e.SuppressKeyPress = true;

                }
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (lstTipoDoce.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecione um item no ListView.");
                return;
            }

            if (!int.TryParse(txtQuantidade.Text, out int novaQuantidade) || novaQuantidade < 1)
            {
                MessageBox.Show("Digite uma quantidade válida.");
                return;
            }

            ListViewItem itemSelecionado = lstTipoDoce.SelectedItems[0];

            if (itemSelecionado.SubItems.Count < 3)
            {
                itemSelecionado.SubItems.Add(novaQuantidade.ToString());
            }
            else
            {
                itemSelecionado.SubItems[2].Text = novaQuantidade.ToString();
            }

            AtualizarTotalGeral();
        }

        private void lstTipoDoce_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = lstTipoDoce.HitTest(e.Location);

            if (info.Item != null && info.SubItem != null)
            {
                int subItemIndex = info.Item.SubItems.IndexOf(info.SubItem);

                if (subItemIndex == 2) // coluna da quantidade
                {
                    txtQuantidade.Text = info.SubItem.Text;
                    txtQuantidade.Visible = true;
                    txtQuantidade.Focus();
                    txtQuantidade.SelectAll();

                    // Opcional: seleciona o item
                    info.Item.Selected = true;
                }
            }
        }
    }
}

