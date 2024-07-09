using ControleDeBar.Dominio.ModuloGarçon;
using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.WinApp.Compartilhado;
using ControleDeBar.WinApp.ModuloProduto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.WinApp.ModuloGarcon
{
    public class ControladorGarcon : ControladorBase
    {
        TabelaGarconControl tabelaGarcon;

        IRepositorioGarcon repositorioGarcon;

        public override string TipoCadastro => "Garcon";

        public override string ToolTipAdicionar => "Cadastrar um novo Garcon";

        public override string ToolTipEditar => "Editar um Garcon";

        public override string ToolTipExcluir => "Excluir um Garcon do sistema";


        public ControladorGarcon(IRepositorioGarcon repositorioGarcon)
        {
            this.repositorioGarcon = repositorioGarcon;

        }

        public override void Adicionar()
        {
            List<Garcom> garcomscadastrados = repositorioGarcon.SelecionarTodos();

            TelaGarconForm telaGarcon = new TelaGarconForm(garcomscadastrados);

            DialogResult resultado = telaGarcon.ShowDialog(); ;

            if (resultado != DialogResult.OK)
                return;

            Garcom novoRegistro = telaGarcon.garcom;

            if (repositorioGarcon.SelecionarTodos().Any(m => m.Nome.Equals(novoRegistro.Nome.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show(
                    $"Já existe um Garcon com o nome \"{novoRegistro.Nome}\".",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            repositorioGarcon.Adicionar(novoRegistro);

            CarregarRegistros();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"Garcon {novoRegistro.Nome} foi adicionado com sucesso");
        }

        public override void Editar()
        {
            int idSelecionado = tabelaGarcon.ObterRegistroSelecionado();

            Garcom garconSelecionado = repositorioGarcon.SelecionarPorId(idSelecionado);

            if (garconSelecionado == null)
            {
                MessageBox.Show(
                    "Você precisa selecionar um registro para executar esta ação!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
            List<Garcom> garconsCadastrados = repositorioGarcon.SelecionarTodos();

            TelaGarconForm telaGarcon = new TelaGarconForm(garconsCadastrados);

            telaGarcon.garcom = garconSelecionado;

            DialogResult resultado = telaGarcon.ShowDialog();

            if (resultado != DialogResult.OK)
                return;

            Garcom garconEditado = telaGarcon.garcom;

            if (repositorioGarcon.SelecionarTodos().Any(m => m.Nome.Equals(garconEditado.Nome.Trim(), StringComparison.OrdinalIgnoreCase) && m.Id != garconEditado.Id))
            {
                MessageBox.Show(
                    $"Já existe um Garçom com o nome \"{garconEditado.Nome}\".",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            repositorioGarcon.Editar(idSelecionado, garconEditado);

            CarregarRegistros();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{garconEditado.Nome}\" foi editado com sucesso!");
        }

        public override void Excluir()
        {
            int idSelecionado = tabelaGarcon.ObterRegistroSelecionado();

            Garcom garcomselecionado = repositorioGarcon.SelecionarPorId(idSelecionado);

            if (garcomselecionado == null)
            {
                MessageBox.Show(
                    "Você precisa selecionar um registro para executar esta ação!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult resultado = MessageBox.Show(
                $"Tem certeza que deseja excluir o Garcon \"{garcomselecionado.Nome}\"?",
                "Excluir Garcom",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
                return;

            repositorioGarcon.Excluir(idSelecionado);

            CarregarRegistros();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{garcomselecionado.Nome}\" foi excluído com sucesso!");
        }

        public override UserControl ObterListagem()
        {
            if (tabelaGarcon == null)
               tabelaGarcon = new TabelaGarconControl();

            CarregarRegistros();

            return tabelaGarcon;

        }
        public override void CarregarRegistros()
        {
            List<Garcom> garcoms = repositorioGarcon.SelecionarTodos()!;

            tabelaGarcon.AtualizarRegistros(garcoms);

        }
    }
}
