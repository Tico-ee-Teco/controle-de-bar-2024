using ControleDeBar.Dominio.ModuloPedido;
using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.WinApp.Compartilhado;

namespace ControleDeBar.WinApp.ModuloPedido
{
    internal class ControladorPedido : ControladorBase
    {
        TabelaPedidoControl tabelaPedido;

        IRepositorioPedido repositorioPedido;
        IRepositorioProduto repositorioProduto;
        public override string TipoCadastro => "Pedidos";

        public override string ToolTipAdicionar => "Cadastrar um novo pedido";

        public override string ToolTipEditar => "Editar um pedido existe";

        public override string ToolTipExcluir => "Excluir um pedido existe";

        public ControladorPedido(IRepositorioPedido repositorioPedido, IRepositorioProduto repositorioProduto)
        {
            this.repositorioPedido = repositorioPedido;
            this.repositorioProduto = repositorioProduto;
        }
        
        public override void Adicionar()
        { 
            List<Pedido> pedidosCadastrados = repositorioPedido.SelecionarTodos();
            List<Produto> produtosCadastrados = repositorioProduto.SelecionarTodos();
 
            TelaPedidoForm telaPedido = new TelaPedidoForm(pedidosCadastrados, produtosCadastrados);

            DialogResult resultado = telaPedido.ShowDialog(); ;

            if (resultado != DialogResult.OK)
                return;

            Pedido novoRegistro = telaPedido.Pedido;

            repositorioPedido.Adicionar(novoRegistro);

            CarregarRegistros();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"Pedido {novoRegistro.NumeroPedido} foi adicionado com sucesso");
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
            if (tabelaPedido == null)
                tabelaPedido = new TabelaPedidoControl();

            CarregarRegistros();

            return tabelaPedido;
        }
        public override void CarregarRegistros()
        {
            List<Pedido> pedidos = repositorioPedido.SelecionarTodos()!;

            tabelaPedido.AtualizarRegistros(pedidos);
        }
    }
}
