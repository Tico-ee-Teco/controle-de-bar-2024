namespace ControleDeBar.WinApp.ModuloPedido
{
    partial class TelaPedidoForm
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
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            cmbItem = new ComboBox();
            label5 = new Label();
            nudQtde = new NumericUpDown();
            label6 = new Label();
            nudPreco = new NumericUpDown();
            btnCancelar = new Button();
            btnGravar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudQtde).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPreco).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Enabled = false;
            label1.Location = new Point(32, 38);
            label1.Name = "label1";
            label1.Size = new Size(25, 20);
            label1.TabIndex = 0;
            label1.Text = "Id:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(63, 35);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(41, 27);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(276, 38);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 2;
            label2.Text = "N Mesa:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(344, 35);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 27);
            textBox2.TabIndex = 3;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(194, 35);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(69, 27);
            textBox3.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(118, 38);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 4;
            label3.Text = "N Pedido:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 97);
            label4.Name = "label4";
            label4.Size = new Size(42, 20);
            label4.TabIndex = 6;
            label4.Text = "Item:";
            // 
            // cmbItem
            // 
            cmbItem.FormattingEnabled = true;
            cmbItem.Location = new Point(63, 94);
            cmbItem.Name = "cmbItem";
            cmbItem.Size = new Size(381, 28);
            cmbItem.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 146);
            label5.Name = "label5";
            label5.Size = new Size(45, 20);
            label5.TabIndex = 8;
            label5.Text = "Qtde:";
            // 
            // nudQtde
            // 
            nudQtde.Location = new Point(63, 144);
            nudQtde.Name = "nudQtde";
            nudQtde.Size = new Size(64, 27);
            nudQtde.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(174, 146);
            label6.Name = "label6";
            label6.Size = new Size(46, 20);
            label6.TabIndex = 10;
            label6.Text = "Preço";
            // 
            // nudPreco
            // 
            nudPreco.DecimalPlaces = 2;
            nudPreco.Location = new Point(226, 144);
            nudPreco.Name = "nudPreco";
            nudPreco.Size = new Size(89, 27);
            nudPreco.TabIndex = 11;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(352, 197);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(92, 36);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(254, 197);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(92, 36);
            btnGravar.TabIndex = 12;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            // 
            // TelaPedidoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(454, 256);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(nudPreco);
            Controls.Add(label6);
            Controls.Add(nudQtde);
            Controls.Add(label5);
            Controls.Add(cmbItem);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TelaPedidoForm";
            Text = "TelaPedidoForm";
            ((System.ComponentModel.ISupportInitialize)nudQtde).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPreco).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label3;
        private Label label4;
        private ComboBox cmbItem;
        private Label label5;
        private NumericUpDown nudQtde;
        private Label label6;
        private NumericUpDown nudPreco;
        private Button btnCancelar;
        private Button btnGravar;
    }
}