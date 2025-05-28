using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Daycake
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            btnAcessar.Click += new EventHandler(btnAcessar_Click); // Conectar evento ao botão  
            btnAcessar.Paint += new PaintEventHandler(btnAcessar_Paint); // Conectar evento Paint ao botão  
            RoundedTextBox txtLogin = new RoundedTextBox();
            RoundedTextBox txtSenha = new RoundedTextBox();
        }

        private void btnAcessar_Click(object sender, EventArgs e)
        {

            //FormMenu menu = new FormMenu();
            //menu.Show(this);
        }

        private void btnAcessar_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // Cores personalizadas  
                Color fillColor = Color.FromArgb(141, 98, 98); // Cor de preenchimento  
                Color borderColor = Color.FromArgb(255, 235, 223); // Cor da borda  
                Color textColor = Color.FromArgb(255, 235, 223); // Cor do texto  

                Brush fillBrush = new SolidBrush(fillColor);
                Pen borderPen = new Pen(borderColor, 1); // Borda mais fina (1px)  
                int cornerRadius = 15; // Raio menor para bordas mais delicadas  

                // Desenhar o fundo arredondado  
                GraphicsPath path = new GraphicsPath();
                path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
                path.AddArc(btn.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
                path.AddArc(btn.Width - cornerRadius, btn.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
                path.AddArc(0, btn.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
                path.CloseAllFigures();

                g.FillPath(fillBrush, path);
                g.DrawPath(borderPen, path);

                // Desenhar o texto centralizado  
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                Font font = btn.Font; // Usa a fonte padrão do botão ou defina uma nova  
                g.DrawString("Acessar", font, new SolidBrush(textColor),
                            new RectangleF(0, 0, btn.Width, btn.Height), sf);
            }
        }

        public class RoundedTextBox : UserControl
        {
            private TextBox textBox = new TextBox();
            private int cornerRadius = 15;
            private Color borderColor = Color.FromArgb(255, 235, 223); // mesma do botão
            private Color backColorCustom = Color.FromArgb(141, 98, 98); // mesma do botão
            private Color foreColorCustom = Color.FromArgb(255, 235, 223); // texto igual ao botão

            public RoundedTextBox()
            {
                this.DoubleBuffered = true;
                textBox.BorderStyle = BorderStyle.None;
                textBox.BackColor = backColorCustom;
                textBox.ForeColor = foreColorCustom;
                textBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                textBox.Location = new Point(10, 7);
                textBox.Width = this.Width - 20;
                textBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                textBox.TextAlign = HorizontalAlignment.Left;
                this.Controls.Add(textBox);
                this.BackColor = Color.Transparent;
                this.Padding = new Padding(10);
                this.Resize += RoundedTextBox_Resize;
            }

            private void RoundedTextBox_Resize(object sender, EventArgs e)
            {
                textBox.Width = this.Width - 20;
                textBox.Height = this.Height - 14;
            }

            public override string Text
            {
                get { return textBox.Text; }
                set { textBox.Text = value; }
            }

            public bool UseSystemPasswordChar
            {
                get { return textBox.UseSystemPasswordChar; }
                set { textBox.UseSystemPasswordChar = value; }
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                GraphicsPath path = new GraphicsPath();
                Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

                path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90);
                path.AddArc(rect.Right - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90);
                path.AddArc(rect.Right - cornerRadius, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90);
                path.CloseFigure();

                using (SolidBrush brush = new SolidBrush(backColorCustom))
                {
                    g.FillPath(brush, path);
                }
                using (Pen pen = new Pen(borderColor, 1))
                {
                    g.DrawPath(pen, path);
                }
            }

            private void btnAcessar_Click_1(object sender, EventArgs e)
            {
                //depois de abrir o menu, sem usar o hide:

                FormMenu menu = new FormMenu();


            }

            private void Login_Load(object sender, EventArgs e)
            {

            }
        }

        private void btnAcessar_Click_1(object sender, EventArgs e)
        {
            string usuario = txtLogin.Text.Trim();
            string senha = txtSenha.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidarLogin(usuario, senha))
            {
                MessageBox.Show("Login realizado com sucesso!", "Bem-vindo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FormMenu menu = new FormMenu();
                menu.Show(this);
            }
            else
            {
                MessageBox.Show("Login ou senha inválidos ou usuário inativo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarLogin(string usuario, string senha)
        {
            string conexaoString = "datasource=localhost;username=root;password=1007;database=daycake";

            using (MySqlConnection conexao = new MySqlConnection(conexaoString))
            {
                string query = "SELECT COUNT(*) FROM Usuario WHERE login = @login AND senha = @senha AND ativo = true";
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@login", usuario);
                cmd.Parameters.AddWithValue("@senha", senha);

                try
                {
                    conexao.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao conectar ao banco de dados:\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
    }
}