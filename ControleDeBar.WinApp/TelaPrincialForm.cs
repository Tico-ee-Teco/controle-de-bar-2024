using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloGar�on;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.Infra.Compartilhado;
using ControleDeBar.Infra.ModuloConta;
using ControleDeBar.Infra.ModuloGarcon;
using ControleDeBar.Infra.ModuloProduto;
using ControleDeBar.Infra.ModuloMesa;
using ControleDeBar.WinApp.Compartilhado;
using ControleDeBar.WinApp.ModuloConta;
using ControleDeBar.WinApp.ModuloGarcon;
using ControleDeBar.WinApp.ModuloProduto;
using ControleDeBar.WinApp.ModuloMesa;

namespace ControleDeBar.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        public static TelaPrincipalForm Instancia { get; private set; }

        ControladorBase controlador;
        ControleDeBarDbContext dbContext;

        IRepositorioMesa repositorioMesa;
        IRepositorioGarcon repositorioGarcom;
        IRepositorioProduto repositorioProduto;
        IRepositorioConta repositorioConta;

        public TelaPrincipalForm()
        {
            InitializeComponent();
            Instancia = this;

            dbContext = new ControleDeBarDbContext();

            repositorioMesa = new RepositorioMesa(dbContext);
            repositorioGarcom = new RepositorioGarcon(dbContext);
            repositorioProduto = new RepositorioProduto(dbContext);
            repositorioConta = new RepositorioConta(dbContext);

            DateTime dataAtual = DateTime.Now;

            AtualizarRodape($"Hoje � {dataAtual.ToShortDateString()}.");
        }

        public void AtualizarRodape(string texto)
        {
            statusLabelPrincipal.Text = texto;
        }

        private void mesasMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorMesa(repositorioMesa);

            ConfigurarTelaPrincipal(controlador);
        }

        private void garconsMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorGarcon(repositorioGarcom);

            ConfigurarTelaPrincipal(controlador);
        }

        private void produtosMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorProduto(repositorioProduto);

            ConfigurarTelaPrincipal(controlador);
        }

        private void contasMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorConta(
                repositorioProduto,
                repositorioMesa,
                repositorioGarcom,
                repositorioConta
            );

            ConfigurarTelaPrincipal(controlador);
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

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (controlador is IControladorFiltravel cF)
                cF.Filtrar();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            if (controlador is IControladorVisualizavel cV)
                cV.Visualizar();
        }

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

            btnFiltrar.Enabled = controladorSelecionado is IControladorFiltravel;
            btnVisualizar.Enabled = controladorSelecionado is IControladorVisualizavel;

            ConfigurarIcones(controladorSelecionado);
            ConfigurarToolTips(controladorSelecionado);
        }

        private void ConfigurarToolTips(ControladorBase controladorSelecionado)
        {
            btnAdicionar.ToolTipText = controladorSelecionado.ToolTipAdicionar;
            btnEditar.ToolTipText = controladorSelecionado.ToolTipEditar;
            btnExcluir.ToolTipText = controladorSelecionado.ToolTipExcluir;

            btnAdicionar.Text = "Adicionar";
            btnEditar.Text = "Editar";
            btnExcluir.Text = "Excluir";

            if (controlador is IControladorFiltravel controladorFiltravel)
                btnFiltrar.ToolTipText = controladorFiltravel.ToolTipFiltrar;

            if (controlador is IControladorVisualizavel controladorVisualizavel)
                btnVisualizar.ToolTipText = controladorVisualizavel.ToolTipVisualizar;

            if (controlador is ControladorConta controladorConta)
            {
                btnAdicionar.Text = controladorConta.ToolTipAdicionar;
                btnEditar.Text = controladorConta.ToolTipEditar;
                btnExcluir.Text = controladorConta.ToolTipExcluir;
            }
        }

        private void ConfigurarIcones(ControladorBase controladorSelecionado)
        {
            btnEditar.Image = Properties.Resources.btnEditar;
            btnExcluir.Image = Properties.Resources.btnExcluir;

            if (controlador is ControladorConta controladorConta)
            {
                btnEditar.Image = controladorConta.IconeAdicionarProduto;
                btnExcluir.Image = controladorConta.IconeFecharConta;
            }
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
