﻿using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.WinApp.Compartilhado.Extensions;

namespace ControleDeBar.WinApp.ModuloConta
{
    public partial class TelaFechamentoContaForm : Form
    {
        public Conta Conta { get; private set; }


        public TelaFechamentoContaForm(Conta contaSelecionada)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            Conta = contaSelecionada;

            ConfigurarCamposExibicao();
        }
        private void btnFecharConta_Click(object sender, EventArgs e)
        {
            Conta.Fechar();
        }

        private void ConfigurarCamposExibicao()
        {
            txtId.Text = Conta.Id.ToString();
            txtMesa.Text = Conta.Mesa.ToString();
            txtGarcom.Text = Conta.Garcom.ToString();

            foreach (Pedido pedido in Conta.Pedidos)
                listPedidos.Items.Add(pedido);

            lblValorTotal.Text = Conta.CalcularValorTotal().ToString("C2");
        }

    }
}
