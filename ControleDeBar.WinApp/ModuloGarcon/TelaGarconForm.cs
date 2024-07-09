using ControleDeBar.Dominio.ModuloGarçon;
using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.WinApp.Compartilhado.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeBar.WinApp.ModuloGarcon
{
    public partial class TelaGarconForm : Form
    {
        public Garcom Garcom
        {
            get => garcom;
            set
            {
                txtID.Text = value.Id.ToString();
                txtNome.Text = value.Nome;              
            }
        }

        public Garcom garcom;

        private List<Garcom> garconscadastrados;

        public TelaGarconForm(List<Garcom> garconscadastrados)
        {
            InitializeComponent();
            this.ConfigurarDialog();

            this.garconscadastrados = garconscadastrados;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {          

            garcom = new Garcom(txtNome.Text);

            List<string> erros = garcom.Validar();

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }

        }
    }
}
 
