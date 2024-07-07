using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.WinApp.Compartilhado.Extensions;

namespace ControleDeBar.WinApp.ModuloProduto
{
    public partial class TelaProdutoForm : Form
    {
        public Produto Produto
        {
            get => produto;
            set
            {
                txtId.Text = value.Id.ToString();
                txtNome.Text = value.Nome;
                txtValor.Text = value.Valor.ToString();
            }
        }

        public Produto produto;

        private List<Produto> produtosCadastrados;

        public TelaProdutoForm(List<Produto> produtosCadastrados)
        {
            InitializeComponent();
            this.ConfigurarDialog();

            this.produtosCadastrados = produtosCadastrados;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            decimal preco = Convert.ToDecimal(txtValor.Text);

            produto = new Produto(txtNome.Text, preco);

            List<string> erros = produto.Validar();

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }
        }
    }
}
