using ControleDeBar.Dominio.Compartilhar;
using ControleDeBar.Dominio.ModuloPedido;
using ControleDeBar.Dominio.ModuloProduto;

namespace ControleDeBar.Dominio.ModuloConta
{
    public class Conta : EntidadeBase
    {
        public Pedido Pedidos { get; set;}

        public Mesa Mesa { get; set; }        

        public decimal ValorTotal { get; set; }
       
        public Garcom Garcom { get; set; }  
        
        public int Quantidade { get; set; }

        public bool ContaPaga { get; set; } = false;       

        public List<Produto> Produtos { get; set; }

        public Conta() { }

        public Conta(Pedido pedidos, Mesa mesa, decimal valorTotal, Garcom garcom, int quantidade, bool contaPaga, List<Produto> produtos)
        {
            Pedidos = pedidos;
            Mesa = mesa;
            ValorTotal = valorTotal;
            Garcom = garcom;
            Quantidade = quantidade;
            ContaPaga = contaPaga;
            Produtos = produtos;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (Produtos == null)
                erros.Add($"O campo Produto é obrigatório!");

           if(Pedidos == null)
                erros.Add($"O campo Pedido é obrigatório!");

           if (Mesa == null)
                erros.Add($"O campo Mesa é obrigatório!");

           //if((Mesa != null) && (Mesa.NumeroMesa <= 0 || Mesa.NumeroMesa == null))
           //     erros.Add($"O campo Número da Mesa precisa não pode ser zero!");

           if (ValorTotal <= 0)
                 erros.Add($"O campo Valor Total precisa ser maior do zero!");

           if (Garcom == null)
                erros.Add($"O campo Garçom é obrigatório!");

           if (Quantidade <= 0)
                erros.Add($"O campo Quantidade precisa ser maior do zero!");

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Conta contaEditado = (Conta)novoRegistro;

            Pedidos = contaEditado.Pedidos;
            Mesa = contaEditado.Mesa;
            ValorTotal = contaEditado.ValorTotal;
            Garcom = contaEditado.Garcom;
            ContaPaga = contaEditado.ContaPaga;
            Produtos = contaEditado.Produtos;  
            Quantidade = contaEditado.Quantidade;
        }
    }
}