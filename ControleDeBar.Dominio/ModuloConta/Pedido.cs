using ControleDeBar.Dominio.Compartilhar;
using ControleDeBar.Dominio.ModuloProduto;

namespace ControleDeBar.Dominio.ModuloConta
{
    public class Pedido : EntidadeBase
    {
        public Produto Produto { get; set; }

        public int Qtde { get; set; }

        public decimal Preco => Produto.Valor * Qtde;

        public Pedido() { }

        public Pedido(Produto produto, int qtde)
        {
            Produto = produto;
            Qtde = qtde;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (Produto == null)
                erros.Add($"O campo Produto é obrigatório!");

            if (Qtde <= 0)
                erros.Add($"O campo Quantidade é obrigatório!");

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Pedido pedidoEditado = (Pedido)novoRegistro;

            Produto = pedidoEditado.Produto;
            Qtde = pedidoEditado.Qtde;

        }

        public override string ToString()
        {
            return $"{Qtde} x {Produto.Nome} - {Preco:C}";
        }


    }
}