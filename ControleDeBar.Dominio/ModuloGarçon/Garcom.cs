using ControleDeBar.Dominio.Compartilhar;

namespace ControleDeBar.Dominio.ModuloGarçon
{
    public class Garcom : EntidadeBase
    {
        public string Nome { get; set; }

        public Garcom() { }

        public Garcom (string nome)
        {
           Nome = nome;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Nome))
                erros.Add("Nome do Garçon e obrigatorio");

            return erros;
        }
        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Garcom novoGarcom = (Garcom)novoRegistro;
            
            Nome = novoGarcom.Nome;
        }
        public override string ToString()
        {
            return $"{Nome}";

        }
    }
}