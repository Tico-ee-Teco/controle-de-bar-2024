using ControleDeBar.Dominio;
using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.WinApp.Compartilhado.Extensions;

namespace ControleDeBar.WinApp.ModuloConta
{
    public partial class TelaVisualizarFaturamentoForm : Form
    {
        private List<Conta> contasFechadas;
        public TelaVisualizarFaturamentoForm(List<Conta> contasFechadas)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            this.contasFechadas = contasFechadas;

            gridFaturamento.ConfigurarGridSomenteLeitura();
            gridFaturamento.ConfigurarGridZebrado();
            gridFaturamento.Columns.AddRange(ObterColunas());

            Array valoresEnum = Enum.GetValues(typeof(TipoFaturamentoEnum));

            foreach (object valor in valoresEnum)
                cmbTiposFiltro.Items.Add(valor);

            cmbTiposFiltro.SelectedIndex = 0;
        }
        private void cmbTiposFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoFaturamentoEnum tipoSelecionado =
                (TipoFaturamentoEnum)cmbTiposFiltro.SelectedItem;

            if(tipoSelecionado == TipoFaturamentoEnum.Periodo)
            {

                lblDataInicial.Visible = true;
                lblDataFinal.Visible = true;

                txtDataInicial.Visible = true;
                txtDataInicial.MinDate = new DateTime(2020, 01, 01);
                txtDataInicial.MaxDate = DateTime.Today;
                txtDataInicial.Value = DateTime.Now.AddDays(-7);

                txtDataFinal.Visible = true;
                txtDataFinal.MinDate = txtDataInicial.MinDate;
                txtDataFinal.MaxDate = DateTime.Now;
                txtDataFinal.Value = DateTime.Today;
            }
            else
            {
                lblDataInicial.Visible = false;
                lblDataFinal.Visible = false;

                txtDataInicial.Visible = false;
                txtDataFinal.Visible = false;
            }

            gridFaturamento.Rows.Clear();
        }


        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            TipoFaturamentoEnum tipoSelecionado =
                (TipoFaturamentoEnum)cmbTiposFiltro.SelectedItem;

            Faturamento faturamento = new Faturamento(tipoSelecionado, contasFechadas);
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
               new DataGridViewTextBoxColumn { DataPropertyName = "Mesa", HeaderText = "Mesa"},
               new DataGridViewTextBoxColumn { DataPropertyName = "Garcom", HeaderText = "Garçom"},
               new DataGridViewTextBoxColumn { DataPropertyName = "ValorTotal", HeaderText = "Valor Total"},
               new DataGridViewTextBoxColumn { DataPropertyName = "Fechamento", HeaderText = "Fechamento"},

            };

            return colunas;
        }

    }
}
