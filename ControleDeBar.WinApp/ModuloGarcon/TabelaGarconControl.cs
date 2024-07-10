using ControleDeBar.Dominio.ModuloGarçon;
using ControleDeBar.WinApp.Compartilhado.Extensions;

namespace ControleDeBar.WinApp.ModuloGarcon
{
    public partial class TabelaGarconControl : UserControl
    {
        public TabelaGarconControl()
        {
            InitializeComponent();

            grid.Columns.AddRange(ObterColunas());

            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
        }

        public void AtualizarRegistros(List<Garcom> garcoms)
        {
            grid.Rows.Clear();

            foreach (Garcom p in garcoms)
                grid.Rows.Add(
                    p.Id,
                    p.Nome                  
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome" },             
            };
        }
    }
}
