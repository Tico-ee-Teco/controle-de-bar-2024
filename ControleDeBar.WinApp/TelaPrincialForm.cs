using ControleDeBar.Dominio.ModuloPedido;
using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.Infra.Compartilhado;
using ControleDeBar.Infra.ModuloPedido;
using ControleDeBar.Infra.ModuloProduto;
using ControleDeBar.WinApp.Compartilhado;
using ControleDeBar.WinApp.ModuloPedido;
using ControleDeBar.WinApp.ModuloProduto;

namespace ControleDeBar.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        ControladorBase controlador;

        IRepositorioProduto repositorioProduto;
        //IRepositorioPedido repositorioPedido;

        public static TelaPrincipalForm Instancia { get; private set; }

        public TelaPrincipalForm()
        {
            InitializeComponent();

            lblTipoCadastro.Text = string.Empty;
            Instancia = this;

            ControleDeBarDbContext dbContext = new ControleDeBarDbContext();

            repositorioProduto = new RepositorioProduto(dbContext);
            //repositorioPedido = new RepositorioPedido(dbContext);

        }

        private void produtosMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorProduto(repositorioProduto);

            ConfigurarTelaPrincipal(controlador);
        }
       

        public void AtualizarRodape(string texto)
        {
            statusLabelPrincipal.Text = texto;
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            controlador.Adicionar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }


        //private void btnVisualizar_Click(object sender, EventArgs e)
        //{
        //    if (controlador is IControladorVisualizavel controladorVisualizavel)
        //        controladorVisualizavel.VisualizarTeste();
        //}

        private void ConfigurarTelaPrincipal(ControladorBase controladorSelecionado)
        {
            lblTipoCadastro.Text = "Cadastro de " + controladorSelecionado.TipoCadastro;

            ConfigurarToolBox(controladorSelecionado);
            ConfigurarListagem(controladorSelecionado);
        }

        private void ConfigurarToolBox(ControladorBase controladorSelecionado)
        {
            btnAdicionar.Enabled = controladorSelecionado is ControladorBase;
            btnEditar.Enabled = controladorSelecionado is ControladorBase;
            btnExcluir.Enabled = controladorSelecionado is ControladorBase;

            //btnVisualizar.Enabled = controladorSelecionado is IControladorVisualizavel;

            ConfigurarToolTips(controladorSelecionado);
        }

        private void ConfigurarToolTips(ControladorBase controladorSelecionado)
        {
            btnAdicionar.ToolTipText = controladorSelecionado.ToolTipAdicionar;
            btnEditar.ToolTipText = controladorSelecionado.ToolTipEditar;
            btnExcluir.ToolTipText = controladorSelecionado.ToolTipExcluir;

            //if (controladorSelecionado is IControladorVisualizavel controladorVisualizavel)
            //    btnVisualizar.ToolTipText = controladorVisualizavel.ToolTipVisualizar;

        }

        private void ConfigurarListagem(ControladorBase controladorSelecionado)
        {
            UserControl listagemContato = controladorSelecionado.ObterListagem();
            listagemContato.Dock = DockStyle.Fill;

            pnlRegistros.Controls.Clear();
            pnlRegistros.Controls.Add(listagemContato);
        }

    }
}
