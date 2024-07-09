namespace ControleDeBar.WinApp.ModuloGarcon
{
    partial class TelaGarconForm
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
            txtNome = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnGravar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // txtID
            // 
            txtID.Location = new Point(85, 41);
            txtID.Name = "txtID";
            txtID.Size = new Size(100, 23);
            txtID.TabIndex = 0;
            txtID.Visible = false;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(85, 83);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(100, 23);
            txtNome.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(34, 41);
            label1.Name = "label1";
            label1.Size = new Size(34, 25);
            label1.TabIndex = 2;
            label1.Text = "ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(1, 76);
            label2.Name = "label2";
            label2.Size = new Size(67, 25);
            label2.TabIndex = 3;
            label2.Text = "Nome:";
            // 
            // btnGravar
            // 
            btnGravar.BackColor = Color.Lime;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Font = new Font("Segoe UI", 11.25F);
            btnGravar.ForeColor = Color.Black;
            btnGravar.Location = new Point(198, 151);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(93, 64);
            btnGravar.TabIndex = 4;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = false;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(192, 0, 0);
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Font = new Font("Segoe UI", 11.25F);
            btnCancelar.Location = new Point(297, 151);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(93, 64);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // TelaGarconForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(402, 227);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtNome);
            Controls.Add(txtID);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "TelaGarconForm";
            Text = "Cadastro de Garcon";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtID;
        private TextBox txtNome;
        private Label label1;
        private Label label2;
        private Button btnGravar;
        private Button btnCancelar;
    }
}