using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloGarçon;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.WinApp.Compartilhado;

namespace ControleDeBar.WinApp.ModuloConta
{
    public class ControladorConta : ControladorBase
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
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
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
