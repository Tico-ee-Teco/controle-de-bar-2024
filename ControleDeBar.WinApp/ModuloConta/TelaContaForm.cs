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
                conta = value;

                txtId.Text = value.Id.ToString();             

                cmbMesa.SelectedItem = value.Mesa;
                cmbGarcom.SelectedItem = value.Garcom;

                foreach (Pedido pedido in value.Pedidos)
                    listPedido.Items.Add(pedido);

                ConfigurarCamposAtualizacaoConta();

                AtualizarLabelValorTotal();
            }
        }

        public List<Pedido> PedidosRemovidos { get; set; }

        private Conta conta;

        private List<Mesa> mesas;
        private List<Garcom> garcons;
        private List<Produto> produtos;

        public TelaContaForm(List<Mesa> mesas, List<Garcom> garcons, List<Produto> produtos)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            this.mesas = mesas;
            this.garcons = garcons;
            this.produtos = produtos;

            PedidosRemovidos = new List<Pedido>();

            foreach (Mesa mesa in mesas)
                cmbMesa.Items.Add(mesa);

            cmbMesa.SelectedIndex = 0;

            foreach (Garcom garcon in garcons)
                cmbGarcom.Items.Add(garcon);

            cmbGarcom.SelectedIndex = 0;

            foreach (Produto produto in produtos)
                cmbProduto.Items.Add(produto);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (conta == null)
                conta = ObterConta();

            List<string> erros = conta.Validar();

            if (erros.Count > 0)
            {
                TelaPrincipalForm
                    .Instancia
                    .AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;

                return;
            }
        }

        private void btnAdicionarPedido_Click(object sender, EventArgs e)
        {
            if (!ContaPodeSerUtilizada())
            {
                TelaPrincipalForm
                    .Instancia
                    .AtualizarRodape("Preencha os campos anteriores antes de criar um pedido!");

                return;
            }

            if (conta == null)
                conta = ObterConta();

            Produto produtoSelecionado = (Produto)cmbProduto.SelectedItem;
            int quantidadeSolicitada = (int)nudQuantidade.Value;

            Pedido pedido = conta.AdicionarPedido(produtoSelecionado, quantidadeSolicitada);

            listPedido.Items.Add(pedido);

            AtualizarLabelValorTotal();

            ResetarQuantidadeSolicitada();
        }

        private void btnRemoverPedido_Click(object sender, EventArgs e)
        {
            Pedido pedidoSelecionado = (Pedido)listPedido.SelectedItem;

            if (pedidoSelecionado == null)
            {
                TelaPrincipalForm
                    .Instancia
                    .AtualizarRodape("Um pedido precisa ser selecionado antes de remover!");

                return;
            }

            conta.RemoverPedido(pedidoSelecionado);

            PedidosRemovidos.Add(pedidoSelecionado);

            listPedido.Items.Remove(pedidoSelecionado);

            AtualizarLabelValorTotal();
        }

        private void ResetarQuantidadeSolicitada()
        {
            nudQuantidade.Value = nudQuantidade.Minimum;
        }

        private void ConfigurarCamposAtualizacaoConta()
        {
            this.Text = "Gerência de Conta";

            cmbMesa.Enabled = false;
            cmbGarcom.Enabled = false;
        }

        private void AtualizarLabelValorTotal()
        {
            lblValorTotal.Text = conta.CalcularValorTotal().ToString("C2");
        }

        private bool ContaPodeSerUtilizada()
        {
            bool dadosEstaoPreenchidos =              
                cmbMesa.SelectedItem != null &&
                cmbGarcom.SelectedItem != null;

            return dadosEstaoPreenchidos || conta != null;
        }


        private Conta ObterConta()
        {
            Mesa mesa = (Mesa)cmbMesa.SelectedItem;
            Garcom garcom = (Garcom)cmbGarcom.SelectedItem;

            return new Conta( mesa, garcom);
        }
    }
}
