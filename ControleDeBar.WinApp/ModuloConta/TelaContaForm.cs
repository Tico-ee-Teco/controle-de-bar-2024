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

                AtualizarTxtValorTotal();
                
            }
        }

        private Conta conta;

        public List<Produto> produtosCadastrados;        
        public List<Mesa> mesasCadastradas;
        public List<Garcom> garconsCadastrados;
        public List<Pedido> PedidosRemovidos { get; set; }
        public TelaContaForm(List<Mesa> mesasCadastradas, List<Garcom> garconsCadastrados, List<Produto> produtosCadastrados)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            this.mesasCadastradas = mesasCadastradas;
            this.garconsCadastrados = garconsCadastrados;
            this.produtosCadastrados = produtosCadastrados;
            
            foreach(Mesa mesa in mesasCadastradas)
                cmbMesa.Items.Add(mesa);

            foreach(Garcom garcom in garconsCadastrados)
                cmbGarcom.Items.Add(garcom);

            foreach(Produto produto in produtosCadastrados)
                cmbProduto.Items.Add(produto);                     

        }

        private void CarregarInformacao()
        {
            cmbMesa.Items.AddRange(mesasCadastradas.ToArray());
            cmbGarcom.Items.AddRange(garconsCadastrados.ToArray());
            cmbProduto.Items.AddRange(produtosCadastrados.ToArray());
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

            listPedido.Items.Add(pedido);

            AtualizarTxtValorTotal();

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

            AtualizarTxtValorTotal();
        }

        

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Mesa mesaSelecionada = (Mesa)cmbMesa.SelectedItem;
            Garcom garcomSelecionado = (Garcom)cmbGarcom.SelectedItem;

            conta = new Conta(mesaSelecionada, garcomSelecionado);

            List<string> erros = conta.Validar();

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;

            }

        }

        private void AtualizarTxtValorTotal()
        {
            txtValorTotal.Text = conta.CalcularValorTotal().ToString("C");
        }

        private void ResetarQuantidadeSolicitada()
        {
            nudQuantidade.Value = nudQuantidade.Minimum;
        }   
    }
}
