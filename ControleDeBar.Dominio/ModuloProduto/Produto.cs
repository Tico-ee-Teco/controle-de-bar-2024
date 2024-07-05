using ControleDeBar.Dominio.Compartilhar;

namespace ControleDeBar.Dominio.ModuloProduto
{
    public class Produto : EntidadeBase
    {
        public string Nome { get; set;}        

        public int Valor { get; set; }

        public int Qtde { get; set; }

        public Produto() { }

        public Produto(string nome, int valor, int qtde)
        {
            Nome = nome;
            Valor = valor;
            Qtde = qtde;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if(string.IsNullOrEmpty(Nome))
                erros.Add("Nome do produto é obrigatório");

            if(Valor < 1)
                erros.Add("Valor do produto deve ser maior do zero");

            if(Qtde < 1)
                erros.Add("Quantidade do produto deve ser maior do zero");

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            throw new NotImplementedException();
        }
        public void RemoverProduto(int qtde)
        {
            Qtde -= qtde;
        }
        public void AdicionarProduto(int qtde)
        {
            Qtde += qtde;
        }

        public override string ToString()
        {
            return $"Nome: {Nome}, Valor: {Valor}, Qtde: {Qtde}";
        }
    }
}