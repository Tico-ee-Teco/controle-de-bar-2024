using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.WinApp.Compartilhado;

namespace ControleDeBar.WinApp.ModuloProduto
{
    public class ControladorProduto : ControladorBase
    {
        TabelaProdutoControl tabelaProduto;

        IRepositorioProduto repositorioProduto;

        public override string TipoCadastro => "Produtos";

        public override string ToolTipAdicionar => "Cadastrar um novo produto";

        public override string ToolTipEditar => "Editar um produto existente";

        public override string ToolTipExcluir => "Excluir um produto existe";

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

            if (repositorioProduto.SelecionarTodos().Any(m => m.Nome.Equals(novoRegistro.Nome.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show(
                    $"Já existe um Produto com o nome \"{novoRegistro.Nome}\".",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            repositorioProduto.Adicionar(novoRegistro);

            CarregarRegistros();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"Produto {novoRegistro.Nome} foi adicionado com sucesso");
        }

        public override void Editar()
        {
            int idSelecionado = tabelaProduto.ObterRegistroSelecionado();

            Produto produtoSelecionado = repositorioProduto.SelecionarPorId(idSelecionado);

            if(produtoSelecionado == null)
            {
                MessageBox.Show(
                    "Você precisa selecionar um registro para executar esta ação!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            List<Produto> produtosCadastrados = repositorioProduto.SelecionarTodos();

            TelaProdutoForm telaProduto = new TelaProdutoForm(produtosCadastrados);

            telaProduto.Produto = produtoSelecionado;

            DialogResult resultado = telaProduto.ShowDialog();

            if (resultado != DialogResult.OK)
                return;

            Produto produtoEditado = telaProduto.Produto;

            Produto novoRegistro = telaProduto.Produto;

            if (repositorioProduto.SelecionarTodos().Any(m => m.Nome.Equals(produtoEditado.Nome.Trim(), StringComparison.OrdinalIgnoreCase) && m.Id != produtoSelecionado.Id))
            {
                MessageBox.Show(
                    $"Já existe um Produto com o nome \"{produtoEditado.Nome}\".",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            repositorioProduto.Editar(produtoSelecionado, produtoEditado);

            CarregarRegistros();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{produtoEditado.Nome}\" foi editado com sucesso!");
        }

        public override void Excluir()
        {
            int idSelecionado = tabelaProduto.ObterRegistroSelecionado();

            Produto produtoSelecionado = repositorioProduto.SelecionarPorId(idSelecionado);

            if(produtoSelecionado == null)
            {
                MessageBox.Show(
                    "Você precisa selecionar um registro para executar esta ação!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (repositorioProduto.ExisteContaComProduto(produtoSelecionado))
            {
                MessageBox.Show(
                    $"O Produto \"{produtoSelecionado.Nome}\" não pode ser excluído, pois está associado a uma conta.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            DialogResult resultado = MessageBox.Show(
                $"Tem certeza que deseja excluir o produto \"{produtoSelecionado.Nome}\"?",
                "Excluir Produto",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if(resultado != DialogResult.Yes)
                return;

            repositorioProduto.Excluir(produtoSelecionado);

            CarregarRegistros();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{produtoSelecionado.Nome}\" foi excluído com sucesso!");
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
            List<Produto> produtos = repositorioProduto.SelecionarTodos()!;

            tabelaProduto.AtualizarRegistros(produtos);

        }
    }
}
