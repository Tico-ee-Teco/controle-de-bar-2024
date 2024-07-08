using ControleDeBar.Dominio.Compartilhar;
using ControleDeBar.Dominio.ModuloProduto;

namespace ControleDeBar.Dominio.ModuloPedido
{
    public class Pedido : EntidadeBase
    {
        public Produto Produto { get; set; }       

        public string Item { get; set; }       

        public decimal Preco { get; set; }        

        public int Qtde { get; set; }

        public bool ExcluiItem { get; set; } = false;

        public Pedido() { }

        public Pedido(Produto produto, string item, decimal preco, int qtde, bool excluiItem)
        {
            Produto = produto;
            Item = item;
            Preco = preco;
            Qtde = qtde;
            ExcluiItem = excluiItem;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (Produto == null)
                erros.Add($"O campo Produto é obrigatório!");

            if(string.IsNullOrEmpty(Item))
                erros.Add($"O campo Item é obrigatório!");

            if (Preco <= 0)
                erros.Add($"O campo Preço precisa ser maior do zero!");

            if (Qtde <= 0)
                erros.Add($"O campo Quantidade precisa ser maior do zero!");

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Pedido pedidoEditado = (Pedido)novoRegistro;

            Produto = pedidoEditado.Produto;
            Item = pedidoEditado.Item;
            Preco = pedidoEditado.Preco;
            Qtde = pedidoEditado.Qtde;
            ExcluiItem = pedidoEditado.ExcluiItem;
        }
    }
}