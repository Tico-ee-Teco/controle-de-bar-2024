using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.WinApp.Compartilhado.Extensions;

namespace ControleDeBar.WinApp.ModuloConta
{
    public partial class TabelaContaControl : UserControl
    {
        public TabelaContaControl()
        {
            InitializeComponent();

            grid.Columns.AddRange(ObterColunas());

            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
        }

        public void AtualizarRegistros(List<Conta> contas)
        {
            grid.Rows.Clear();            

            foreach (Conta c in contas)
                grid.Rows.Add(
                    c.Id,
                    c.Mesa,
                    c.Garcom,                                       
                    c.ValorTotal
                   
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Mesa", HeaderText = "Número da Mesa" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Garcom", HeaderText = "Nome do Garçom" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Produto", HeaderText = "Produto" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Quantidade", HeaderText = "Quantidade" },
                new DataGridViewTextBoxColumn { DataPropertyName = "ValorTotal", HeaderText = "Total a Pagar R$" }
            };
        }
    }
}
