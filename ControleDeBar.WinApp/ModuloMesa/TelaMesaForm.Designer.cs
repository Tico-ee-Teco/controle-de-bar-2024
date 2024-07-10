namespace ControleDeBar.WinApp.ModuloMesa
{
    partial class TelaMesaForm
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
            txtID = new TextBox();
            txtNumero = new TextBox();
            chkOcupada = new CheckBox();
            btnGravar = new Button();
            btnCancelar = new Button();
            id = new Label();
            numero12345 = new Label();
            SuspendLayout();
            // 
            // txtID
            // 
            txtID.Location = new Point(110, 34);
            txtID.Name = "txtID";
            txtID.Size = new Size(100, 23);
            txtID.TabIndex = 0;
            txtID.Visible = false;
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(110, 79);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(100, 23);
            txtNumero.TabIndex = 1;
            // 
            // chkOcupada
            // 
            chkOcupada.AutoSize = true;
            chkOcupada.Enabled = false;
            chkOcupada.Location = new Point(12, 122);
            chkOcupada.Name = "chkOcupada";
            chkOcupada.Size = new Size(105, 19);
            chkOcupada.TabIndex = 2;
            chkOcupada.Text = "Mesa Ocupada";
            chkOcupada.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.BackColor = Color.Lime;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Font = new Font("Segoe UI", 11.25F);
            btnGravar.Location = new Point(179, 161);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(112, 43);
            btnGravar.TabIndex = 3;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = false;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(192, 0, 0);
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Font = new Font("Segoe UI", 11.25F);
            btnCancelar.Location = new Point(297, 161);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(112, 43);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // id
            // 
            id.AutoSize = true;
            id.Font = new Font("Segoe UI", 14F);
            id.Location = new Point(65, 34);
            id.Name = "id";
            id.Size = new Size(39, 25);
            id.TabIndex = 5;
            id.Text = "ID :";
            // 
            // numero12345
            // 
            numero12345.AutoSize = true;
            numero12345.Font = new Font("Segoe UI", 14F);
            numero12345.Location = new Point(12, 79);
            numero12345.Name = "numero12345";
            numero12345.Size = new Size(90, 25);
            numero12345.TabIndex = 6;
            numero12345.Text = "Numero :";
            // 
            // TelaMesaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(415, 216);
            Controls.Add(numero12345);
            Controls.Add(id);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(chkOcupada);
            Controls.Add(txtNumero);
            Controls.Add(txtID);
            Name = "TelaMesaForm";
            Text = "TelaMesaForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtID;
        private TextBox txtNumero;
        private CheckBox chkOcupada;
        private Button btnGravar;
        private Button btnCancelar;
        private Label id;
        private Label numero12345;
    }
}