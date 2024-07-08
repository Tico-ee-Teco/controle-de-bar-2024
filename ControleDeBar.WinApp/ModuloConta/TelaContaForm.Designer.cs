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
            textBox1 = new TextBox();
            label2 = new Label();
            cmbMesa = new ComboBox();
            label3 = new Label();
            cmbGarcom = new ComboBox();
            gpbRegistroPedidos = new GroupBox();
            label4 = new Label();
            comboBox1 = new ComboBox();
            label5 = new Label();
            numericUpDown1 = new NumericUpDown();
            btnAddPedido = new Button();
            btnEditarPedido = new Button();
            btnRemoverPedido = new Button();
            listPedido = new ListBox();
            label6 = new Label();
            textBox2 = new TextBox();
            btnCancelar = new Button();
            btnGravar = new Button();
            gpbRegistroPedidos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
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
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Location = new Point(65, 47);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(66, 27);
            textBox1.TabIndex = 1;
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
            gpbRegistroPedidos.Controls.Add(btnEditarPedido);
            gpbRegistroPedidos.Controls.Add(btnAddPedido);
            gpbRegistroPedidos.Controls.Add(numericUpDown1);
            gpbRegistroPedidos.Controls.Add(label5);
            gpbRegistroPedidos.Controls.Add(comboBox1);
            gpbRegistroPedidos.Controls.Add(label4);
            gpbRegistroPedidos.Location = new Point(12, 137);
            gpbRegistroPedidos.Name = "gpbRegistroPedidos";
            gpbRegistroPedidos.Size = new Size(438, 303);
            gpbRegistroPedidos.TabIndex = 4;
            gpbRegistroPedidos.TabStop = false;
            gpbRegistroPedidos.Text = "Registro de Pedidos";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 34);
            label4.Name = "label4";
            label4.Size = new Size(65, 20);
            label4.TabIndex = 0;
            label4.Text = "Produto:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(103, 31);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(258, 28);
            comboBox1.TabIndex = 3;
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
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(103, 70);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(54, 27);
            numericUpDown1.TabIndex = 5;
            // 
            // btnAddPedido
            // 
            btnAddPedido.Location = new Point(172, 70);
            btnAddPedido.Name = "btnAddPedido";
            btnAddPedido.Size = new Size(83, 27);
            btnAddPedido.TabIndex = 6;
            btnAddPedido.Text = "Adicionar";
            btnAddPedido.UseVisualStyleBackColor = true;
            // 
            // btnEditarPedido
            // 
            btnEditarPedido.Location = new Point(261, 70);
            btnEditarPedido.Name = "btnEditarPedido";
            btnEditarPedido.Size = new Size(83, 27);
            btnEditarPedido.TabIndex = 7;
            btnEditarPedido.Text = "Editar";
            btnEditarPedido.UseVisualStyleBackColor = true;
            // 
            // btnRemoverPedido
            // 
            btnRemoverPedido.Location = new Point(350, 70);
            btnRemoverPedido.Name = "btnRemoverPedido";
            btnRemoverPedido.Size = new Size(83, 27);
            btnRemoverPedido.TabIndex = 8;
            btnRemoverPedido.Text = "Remover";
            btnRemoverPedido.UseVisualStyleBackColor = true;
            // 
            // listPedido
            // 
            listPedido.FormattingEnabled = true;
            listPedido.ItemHeight = 20;
            listPedido.Location = new Point(7, 104);
            listPedido.Name = "listPedido";
            listPedido.Size = new Size(425, 184);
            listPedido.TabIndex = 9;
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
            // textBox2
            // 
            textBox2.BackColor = SystemColors.Control;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.ForeColor = Color.FromArgb(0, 192, 0);
            textBox2.Location = new Point(78, 451);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(74, 20);
            textBox2.TabIndex = 6;
            textBox2.Text = "R$ 200,00";
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(358, 451);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(92, 36);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(260, 451);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(92, 36);
            btnGravar.TabIndex = 8;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            // 
            // TelaContaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(457, 495);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(textBox2);
            Controls.Add(label6);
            Controls.Add(gpbRegistroPedidos);
            Controls.Add(cmbGarcom);
            Controls.Add(label3);
            Controls.Add(cmbMesa);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TelaContaForm";
            Text = "Cadastro de Conta";
            gpbRegistroPedidos.ResumeLayout(false);
            gpbRegistroPedidos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private ComboBox cmbMesa;
        private Label label3;
        private ComboBox cmbGarcom;
        private GroupBox gpbRegistroPedidos;
        private ComboBox comboBox1;
        private Label label4;
        private Button btnAddPedido;
        private NumericUpDown numericUpDown1;
        private Label label5;
        private ListBox listPedido;
        private Button btnRemoverPedido;
        private Button btnEditarPedido;
        private Label label6;
        private TextBox textBox2;
        private Button btnCancelar;
        private Button btnGravar;
    }
}