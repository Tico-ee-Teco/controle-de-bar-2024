using ControleDeBar.Dominio.Compartilhar;

namespace ControleDeBar.Dominio.ModuloProduto
{
    public class Produto : EntidadeBase
    {
        public string Nome { get; set;}        

        public int Valor { get; set; }       

        public Produto() { }

        public Produto(string nome, int valor)
        {
            Nome = nome;
            Valor = valor;
            
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if(string.IsNullOrEmpty(Nome))
                erros.Add("Nome do produto é obrigatório");

            if(Valor < 1)
                erros.Add("Valor do produto deve ser maior do zero");            

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Produto novoProduto = (Produto)novoRegistro;

            Nome = novoProduto.Nome;
            Valor = novoProduto.Valor;           
        }        

        public override string ToString()
        {
            return $"Nome: {Nome}, Valor: {Valor}, Qtde: {Qtde}";
        }
    }
}