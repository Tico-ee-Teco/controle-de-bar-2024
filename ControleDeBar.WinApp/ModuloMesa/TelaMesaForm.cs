using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.WinApp.Compartilhado.Extensions;

namespace ControleDeBar.WinApp.ModuloMesa
{
    public partial class TelaMesaForm : Form
    {
        private Mesa mesa;
        
        public Mesa Mesa
        {
            get => mesa;
            set
            {
                txtID.Text = value.Id.ToString();
                txtNumero.Text = value.Numero;
                chkOcupada.Checked = value.Ocupada;
            }

        }
        private List<Mesa> Mesascadastradas;
        public TelaMesaForm(List<Mesa> mesascadastradas)
        {
            InitializeComponent();
            this.ConfigurarDialog();

            this.Mesascadastradas = mesascadastradas;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string numero = txtNumero.Text;
            mesa = new Mesa(numero);

            List<string> erros = mesa.Validar();

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;

                return;
            }
        }
      
    }
}
