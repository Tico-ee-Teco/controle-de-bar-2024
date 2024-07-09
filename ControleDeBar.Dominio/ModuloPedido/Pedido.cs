using ControleDeBar.Dominio.Compartilhar;
using ControleDeBar.Dominio.ModuloProduto;

namespace ControleDeBar.Dominio.ModuloPedido
{
    public class Pedido : EntidadeBase
    {        
        public Produto Produto { get; set; } 
        
        //public int NumeroPedido { get; set; }
        public Garcom Garcom { get; set; }

        public int NumeroMesa { get; set; }

        public decimal Preco { get; set; }        

        public int Qtde { get; set; }

        public bool ExcluiItem { get; set; } = false;

        public Pedido() { }

        public Pedido (int numeroMesa, Garcom garcom, Produto produto, int qtde, decimal preco)
        {            
            NumeroMesa = numeroMesa;
            Garcom = garcom;
            Produto = produto;
            Qtde = qtde;           
            Preco = preco;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (Produto == null)
                erros.Add($"O campo Produto é obrigatório!");   
            
            if(NumeroPedido <= 0 || NumeroPedido == null)
                erros.Add($"O campo Número do Pedido precisa de um número maior que zero!");

            if (NumeroMesa <= 0 || NumeroMesa == null)
                erros.Add($"O campo Número da Mesa precisa não pode ser zero!");

            if (Qtde <= 0)
                erros.Add($"O campo Quantidade precisa ser maior do zero!");

            if (Preco <= 0)
                erros.Add($"O campo Preço precisa ser maior do zero!");

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Pedido pedidoEditado = (Pedido)novoRegistro;

            Produto = pedidoEditado.Produto; 
            NumeroPedido = pedidoEditado.NumeroPedido;
            NumeroMesa = pedidoEditado.NumeroMesa;
            Qtde = pedidoEditado.Qtde;            
            Preco = pedidoEditado.Preco;
        }

        public bool AtribuirProduto(Produto produto)
        {
            bool conseguiuAtribuir = produto.AdiconarPedido(this);

            if (conseguiuAtribuir)
                Produto = produto;
            return conseguiuAtribuir;
        }

        public bool RemoverProduto()
        {
            if (Produto == null)
                return false;

            Produto.Pedidos.Remove(this);
            Produto = null;

            return true;
        }
    }
}