
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.WinApp.Compartilhado.Extensions;

namespace ControleDeBar.WinApp.ModuloMesa
{
    public partial class TabelaMesaControl : UserControl
    {
        public TabelaMesaControl()
        {
            InitializeComponent();

            grid.Columns.AddRange(ObterColunas());

            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
        }

        public void AtualizarRegistros(List<Mesa> mesas)
        {
            grid.Rows.Clear();

            foreach (Mesa mesa in mesas)
            {
                string status = mesa.Ocupada ? "Ocupada" : "Livre";

                grid.Rows.Add(
                    mesa.Id,
                    mesa.Numero,
                    status
                 );
            }
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Ocupada", HeaderText = "Ocupada" },
            };
        }
    }
}
