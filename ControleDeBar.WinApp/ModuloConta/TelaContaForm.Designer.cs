namespace ControleDeBar.WinApp.ModuloConta
{
    partial class TelaContaForm
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
            label1 = new Label();
            txtId = new TextBox();
            label2 = new Label();
            cmbMesa = new ComboBox();
            label3 = new Label();
            cmbGarcom = new ComboBox();
            gpbRegistroPedidos = new GroupBox();
            listPedido = new ListBox();
            btnRemoverPedido = new Button();
            btnAddPedido = new Button();
            nudQuantidade = new NumericUpDown();
            label5 = new Label();
            cmbProduto = new ComboBox();
            label4 = new Label();
            label6 = new Label();
            btnCancelar = new Button();
            btnGravar = new Button();
            lblValorTotal = new Label();
            gpbRegistroPedidos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantidade).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 50);
            label1.Name = "label1";
            label1.Size = new Size(25, 20);
            label1.TabIndex = 0;
            label1.Text = "Id:";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(65, 47);
            txtId.Name = "txtId";
            txtId.Size = new Size(66, 27);
            txtId.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 88);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 2;
            label2.Text = "Mesa:";
            // 
            // cmbMesa
            // 
            cmbMesa.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMesa.FormattingEnabled = true;
            cmbMesa.Location = new Point(65, 85);
            cmbMesa.Name = "cmbMesa";
            cmbMesa.Size = new Size(118, 28);
            cmbMesa.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(221, 88);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 3;
            label3.Text = "Garçom:";
            // 
            // cmbGarcom
            // 
            cmbGarcom.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGarcom.FormattingEnabled = true;
            cmbGarcom.Location = new Point(291, 85);
            cmbGarcom.Name = "cmbGarcom";
            cmbGarcom.Size = new Size(114, 28);
            cmbGarcom.TabIndex = 3;
            // 
            // gpbRegistroPedidos
            // 
            gpbRegistroPedidos.Controls.Add(listPedido);
            gpbRegistroPedidos.Controls.Add(btnRemoverPedido);
            gpbRegistroPedidos.Controls.Add(btnAddPedido);
            gpbRegistroPedidos.Controls.Add(nudQuantidade);
            gpbRegistroPedidos.Controls.Add(label5);
            gpbRegistroPedidos.Controls.Add(cmbProduto);
            gpbRegistroPedidos.Controls.Add(label4);
            gpbRegistroPedidos.Location = new Point(12, 137);
            gpbRegistroPedidos.Name = "gpbRegistroPedidos";
            gpbRegistroPedidos.Size = new Size(406, 303);
            gpbRegistroPedidos.TabIndex = 4;
            gpbRegistroPedidos.TabStop = false;
            gpbRegistroPedidos.Text = "Registro de Pedidos";
            // 
            // listPedido
            // 
            listPedido.FormattingEnabled = true;
            listPedido.ItemHeight = 20;
            listPedido.Location = new Point(7, 104);
            listPedido.Name = "listPedido";
            listPedido.Size = new Size(386, 184);
            listPedido.TabIndex = 9;
            // 
            // btnRemoverPedido
            // 
            btnRemoverPedido.BackColor = Color.FromArgb(192, 0, 0);
            btnRemoverPedido.Location = new Point(279, 69);
            btnRemoverPedido.Name = "btnRemoverPedido";
            btnRemoverPedido.Size = new Size(83, 29);
            btnRemoverPedido.TabIndex = 8;
            btnRemoverPedido.Text = "Remover";
            btnRemoverPedido.UseVisualStyleBackColor = false;
            btnRemoverPedido.Click += btnRemoverPedido_Click;
            // 
            // btnAddPedido
            // 
            btnAddPedido.BackColor = Color.Lime;
            btnAddPedido.Location = new Point(177, 70);
            btnAddPedido.Name = "btnAddPedido";
            btnAddPedido.Size = new Size(83, 28);
            btnAddPedido.TabIndex = 6;
            btnAddPedido.Text = "Adicionar";
            btnAddPedido.UseVisualStyleBackColor = false;
            btnAddPedido.Click += btnAdicionarPedido_Click;
            // 
            // nudQuantidade
            // 
            nudQuantidade.Location = new Point(103, 70);
            nudQuantidade.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudQuantidade.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudQuantidade.Name = "nudQuantidade";
            nudQuantidade.Size = new Size(54, 27);
            nudQuantidade.TabIndex = 5;
            nudQuantidade.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 72);
            label5.Name = "label5";
            label5.Size = new Size(90, 20);
            label5.TabIndex = 4;
            label5.Text = "Quantidade:";
            // 
            // cmbProduto
            // 
            cmbProduto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProduto.FormattingEnabled = true;
            cmbProduto.Location = new Point(104, 31);
            cmbProduto.Name = "cmbProduto";
            cmbProduto.Size = new Size(289, 28);
            cmbProduto.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 34);
            label4.Name = "label4";
            label4.Size = new Size(65, 20);
            label4.TabIndex = 0;
            label4.Text = "Produto:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 453);
            label6.Name = "label6";
            label6.Size = new Size(64, 15);
            label6.TabIndex = 5;
            label6.Text = "Valor Total:";
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(192, 0, 0);
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(313, 447);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(92, 36);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnGravar
            // 
            btnGravar.BackColor = Color.Lime;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(215, 447);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(92, 36);
            btnGravar.TabIndex = 8;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = false;
            btnGravar.Click += btnGravar_Click;
            // 
            // lblValorTotal
            // 
            lblValorTotal.AutoSize = true;
            lblValorTotal.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblValorTotal.ForeColor = Color.ForestGreen;
            lblValorTotal.Location = new Point(82, 453);
            lblValorTotal.Name = "lblValorTotal";
            lblValorTotal.Size = new Size(40, 20);
            lblValorTotal.TabIndex = 14;
            lblValorTotal.Text = "0,00";
            // 
            // TelaContaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(425, 495);
            Controls.Add(lblValorTotal);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(label6);
            Controls.Add(gpbRegistroPedidos);
            Controls.Add(cmbGarcom);
            Controls.Add(label3);
            Controls.Add(cmbMesa);
            Controls.Add(label2);
            Controls.Add(txtId);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TelaContaForm";
            Text = "Cadastro de Conta";
            gpbRegistroPedidos.ResumeLayout(false);
            gpbRegistroPedidos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantidade).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtId;
        private Label label2;
        private ComboBox cmbMesa;
        private Label label3;
        private ComboBox cmbGarcom;
        private GroupBox gpbRegistroPedidos;
        private ComboBox cmbProduto;
        private Label label4;
        private Button btnAddPedido;
        private NumericUpDown nudQuantidade;
        private Label label5;
        private ListBox listPedido;
        private Button btnRemoverPedido;
        private Label label6;
        private Button btnCancelar;
        private Button btnGravar;
        private Label lblValorTotal;
    }
}