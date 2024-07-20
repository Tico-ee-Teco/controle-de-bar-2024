
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infra.ModuloConta;
using ControleDeBar.WinApp.Compartilhado;

namespace ControleDeBar.WinApp.ModuloMesa
{
    public class ControladorMesa : ControladorBase
    {
        TabelaMesaControl tabelaMesa;

        IRepositorioMesa repositorioMesa;

        public override string TipoCadastro => "Mesa";

        public override string ToolTipAdicionar => "Cadastrar uma nova Mesa";

        public override string ToolTipEditar => "Editar uma Mesa";

        public override string ToolTipExcluir => "Excluir uma Mesa do sistema";


        public ControladorMesa(IRepositorioMesa repositorioMesa)
        {
            this.repositorioMesa = repositorioMesa;
        }

        public override void Adicionar()
        {
            List<Mesa> mesasCadastradas = repositorioMesa.SelecionarTodos();
            TelaMesaForm telaMesa = new TelaMesaForm(mesasCadastradas);

            DialogResult resultado = telaMesa.ShowDialog();

            if (resultado != DialogResult.OK) 
                return;

            Mesa mesacriada = telaMesa.Mesa;

            if(repositorioMesa.SelecionarTodos().Any(m => m.Numero.Equals(mesacriada.Numero.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show(
                    $"Já existe uma Mesa com o numero \"{mesacriada.Numero}\".",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            repositorioMesa.Adicionar(mesacriada);

            CarregarRegistros();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"Mesa {mesacriada.Numero} foi adicionado com sucesso");
        }

        public override void Editar()
        {
            int idSelecionado = tabelaMesa.ObterRegistroSelecionado();

            Mesa mesaselecionada = repositorioMesa.SelecionarPorId(idSelecionado);

            if (mesaselecionada == null)
            {
                MessageBox.Show(
                    "Você precisa selecionar um registro para executar esta ação!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
            List<Mesa> mesascadastradas = repositorioMesa.SelecionarTodos();

            TelaMesaForm telaMesa = new TelaMesaForm(mesascadastradas);

            telaMesa.Mesa = mesaselecionada;

            DialogResult resultado = telaMesa.ShowDialog();

            if (resultado != DialogResult.OK)
                return;

            Mesa mesaEditada = telaMesa.Mesa;

            if (repositorioMesa.SelecionarTodos().Any(m => m.Numero.Equals(mesaEditada.Numero.Trim(), StringComparison.OrdinalIgnoreCase) && m.Id != mesaEditada.Id))
            {
                MessageBox.Show(
                    $"Já existe uma Mesa com o Numero \"{mesaEditada.Numero}\".",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            repositorioMesa.Editar(mesaselecionada, mesaEditada);

            CarregarRegistros();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{mesaEditada.Numero}\" foi editado com sucesso!");
        }

        public override void Excluir()
        {
            int idSelecionado = tabelaMesa.ObterRegistroSelecionado();

            Mesa mesaselecionada = repositorioMesa.SelecionarPorId(idSelecionado);

            if (mesaselecionada == null)
            {
                MessageBox.Show(
                    "Você precisa selecionar um registro para executar esta ação!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult resultado = MessageBox.Show(
                $"Tem certeza que deseja excluir A mesa \"{mesaselecionada.Numero}\"?",
                "Excluir Garcom",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
                return;

            repositorioMesa.Excluir(mesaselecionada);

            CarregarRegistros();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{mesaselecionada.Numero}\" foi excluído com sucesso!");
        }

        public override UserControl ObterListagem()
        {
            if (tabelaMesa == null)
                tabelaMesa = new TabelaMesaControl();

            CarregarRegistros();

            return tabelaMesa;

        }
        public override void CarregarRegistros()
        {
            List<Mesa> mesas = repositorioMesa.SelecionarTodos()!;

            tabelaMesa.AtualizarRegistros(mesas);

        }
    }
}
