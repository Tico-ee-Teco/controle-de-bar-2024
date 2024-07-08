using ControleDeBar.Dominio.ModuloPedido;
using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.WinApp.Compartilhado.Extensions;

namespace ControleDeBar.WinApp.ModuloPedido
{
    public partial class TelaPedidoForm : Form
    {
        public Pedido Pedido
        {
            get => pedido;
            set
            {
                txtId.Text = value.Id.ToString();
                txtNumeroPedido.Text = value.NumeroPedido.ToString();
                txtNumeroMesa.Text = value.NumeroMesa.ToString();
                cmbItem.Text = value.Produto.Nome;
                nudQtde.Value = value.Qtde;
                nudPreco.Value = value.Preco;
            }
        }

        List<Produto> produtosCadastrados = new List<Produto>();

        public Pedido pedido;
        public TelaPedidoForm(List<Produto> produtosCadastrados)
        {
            InitializeComponent();
            this.ConfigurarDialog();

            this.produtosCadastrados = produtosCadastrados;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            int numeroPedido = Convert.ToInt32(txtNumeroPedido.Text);
            int numeroMesa = Convert.ToInt32(txtNumeroMesa.Text);
            Produto produto = produtosCadastrados.Find(p => p.Nome == cmbItem.Text);
            int qtde = Convert.ToInt32(nudQtde.Value);
            decimal preco = Convert.ToDecimal(nudPreco.Value);

            pedido = new Pedido(numeroPedido, numeroMesa, produto, qtde, preco);

            List<string> erros = pedido.Validar();

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }
        }
    }
}
