using ControleDeBar.Dominio.ModuloProduto;

namespace ControleDeBar.Dominio.ModuloConta
{
    public class Pedido
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }

        public int Qtde { get; set; }

        public decimal Preco => Produto.Valor * Qtde;

        public Pedido() { }

        public Pedido(Produto produto, int qtde) : this()
        {
            Produto = produto;
            Qtde = qtde;
        }     
        
        public decimal CalcularTotalParcial()
        {
           return Produto.Valor * Qtde;
        }

        public override string ToString()
        {
            return $"{Qtde} x {Produto.Nome} - {Preco:C}";
        }


    }
}