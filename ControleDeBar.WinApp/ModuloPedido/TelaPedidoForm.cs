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
                nudQtde.Value = value.Qtde;
                nudPreco.Value = value.Preco;

                Produto produtoSelecionado = produtosCadastrados.Find(p => p.Nome == value.Produto.Nome);

                if(produtoSelecionado != null)
                {
                    cmbItem.SelectedItem = value.Produto.Nome;
                    nudPreco.Value = produtoSelecionado.Valor;
                }
            }
        }

        List<Produto> produtosCadastrados = new List<Produto>();
        List<Pedido> pedidosCadastrados = new List<Pedido>();

        public Pedido pedido;
        public TelaPedidoForm(List<Pedido> pedidosCadastrados, List<Produto> produtosCadastrados)
        {
            InitializeComponent();
            this.ConfigurarDialog();

            this.pedidosCadastrados = pedidosCadastrados;

            foreach (Produto produto in produtosCadastrados)            
                cmbItem.Items.Add(produto.Nome);           
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            int numeroPedido = Convert.ToInt32(txtNumeroPedido.Text);
            int numeroMesa = Convert.ToInt32(txtNumeroMesa.Text);
            Produto produto = produtosCadastrados.Find(p => p.Nome == cmbItem.SelectedItem.ToString());
            //Produto produto = produtosCadastrados.Find(p => p.Nome == cmbItem.Text);
            int qtde = Convert.ToInt32(nudQtde.Value);
            decimal preco = Convert.ToInt32(nudPreco.Value);

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
