using ControleDeBar.WinApp.Compartilhado.Extensions;
using ControleDeBar.Dominio.ModuloProduto;

namespace ControleDeBar.WinApp.ModuloProduto
{
    public partial class TabelaProdutoControl : UserControl
    {
        public TabelaProdutoControl()
        {
            InitializeComponent();

            grid.Columns.AddRange(ObterColunas());

            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
        }

        public void AtualizarRegistros(List<Produto> produtos)
        {
            grid.Rows.Clear();

            foreach (Produto p in produtos)
                grid.Rows.Add(p.Id, p.Nome, p.Valor);
        }

        public int ObterRegistroSelecionado()
        {
            return grid.SelecionarId();
        }

        private DataGridViewColumn[] ObterColunas()
        {
            return new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Valor", HeaderText = "Valor" }
            };
        }
    }
}
