using ControleDeBar.Dominio;
using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloGarçon;
using ControleDeBar.Dominio.ModuloMesa;
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

                foreach (Pedido pedido in value.Pedidos)
                    listPedido.Items.Add(pedido);
            }
        }

        private Conta conta;

        public List<Produto> produtosCadastrados;
        public List<Mesa> mesasCadastradas;
        public List<Garcom> garconsCadastrados;
        public List<Pedido> pedidos;
        public TelaContaForm(List<Mesa> mesas, List<Garcom> garcons, List<Produto> produtos)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            mesasCadastradas = mesas;
            garconsCadastrados = garcons;
            produtosCadastrados = produtos;
            pedidos = new List<Pedido>();

            CarregarInformacao();

        }

        private void CarregarInformacao()
        {
            cmbMesa.Items.Add(mesasCadastradas);
            cmbGarcom.Items.Add(garconsCadastrados);
            cmbProduto.Items.Add(produtosCadastrados);
        }

        private void btnAddPedido_Click(object sender, EventArgs e)
        {
            Produto produtoSelecionado = (Produto)cmbProduto.SelectedItem;
            int quantidade = (int)nudQuantidade.Value;

            if (produtoSelecionado == null || quantidade <= 0)
            {
                MessageBox.Show("Selecione um produto e informe a quantidade");

                return;
            }

            Pedido pedido = new Pedido(produtoSelecionado, quantidade);
            pedidos.Add(pedido);
            AtualizarListaPedidos();
            AtualizarValorTotal();

        }
        private void btnRemoverPedido_Click(object sender, EventArgs e)
        {
            Pedido pedidoSelecionado = (Pedido)listPedido.SelectedItem;

            if (pedidoSelecionado != null)
            {
                pedidos.Remove(pedidoSelecionado);
                AtualizarListaPedidos();
                AtualizarValorTotal();
            }
        }

        private void AtualizarValorTotal()
        {
            decimal valorTotal = pedidos.Sum(p => p.Produto.Valor * p.Qtde);

            txtValorTotal.Text = valorTotal.ToString("C");
        }

        private void AtualizarListaPedidos()
        {
            listPedido.Items.Clear();

            foreach (Pedido pedido in pedidos)
                listPedido.Items.Add(pedido);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Mesa mesaSelecionada = (Mesa)cmbMesa.SelectedItem;
            Garcom garcomSelecionado = (Garcom)cmbGarcom.SelectedItem;

            //if (mesaSelecionada == null || garcomSelecionado == null || pedidos.Count == 0)
            //{
            //    MessageBox.Show("Selecione uma mesa, um garçom e adicione pelo menos um pedido");

            //    return;
            //}

            conta = new Conta(mesaSelecionada, garcomSelecionado, pedidos);

            List<string> erros = conta.Validar();

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;

            }

        }
    }
}
