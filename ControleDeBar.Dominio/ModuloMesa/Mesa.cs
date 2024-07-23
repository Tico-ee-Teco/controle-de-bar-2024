using ControleDeBar.Dominio.Compartilhar;
using ControleDeBar.Dominio.ModuloConta;

namespace ControleDeBar.Dominio.ModuloMesa
{
    public class Mesa : EntidadeBase
    {
        public string Numero { get; set; }
        public bool Ocupada { get; set; }
        public List<Conta> Contas { get; set; }

        public Mesa() 
        {
            Contas = new List<Conta>();
        }

        public Mesa(string numeromesa) : this()
        {
            Numero = numeromesa;

        }
        public void Ocupar()
        {
            Ocupada = true;
        }
        public void Desocupar()
        {
            Ocupada = false;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Numero))
                erros.Add("Número da mesa é obrigatório e deve ser maior que zero");

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Mesa novaMesa = (Mesa)novoRegistro;
            Numero = novaMesa.Numero;
        }
        public override string ToString()
        {
            return $"{Numero}";
        }
    }
}