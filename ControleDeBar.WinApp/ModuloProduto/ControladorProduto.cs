using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.WinApp.Compartilhado;

namespace ControleDeBar.WinApp.ModuloProduto
{
    public class ControladorProduto : ControladorBase
    {
        public override string TipoCadastro => "Produtos";

        public override string ToolTipAdicionar => "Cadastrar um novo produto";

        public override string ToolTipEditar => "Editar um produto existente";

        public override string ToolTipExcluir => "Excluir um produto existe";

        TabelaProdutoControl tabelaProduto;

        IRepositorioProduto repositorioProduto;

        public ControladorProduto(IRepositorioProduto repositorioProduto)
        {
            this.repositorioProduto = repositorioProduto;            
        }

        public override void Adicionar()
        {
            List<Produto> produtosCadastrados = repositorioProduto.SelecionarTodos();

            TelaProdutoForm telaProduto = new TelaProdutoForm(produtosCadastrados);

            DialogResult resultado = telaProduto.ShowDialog(); ;

            if(resultado != DialogResult.OK)
                return;

            Produto novoRegistro = telaProduto.Produto;

            repositorioProduto.Adicionar(novoRegistro);

            CarregarRegistros();

            TelaPrincipalForm.Instancia.AtualizarRodape($"Produto {novoRegistro.Nome} foi adicionado com sucesso");
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
            if (tabelaProduto == null)
                tabelaProduto = new TabelaProdutoControl();

            CarregarRegistros();

            return tabelaProduto;
        }
        public override void CarregarRegistros()
        {
            List<Produto> produtos = repositorioProduto.SelecionarTodos();

            tabelaProduto.AtualizarRegistros(produtos);
        }
    }
}
