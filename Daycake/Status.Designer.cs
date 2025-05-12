namespace Daycake
{
    partial class Status
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Status));
            this.tabStatusPedido = new System.Windows.Forms.TabPage();
            this.tblPanelBase = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.mtbDataEntrega = new System.Windows.Forms.MaskedTextBox();
            this.mtbDataPedido = new System.Windows.Forms.MaskedTextBox();
            this.lblDataPedido = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.lblDataEntrega = new System.Windows.Forms.Label();
            this.lblFiltre = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.lstFiltro = new System.Windows.Forms.ListView();
            this.tabControlStatus = new System.Windows.Forms.TabControl();
            this.tabStatusPedido.SuspendLayout();
            this.tblPanelBase.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabStatusPedido
            // 
            this.tabStatusPedido.Controls.Add(this.tblPanelBase);
            this.tabStatusPedido.Location = new System.Drawing.Point(4, 22);
            this.tabStatusPedido.Name = "tabStatusPedido";
            this.tabStatusPedido.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatusPedido.Size = new System.Drawing.Size(794, 421);
            this.tabStatusPedido.TabIndex = 0;
            this.tabStatusPedido.Text = "Status do Pedido";
            this.tabStatusPedido.UseVisualStyleBackColor = true;
            // 
            // tblPanelBase
            // 
            this.tblPanelBase.BackgroundImage = global::Daycake.Properties.Resources.FundoPag_21;
            this.tblPanelBase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tblPanelBase.ColumnCount = 3;
            this.tblPanelBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblPanelBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblPanelBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblPanelBase.Controls.Add(this.lstFiltro, 1, 2);
            this.tblPanelBase.Controls.Add(this.tableLayoutPanel1, 1, 1);
            this.tblPanelBase.Location = new System.Drawing.Point(-4, 0);
            this.tblPanelBase.Name = "tblPanelBase";
            this.tblPanelBase.RowCount = 4;
            this.tblPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tblPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tblPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tblPanelBase.Size = new System.Drawing.Size(802, 425);
            this.tblPanelBase.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnFiltrar, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblFiltre, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(33, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.89691F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(736, 109);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 235F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 234F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 261F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.lblDataEntrega, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbxStatus, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblStatus, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblDataPedido, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.mtbDataPedido, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.mtbDataEntrega, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 35);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(730, 45);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // mtbDataEntrega
            // 
            this.mtbDataEntrega.Location = new System.Drawing.Point(238, 23);
            this.mtbDataEntrega.Mask = "00/00/0000";
            this.mtbDataEntrega.Name = "mtbDataEntrega";
            this.mtbDataEntrega.Size = new System.Drawing.Size(228, 20);
            this.mtbDataEntrega.TabIndex = 17;
            this.mtbDataEntrega.ValidatingType = typeof(System.DateTime);
            // 
            // mtbDataPedido
            // 
            this.mtbDataPedido.Location = new System.Drawing.Point(3, 23);
            this.mtbDataPedido.Mask = "00/00/0000";
            this.mtbDataPedido.Name = "mtbDataPedido";
            this.mtbDataPedido.Size = new System.Drawing.Size(229, 20);
            this.mtbDataPedido.TabIndex = 16;
            this.mtbDataPedido.ValidatingType = typeof(System.DateTime);
            // 
            // lblDataPedido
            // 
            this.lblDataPedido.AutoSize = true;
            this.lblDataPedido.ForeColor = System.Drawing.Color.Black;
            this.lblDataPedido.Location = new System.Drawing.Point(3, 0);
            this.lblDataPedido.Name = "lblDataPedido";
            this.lblDataPedido.Size = new System.Drawing.Size(83, 13);
            this.lblDataPedido.TabIndex = 9;
            this.lblDataPedido.Text = "Data do pedido:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Location = new System.Drawing.Point(472, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Status:";
            // 
            // cbxStatus
            // 
            this.cbxStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxStatus.FormattingEnabled = true;
            this.cbxStatus.Location = new System.Drawing.Point(472, 23);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(255, 21);
            this.cbxStatus.TabIndex = 14;
            // 
            // lblDataEntrega
            // 
            this.lblDataEntrega.AutoSize = true;
            this.lblDataEntrega.ForeColor = System.Drawing.Color.Black;
            this.lblDataEntrega.Location = new System.Drawing.Point(238, 0);
            this.lblDataEntrega.Name = "lblDataEntrega";
            this.lblDataEntrega.Size = new System.Drawing.Size(87, 13);
            this.lblDataEntrega.TabIndex = 15;
            this.lblDataEntrega.Text = "Data do entrega:";
            // 
            // lblFiltre
            // 
            this.lblFiltre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFiltre.AutoSize = true;
            this.lblFiltre.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.lblFiltre.Location = new System.Drawing.Point(4, 0);
            this.lblFiltre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiltre.Name = "lblFiltre";
            this.lblFiltre.Size = new System.Drawing.Size(728, 16);
            this.lblFiltre.TabIndex = 35;
            this.lblFiltre.Text = "Filtre aqui o pedido:";
            this.lblFiltre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFiltrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.ForeColor = System.Drawing.Color.Black;
            this.btnFiltrar.Location = new System.Drawing.Point(3, 86);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(730, 20);
            this.btnFiltrar.TabIndex = 36;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // lstFiltro
            // 
            this.lstFiltro.BackColor = System.Drawing.Color.White;
            this.lstFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFiltro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.lstFiltro.HideSelection = false;
            this.lstFiltro.Location = new System.Drawing.Point(33, 127);
            this.lstFiltro.Name = "lstFiltro";
            this.lstFiltro.Size = new System.Drawing.Size(736, 257);
            this.lstFiltro.TabIndex = 1;
            this.lstFiltro.UseCompatibleStateImageBehavior = false;
            // 
            // tabControlStatus
            // 
            this.tabControlStatus.Controls.Add(this.tabStatusPedido);
            this.tabControlStatus.Location = new System.Drawing.Point(-3, 1);
            this.tabControlStatus.Name = "tabControlStatus";
            this.tabControlStatus.SelectedIndex = 0;
            this.tabControlStatus.Size = new System.Drawing.Size(802, 447);
            this.tabControlStatus.TabIndex = 0;
            // 
            // Status
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControlStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Status";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Status";
            this.Load += new System.EventHandler(this.Status_Load);
            this.tabStatusPedido.ResumeLayout(false);
            this.tblPanelBase.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabControlStatus.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabStatusPedido;
        private System.Windows.Forms.TableLayoutPanel tblPanelBase;
        private System.Windows.Forms.ListView lstFiltro;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Label lblFiltre;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblDataEntrega;
        private System.Windows.Forms.ComboBox cbxStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblDataPedido;
        private System.Windows.Forms.MaskedTextBox mtbDataPedido;
        private System.Windows.Forms.MaskedTextBox mtbDataEntrega;
        private System.Windows.Forms.TabControl tabControlStatus;
    }
}