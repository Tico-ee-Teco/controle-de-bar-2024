using ControleDeBar.Dominio.ModuloPedido;
using ControleDeBar.WinApp.Compartilhado.Extensions;

namespace ControleDeBar.WinApp.ModuloPedido
{
    public partial class TabelaPedidoControl : UserControl
    {
        public TabelaPedidoControl()
        {
            InitializeComponent();

            grid.Columns.AddRange(ObterColunas());

            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
        }

        public void AtualizarRegistros(List<Pedido> pedidos)
        {
            grid.Rows.Clear();

            foreach (Pedido p in pedidos)
                grid.Rows.Add(
                    p.Id,
                    p.Produto.Nome,                   
                    p.Qtde,
                    p.Preco
                 );
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Item", HeaderText = "Item" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Qtde", HeaderText = "Qtde" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Preco", HeaderText = "Preco" }
            };
        }
    }
}
