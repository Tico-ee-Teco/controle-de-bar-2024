namespace ControleDeBar.WinApp.ModuloConta
{
    partial class TelaVisualizarFaturamentoForm
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
            txtDataFinal = new DateTimePicker();
            txtDataInicial = new DateTimePicker();
            lblDataFinal = new Label();
            cmbTiposFiltro = new ComboBox();
            lblDataInicial = new Label();
            lblFiltro = new Label();
            groupFaturamento = new GroupBox();
            gridFaturamento = new DataGridView();
            btnFiltrar = new Button();
            label5 = new Label();
            lblValorTotal = new Label();
            btnVoltar = new Button();
            groupFaturamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridFaturamento).BeginInit();
            SuspendLayout();
            // 
            // txtDataFinal
            // 
            txtDataFinal.Format = DateTimePickerFormat.Short;
            txtDataFinal.Location = new Point(436, 45);
            txtDataFinal.Name = "txtDataFinal";
            txtDataFinal.Size = new Size(158, 23);
            txtDataFinal.TabIndex = 25;
            txtDataFinal.Visible = false;
            // 
            // txtDataInicial
            // 
            txtDataInicial.Format = DateTimePickerFormat.Short;
            txtDataInicial.Location = new Point(173, 45);
            txtDataInicial.Name = "txtDataInicial";
            txtDataInicial.Size = new Size(158, 23);
            txtDataInicial.TabIndex = 26;
            txtDataInicial.Visible = false;
            // 
            // lblDataFinal
            // 
            lblDataFinal.AutoSize = true;
            lblDataFinal.Location = new Point(351, 48);
            lblDataFinal.Name = "lblDataFinal";
            lblDataFinal.Size = new Size(62, 15);
            lblDataFinal.TabIndex = 22;
            lblDataFinal.Text = "Data Final:";
            lblDataFinal.Visible = false;
            // 
            // cmbTiposFiltro
            // 
            cmbTiposFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTiposFiltro.FormattingEnabled = true;
            cmbTiposFiltro.Location = new Point(173, 4);
            cmbTiposFiltro.Name = "cmbTiposFiltro";
            cmbTiposFiltro.Size = new Size(421, 23);
            cmbTiposFiltro.TabIndex = 19;
            cmbTiposFiltro.SelectedIndexChanged += cmbTiposFiltro_SelectedIndexChanged;
            // 
            // lblDataInicial
            // 
            lblDataInicial.AutoSize = true;
            lblDataInicial.Location = new Point(80, 48);
            lblDataInicial.Name = "lblDataInicial";
            lblDataInicial.Size = new Size(68, 15);
            lblDataInicial.TabIndex = 23;
            lblDataInicial.Text = "Data Inicial:";
            lblDataInicial.Visible = false;
            // 
            // lblFiltro
            // 
            lblFiltro.AutoSize = true;
            lblFiltro.Location = new Point(12, 7);
            lblFiltro.Name = "lblFiltro";
            lblFiltro.Size = new Size(125, 15);
            lblFiltro.TabIndex = 24;
            lblFiltro.Text = "Filtro do Faturamento:";
            // 
            // groupFaturamento
            // 
            groupFaturamento.Controls.Add(gridFaturamento);
            groupFaturamento.Location = new Point(12, 125);
            groupFaturamento.Name = "groupFaturamento";
            groupFaturamento.Size = new Size(587, 346);
            groupFaturamento.TabIndex = 20;
            groupFaturamento.TabStop = false;
            groupFaturamento.Text = "Tabela de Faturamento";
            // 
            // gridFaturamento
            // 
            gridFaturamento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridFaturamento.Dock = DockStyle.Fill;
            gridFaturamento.Location = new Point(3, 19);
            gridFaturamento.Name = "gridFaturamento";
            gridFaturamento.Size = new Size(581, 324);
            gridFaturamento.TabIndex = 0;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(478, 90);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(121, 29);
            btnFiltrar.TabIndex = 21;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(15, 523);
            label5.Name = "label5";
            label5.Size = new Size(85, 21);
            label5.TabIndex = 29;
            label5.Text = "Valor Total:";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblValorTotal
            // 
            lblValorTotal.AutoSize = true;
            lblValorTotal.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblValorTotal.ForeColor = Color.ForestGreen;
            lblValorTotal.Location = new Point(107, 521);
            lblValorTotal.Name = "lblValorTotal";
            lblValorTotal.Size = new Size(83, 25);
            lblValorTotal.TabIndex = 28;
            lblValorTotal.Text = "R$ 0,00 ";
            lblValorTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnVoltar
            // 
            btnVoltar.BackColor = Color.Lime;
            btnVoltar.DialogResult = DialogResult.OK;
            btnVoltar.Font = new Font("Segoe UI", 11.25F);
            btnVoltar.Location = new Point(436, 506);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(163, 40);
            btnVoltar.TabIndex = 27;
            btnVoltar.Text = "Voltar";
            btnVoltar.UseVisualStyleBackColor = false;
            // 
            // TelaVisualizarFaturamentoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(609, 558);
            Controls.Add(label5);
            Controls.Add(lblValorTotal);
            Controls.Add(btnVoltar);
            Controls.Add(txtDataFinal);
            Controls.Add(txtDataInicial);
            Controls.Add(lblDataFinal);
            Controls.Add(cmbTiposFiltro);
            Controls.Add(lblDataInicial);
            Controls.Add(lblFiltro);
            Controls.Add(groupFaturamento);
            Controls.Add(btnFiltrar);
            Name = "TelaVisualizarFaturamentoForm";
            Text = "TelaVisualizarFaturamentoForm";
            groupFaturamento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridFaturamento).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker txtDataFinal;
        private DateTimePicker txtDataInicial;
        private Label lblDataFinal;
        private ComboBox cmbTiposFiltro;
        private Label lblDataInicial;
        private Label lblFiltro;
        private GroupBox groupFaturamento;
        private DataGridView gridFaturamento;
        private Button btnFiltrar;
        private Label label5;
        private Label lblValorTotal;
        private Button btnVoltar;
    }
}