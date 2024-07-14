namespace ControleDeBar.WinApp
{
    partial class TelaPrincipalForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            CadastroMenuItem = new ToolStripMenuItem();
            contasMenuItem = new ToolStripMenuItem();
            produtosMenuItem = new ToolStripMenuItem();
            garçonsToolStripMenuItem = new ToolStripMenuItem();
            mesasToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            statusLabelPrincipal = new ToolStripStatusLabel();
            toolStrip1 = new ToolStrip();
            btnAdicionar = new ToolStripButton();
            btnEditar = new ToolStripButton();
            btnExcluir = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnFecharConta = new ToolStripButton();
            btnRelatorio = new ToolStripButton();
            btnFiltrar = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            lblTipoCadastro = new ToolStripLabel();
            toolTip1 = new ToolTip(components);
            pnlRegistros = new Panel();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { CadastroMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(923, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // CadastroMenuItem
            // 
            CadastroMenuItem.DropDownItems.AddRange(new ToolStripItem[] { contasMenuItem, produtosMenuItem, garçonsToolStripMenuItem, mesasToolStripMenuItem });
            CadastroMenuItem.Name = "CadastroMenuItem";
            CadastroMenuItem.Size = new Size(66, 20);
            CadastroMenuItem.Text = "Cadastro";
            // 
            // contasMenuItem
            // 
            contasMenuItem.Name = "contasMenuItem";
            contasMenuItem.Size = new Size(122, 22);
            contasMenuItem.Text = "Contas";
            contasMenuItem.Click += contasMenuItem_Click;
            // 
            // produtosMenuItem
            // 
            produtosMenuItem.Name = "produtosMenuItem";
            produtosMenuItem.Size = new Size(122, 22);
            produtosMenuItem.Text = "Produtos";
            produtosMenuItem.Click += produtosMenuItem_Click;
            // 
            // garçonsToolStripMenuItem
            // 
            garçonsToolStripMenuItem.Name = "garçonsToolStripMenuItem";
            garçonsToolStripMenuItem.Size = new Size(122, 22);
            garçonsToolStripMenuItem.Text = "Garçons";
            garçonsToolStripMenuItem.Click += garçonsToolStripMenuItem_Click;
            // 
            // mesasToolStripMenuItem
            // 
            mesasToolStripMenuItem.Name = "mesasToolStripMenuItem";
            mesasToolStripMenuItem.Size = new Size(122, 22);
            mesasToolStripMenuItem.Text = "Mesas";
            mesasToolStripMenuItem.Click += mesasToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusLabelPrincipal });
            statusStrip1.Location = new Point(0, 503);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(923, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusLabelPrincipal
            // 
            statusLabelPrincipal.Name = "statusLabelPrincipal";
            statusLabelPrincipal.Size = new Size(141, 17);
            statusLabelPrincipal.Text = "Visualizando 0 registro(s).";
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnAdicionar, btnEditar, btnExcluir, toolStripSeparator1, btnFecharConta, btnRelatorio, btnFiltrar, toolStripSeparator2, lblTipoCadastro });
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(923, 25);
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnAdicionar
            // 
            btnAdicionar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnAdicionar.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdicionar.Image = Properties.Resources.btnAdicionar;
            btnAdicionar.ImageTransparentColor = Color.Magenta;
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(23, 22);
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // btnEditar
            // 
            btnEditar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnEditar.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEditar.Image = Properties.Resources.btnEditar;
            btnEditar.ImageTransparentColor = Color.Magenta;
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(23, 22);
            btnEditar.Text = "Editar";
            btnEditar.Click += btnEditar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnExcluir.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExcluir.Image = Properties.Resources.btnExcluir;
            btnExcluir.ImageTransparentColor = Color.Magenta;
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(23, 22);
            btnExcluir.Text = "Excluir";
            btnExcluir.Click += btnExcluir_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // btnFecharConta
            // 
            btnFecharConta.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnFecharConta.Image = Properties.Resources.btnFecharConta;
            btnFecharConta.ImageTransparentColor = Color.Magenta;
            btnFecharConta.Name = "btnFecharConta";
            btnFecharConta.Size = new Size(23, 22);
            btnFecharConta.Text = "Fechar Conta";
            btnFecharConta.Click += btnFecharConta_Click;
            // 
            // btnRelatorio
            // 
            btnRelatorio.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnRelatorio.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRelatorio.Image = Properties.Resources.btnVisualizar;
            btnRelatorio.ImageTransparentColor = Color.Magenta;
            btnRelatorio.Name = "btnRelatorio";
            btnRelatorio.Size = new Size(23, 22);
            btnRelatorio.Text = "Relatorio";
            btnRelatorio.Click += btnRelatorio_Click;
            // 
            // btnFiltrar
            // 
            btnFiltrar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnFiltrar.Image = Properties.Resources.btnFiltrar;
            btnFiltrar.ImageTransparentColor = Color.Magenta;
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(23, 22);
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // lblTipoCadastro
            // 
            lblTipoCadastro.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTipoCadastro.Name = "lblTipoCadastro";
            lblTipoCadastro.Size = new Size(96, 22);
            lblTipoCadastro.Text = "Tipo de Cadastro";
            // 
            // pnlRegistros
            // 
            pnlRegistros.Dock = DockStyle.Fill;
            pnlRegistros.Location = new Point(0, 49);
            pnlRegistros.Name = "pnlRegistros";
            pnlRegistros.Size = new Size(923, 454);
            pnlRegistros.TabIndex = 4;
            // 
            // TelaPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(923, 525);
            Controls.Add(pnlRegistros);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "TelaPrincipalForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Controle de Bar 1.0";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private StatusStrip statusStrip1;
        private ToolStrip toolStrip1;
        private ToolStripLabel lblTipoCadastro;
        private ToolTip toolTip1;
        private ToolStripMenuItem CadastroMenuItem;
        private ToolStripMenuItem produtosMenuItem;
        private ToolStripButton btnAdicionar;
        private ToolStripButton btnEditar;
        private ToolStripButton btnExcluir;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnRelatorio;
        private ToolStripStatusLabel statusLabelPrincipal;
        private Panel pnlRegistros;
        private ToolStripMenuItem garçonsToolStripMenuItem;
        private ToolStripMenuItem mesasToolStripMenuItem;
        private ToolStripMenuItem contasMenuItem;
        private ToolStripButton btnFiltrar;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btnFecharConta;
    }
}
