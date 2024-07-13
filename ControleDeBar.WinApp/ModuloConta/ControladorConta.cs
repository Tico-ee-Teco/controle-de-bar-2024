using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloGarçon;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.WinApp.Compartilhado;

namespace ControleDeBar.WinApp.ModuloConta
{
    public class ControladorConta : ControladorBase, IControladorFiltravel, IControladorVisualizavel
    {
        TabelaContaControl tabelaConta;
        IRepositorioConta repositorioConta;
        IRepositorioProduto repositorioProduto;
        IRepositorioMesa repositorioMesa;
        IRepositorioGarcon repositorioGarcon;
        public override string TipoCadastro => "Conta";

        public override string ToolTipAdicionar => "Cadastrar uma nova conta";

        public override string ToolTipEditar => "Editar uma conta existente";

        public override string ToolTipExcluir => "Excluir uma conta existente";

        public string ToolTipFiltrar => "Filtrar contas";

        public string ToolTipVisualizar => "Visualizar Faturamento";

        public ControladorConta(IRepositorioConta repositorioConta, IRepositorioProduto repositorioProduto, IRepositorioMesa repositorioMesa, IRepositorioGarcon repositorioGarcon)
        {
            this.repositorioConta = repositorioConta;
            this.repositorioProduto = repositorioProduto;
            this.repositorioMesa = repositorioMesa;
            this.repositorioGarcon = repositorioGarcon;
        }
        public override void Adicionar()
        {
            List<Produto> produtosCadastrados = repositorioProduto.SelecionarTodos();
            List<Mesa> mesasCadastradas = repositorioMesa.SelecionarTodos();
            List<Garcom> garconsCadastrados = repositorioGarcon.SelecionarTodos();

            TelaContaForm telaConta = new TelaContaForm(mesasCadastradas,garconsCadastrados,produtosCadastrados );

            DialogResult resultado = telaConta.ShowDialog();

            if (resultado != DialogResult.OK)
                return;

            Conta novaConta = telaConta.Conta;

            repositorioConta.Adicionar(novaConta);

            CarregarRegistros();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"Conta: {novaConta.Id} inserida com sucesso");
        }

        public override void Editar()
        {
            AtualizarProduto();
        }        

        public override void Excluir()
        {
            FecharConta();
        }
        private void AtualizarProduto()
        {
            List<Mesa> mesas = repositorioMesa.SelecionarTodos();
            List<Garcom> garcons = repositorioGarcon.SelecionarTodos();
            List<Produto> produtos = repositorioProduto.SelecionarTodos();

            int idSelecionado = tabelaConta.ObterRegistroSelecionado();

            Conta contaSelecionada = repositorioConta.SelecionarPorId(idSelecionado);

            if (contaSelecionada == null)
            {
                MessageBox.Show(
                    "Você precisa selecionar um registro para executar esta ação!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            TelaContaForm telaConta = new TelaContaForm(mesas, garcons, produtos);

            telaConta.Conta = contaSelecionada;

            DialogResult resultado = telaConta.ShowDialog();

            if (resultado != DialogResult.OK)
                return;

            Conta contaAtualizada = telaConta.Conta;

            List<Pedido> pedidosRemovidos = telaConta.PedidosRemovidos;

            repositorioConta.AtualizarPedidos(contaAtualizada, pedidosRemovidos);

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"Conta: {contaAtualizada.Id} atualizada com sucesso");
        }

        private void FecharConta()
        {
            int idSelecionado = tabelaConta.ObterRegistroSelecionado();

            Conta contaSelecionada = repositorioConta.SelecionarPorId(idSelecionado);

            if (contaSelecionada == null)
            {
                MessageBox.Show(
                    "Selecione uma conta para fechar!",
                    "Fechar Conta",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);

                return;
            }

            if(!contaSelecionada.ContaPaga)
            {
                MessageBox.Show(
                    "Conta não pode ser fechada, pois ainda não foi paga!",
                    "Fechar Conta",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);

                return;
            }

            TelaFechamentoContaForm telaFechamentoConta = 
                new TelaFechamentoContaForm(contaSelecionada);

            DialogResult resultado = telaFechamentoConta.ShowDialog();

            if(resultado != DialogResult.OK)
                return;

            Conta contaFechada = telaFechamentoConta.Conta;

            repositorioConta.AtualizarStatus(contaFechada);

            CarregarRegistros();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"Conta: {contaSelecionada.Id} fechada com sucesso");
        }

        public void Filtrar()
        {
            TelaFiltroContasForm telaFiltro = new TelaFiltroContasForm();

            DialogResult dialogResult = telaFiltro.ShowDialog();

            if (dialogResult != DialogResult.OK) return;

            TipoFiltroContaEnum filtroSelecionado = telaFiltro.FiltroSelecionado;

            List<Conta> contasFiltradas;

            switch (filtroSelecionado)
            {
                case TipoFiltroContaEnum.Abertas:
                    contasFiltradas = repositorioConta.SelecionarContasEmAberto();
                    break;

                case TipoFiltroContaEnum.Fechadas:
                    contasFiltradas = repositorioConta.SelecionarContasFechadas();
                    break;

                default:
                    contasFiltradas = repositorioConta.SelecionarContas();
                    break;
            }

            tabelaConta.AtualizarRegistros(contasFiltradas);
        }

        public void Visualizar()
        {
            List<Conta> contasFechadas = repositorioConta.SelecionarContasFaturamento();

            TelaVisualizarFaturamentoForm telaFaturamento =
                new TelaVisualizarFaturamentoForm(contasFechadas);

            telaFaturamento.ShowDialog();
        }

        public override UserControl ObterListagem()
        {
            if (tabelaConta == null)
                tabelaConta = new TabelaContaControl();

            CarregarRegistros();

            return tabelaConta;
        }
        public override void CarregarRegistros()
        {
            List<Conta> contas = repositorioConta.SelecionarTodos()!;

            tabelaConta.AtualizarRegistros(contas);
        }

       

       
    }
}
