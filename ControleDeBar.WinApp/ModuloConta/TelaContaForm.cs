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

                foreach (Pedido pedido in value.Pedidos)
                    listPedido.Items.Add(pedido);
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

            //carregar pedidos
        }

        private void btnAddPedido_Click(object sender, EventArgs e)
        {
            Mesa mesa = mesasCadastradas.Find(m => m.Numero == Convert.ToInt32(cmbMesa.SelectedItem));
            Garcom garcom = garconsCadastrados.Find(g => g.Nome == cmbGarcom.SelectedItem.ToString());
            Produto produto = produtosCadastrados.Find(p => p.Nome == cmbProduto.SelectedItem.ToString());
            int quantide = (int)nudQuantidade.Value;
            decimal valorTotal = produto.Valor * quantide;

            Pedido pedido = new Pedido(mesa.Numero, garcom, produto, quantide, valorTotal);

            listPedido.Items.Add(pedido);
        }

        private void btnRemoverPedido_Click(object sender, EventArgs e)
        {
            Pedido pedido = (Pedido)listPedido.SelectedItem;

            if (pedido == null)
                return;

            listPedido.Items.Remove(pedido);

            RecarregarPedidos();
        }

        private void RecarregarPedidos()
        {
            List<Pedido> pedidos = new List<Pedido>();

            listPedido.Items.Clear();

            foreach (Pedido p in pedidos)
            {
                Mesa mesa = mesasCadastradas.Find(m => m.Numero == Convert.ToInt32(cmbMesa.SelectedItem));

               Pedido pedido = new Pedido(mesa.Numero, p.Garcom, p.Produto, p.Qtde, p.Preco);

                listPedido.Items.Add(pedido);

            }
        }
    }
}
