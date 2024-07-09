using ControleDeBar.Dominio;
using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloPedido;
using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.WinApp.Compartilhado.Extensions;

namespace ControleDeBar.WinApp.ModuloConta
{
    public partial class TelaContaForm : Form
    {
        public Conta Conta
        {
            get => conta;
            set
            {
                txtId.Text = value.Id.ToString();
                cmbMesa.SelectedItem = value.Mesa.Numero.ToString();
                cmbGarcom.SelectedItem = value.Garcom.Nome;
                cmbProduto.SelectedItem =
                    produtosCadastrados.Find(p => p.Nome == value.Produto.Nome);
            }
        }

        public Conta conta;

        public List<Produto> produtosCadastrados = new List<Produto>();
        public List<Mesa> mesasCadastradas = new List<Mesa>();
        public List<Garcom> garconsCadastrados = new List<Garcom>();
        public List<Conta> contasCadastradas = new List<Conta>();
        public TelaContaForm(List<Conta> contasCadastradas)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            this.contasCadastradas = contasCadastradas;

            foreach (Produto produto in produtosCadastrados)
                cmbProduto.Items.Add(produto.Nome);

            foreach (Mesa mesa in mesasCadastradas)
                cmbMesa.Items.Add(mesa.Numero);

            foreach (Garcom garcom in garconsCadastrados)
                cmbGarcom.Items.Add(garcom.Nome);
        }

        private void btnAddPedido_Click(object sender, EventArgs e)
        {
            Mesa mesa = mesasCadastradas.Find(m => m.Numero == Convert.ToInt32(cmbMesa.SelectedItem));
            Garcom garcom = garconsCadastrados.Find(g => g.Nome == cmbGarcom.SelectedItem.ToString());
            Produto produto = produtosCadastrados.Find(p => p.Nome == cmbProduto.SelectedItem.ToString());
            int quantide = (int)nudQuantidade.Value;
            decimal valorTotal = produto.Valor * quantide;

            Pedido pedido = new Pedido(mesa.Numero, garcom, produto, quantide,valorTotal);

            listPedido.Items.Add(pedido);
        }
    }
}
