using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloPedido;
using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.Infra.ModuloPedido;
using ControleDeBar.WinApp.Compartilhado;
using ControleDeBar.WinApp.ModuloPedido;

namespace ControleDeBar.WinApp.ModuloConta
{
    public class ControladorConta : ControladorBase
    {
        TabelaContaControl tabelaConta;
        IRepositorioConta repositorioConta;
        IRepositorioProduto repositorioProduto;
        public override string TipoCadastro => "Conta";

        public override string ToolTipAdicionar => "Cadastrar uma nova conta";

        public override string ToolTipEditar => "Editar uma conta existente";

        public override string ToolTipExcluir => "Excluir uma conta existente";

        public ControladorConta(IRepositorioConta repositorioConta, IRepositorioProduto repositorioProduto)
        {
            this.repositorioConta = repositorioConta;
            this.repositorioProduto = repositorioProduto;
        }
        public override void Adicionar()
        {
            List<Produto> produtosCadastrados = repositorioProduto.SelecionarTodos();
            //List<Mesa> mesasCadastradas = repositorioConta.SelecionarTodos();

            //TelaContaForm telaConta = new TelaContaForm(produtosCadastrados);

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
