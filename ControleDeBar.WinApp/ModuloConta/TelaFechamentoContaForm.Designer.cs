namespace ControleDeBar.WinApp.ModuloConta
{
    partial class TelaFechamentoContaForm
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
            groupBox1 = new GroupBox();
            listPedidos = new ListBox();
            txtGarcom = new TextBox();
            txtMesa = new TextBox();
            txtTitular = new TextBox();
            txtId = new TextBox();
            label8 = new Label();
            lblTitular = new Label();
            label7 = new Label();
            label1 = new Label();
            label5 = new Label();
            lblValorTotal = new Label();
            btnCacnelar = new Button();
            btnGravar = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listPedidos);
            groupBox1.Font = new Font("Segoe UI", 11.25F);
            groupBox1.Location = new Point(5, 118);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(531, 371);
            groupBox1.TabIndex = 22;
            groupBox1.TabStop = false;
            groupBox1.Text = "Produtos Consumidos";
            // 
            // listPedidos
            // 
            listPedidos.FormattingEnabled = true;
            listPedidos.ItemHeight = 20;
            listPedidos.Location = new Point(9, 34);
            listPedidos.Name = "listPedidos";
            listPedidos.Size = new Size(504, 324);
            listPedidos.TabIndex = 17;
            // 
            // txtGarcom
            // 
            txtGarcom.Enabled = false;
            txtGarcom.Font = new Font("Segoe UI", 11.25F);
            txtGarcom.Location = new Point(354, 72);
            txtGarcom.Name = "txtGarcom";
            txtGarcom.PlaceholderText = "Nome do Garçom";
            txtGarcom.Size = new Size(173, 27);
            txtGarcom.TabIndex = 18;
            txtGarcom.TabStop = false;
            // 
            // txtMesa
            // 
            txtMesa.Enabled = false;
            txtMesa.Font = new Font("Segoe UI", 11.25F);
            txtMesa.Location = new Point(66, 72);
            txtMesa.Name = "txtMesa";
            txtMesa.PlaceholderText = "Número da Mesa";
            txtMesa.Size = new Size(175, 27);
            txtMesa.TabIndex = 19;
            txtMesa.TabStop = false;
            // 
            // txtTitular
            // 
            txtTitular.Enabled = false;
            txtTitular.Font = new Font("Segoe UI", 11.25F);
            txtTitular.Location = new Point(66, 39);
            txtTitular.Name = "txtTitular";
            txtTitular.PlaceholderText = "Nome do Cliente";
            txtTitular.Size = new Size(461, 27);
            txtTitular.TabIndex = 20;
            txtTitular.TabStop = false;
            // 
            // txtId
            // 
            txtId.Font = new Font("Segoe UI", 11.25F);
            txtId.Location = new Point(66, 6);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(67, 27);
            txtId.TabIndex = 21;
            txtId.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11.25F);
            label8.Location = new Point(13, 75);
            label8.Name = "label8";
            label8.Size = new Size(47, 20);
            label8.TabIndex = 17;
            label8.Text = "Mesa:";
            // 
            // lblTitular
            // 
            lblTitular.AutoSize = true;
            lblTitular.Font = new Font("Segoe UI", 11.25F);
            lblTitular.Location = new Point(6, 42);
            lblTitular.Name = "lblTitular";
            lblTitular.Size = new Size(54, 20);
            lblTitular.TabIndex = 14;
            lblTitular.Text = "Titular:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F);
            label7.Location = new Point(284, 75);
            label7.Name = "label7";
            label7.Size = new Size(64, 20);
            label7.TabIndex = 16;
            label7.Text = "Garçom:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F);
            label1.Location = new Point(35, 9);
            label1.Name = "label1";
            label1.Size = new Size(25, 20);
            label1.TabIndex = 15;
            label1.Text = "Id:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(11, 504);
            label5.Name = "label5";
            label5.Size = new Size(85, 21);
            label5.TabIndex = 26;
            label5.Text = "Valor Total:";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblValorTotal
            // 
            lblValorTotal.AutoSize = true;
            lblValorTotal.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblValorTotal.ForeColor = Color.ForestGreen;
            lblValorTotal.Location = new Point(103, 502);
            lblValorTotal.Name = "lblValorTotal";
            lblValorTotal.Size = new Size(83, 25);
            lblValorTotal.TabIndex = 25;
            lblValorTotal.Text = "R$ 0,00 ";
            lblValorTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCacnelar
            // 
            btnCacnelar.DialogResult = DialogResult.Cancel;
            btnCacnelar.Font = new Font("Segoe UI", 11.25F);
            btnCacnelar.Location = new Point(442, 495);
            btnCacnelar.Name = "btnCacnelar";
            btnCacnelar.Size = new Size(94, 39);
            btnCacnelar.TabIndex = 23;
            btnCacnelar.Text = "Cancelar";
            btnCacnelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Font = new Font("Segoe UI", 11.25F);
            btnGravar.ForeColor = SystemColors.ControlText;
            btnGravar.Location = new Point(284, 495);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(152, 39);
            btnGravar.TabIndex = 24;
            btnGravar.Text = "Fechar Conta";
            btnGravar.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnGravar.UseVisualStyleBackColor = true;
            // 
            // TelaFechamentoContaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(551, 538);
            Controls.Add(label5);
            Controls.Add(lblValorTotal);
            Controls.Add(btnCacnelar);
            Controls.Add(btnGravar);
            Controls.Add(groupBox1);
            Controls.Add(txtGarcom);
            Controls.Add(txtMesa);
            Controls.Add(txtTitular);
            Controls.Add(txtId);
            Controls.Add(label8);
            Controls.Add(lblTitular);
            Controls.Add(label7);
            Controls.Add(label1);
            Name = "TelaFechamentoContaForm";
            Text = "TelaFechamentoContaForm";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private ListBox listPedidos;
        private TextBox txtGarcom;
        private TextBox txtMesa;
        private TextBox txtTitular;
        private TextBox txtId;
        private Label label8;
        private Label lblTitular;
        private Label label7;
        private Label label1;
        private Label label5;
        private Label lblValorTotal;
        private Button btnCacnelar;
        private Button btnGravar;
    }
}