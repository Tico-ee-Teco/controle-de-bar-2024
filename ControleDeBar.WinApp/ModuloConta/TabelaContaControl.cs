using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.WinApp.Compartilhado.Extensions;

namespace ControleDeBar.WinApp.ModuloConta
{
    public partial class TabelaContaControl : UserControl
    {
        //public TabelaContaControl()
        //{
        //    InitializeComponent();

        //    grid.Columns.AddRange(ObterColunas());

        //    grid.ConfigurarGridSomenteLeitura();
        //    grid.ConfigurarGridZebrado();
        //}

        //public void AtualizarRegistros(List<Conta> contas)
        //{
        //    grid.Rows.Clear();            

        //    foreach (Conta c in contas)
        //    {
        //        string statusConta = c.ContaPaga ? "Paga" : "Não Paga";

        //        grid.Rows.Add(
        //            c.Id,
        //            c.Mesa.Numero,
        //            c.Garcom.Nome,
        //            statusConta                                      
        //        );

        //    }
        //}

        //public int ObterRegistroSelecionado()
        //{
        //    return grid.SelecionarId();
        //}       

        //private DataGridViewColumn[] ObterColunas()
        //{
        //    return new DataGridViewColumn[]
        //    {
        //        new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id" },
        //        new DataGridViewTextBoxColumn { DataPropertyName = "Mesa", HeaderText = "Número da Mesa" },
        //        new DataGridViewTextBoxColumn { DataPropertyName = "Garcom", HeaderText = "Nome do Garçom" },
        //        new DataGridViewTextBoxColumn { DataPropertyName = "ContaPaga", HeaderText = "Status da Conta" }

        //    };
        //}
        public TabelaContaControl()
        {
            InitializeComponent();

            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id" },
                new DataGridViewTextBoxColumn { Name = "Abertura", HeaderText = "Abertura", },
                new DataGridViewTextBoxColumn { Name = "Mesa.Numero", HeaderText = "Mesa" },
                new DataGridViewTextBoxColumn { Name = "Garcom.Nome", HeaderText = "Garçom" },
                new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status" },
            };

            return colunas;
        }

        public int ObterRegistroSelecionado()
        {
            return grid.SelecionarId();
        }

        public void AtualizarRegistros(List<Conta> contas)
        {
            grid.Rows.Clear();

            foreach (Conta conta in contas)
            {
                string statusConta = conta.ContaPaga ? "Aberta" : "Fechada";

                grid.Rows.Add(
                    conta.Id,
                    conta.Abertura.ToShortDateString(),
                    conta.Mesa.Numero,
                    conta.Garcom.Nome,
                    statusConta
                );
            }
        }
    }
}
