using ControleDeBar.Dominio.Compartilhar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleDeBar.Dominio.ModuloMesa
{
    public class Mesa : EntidadeBase
    {
        public int Numero { get; set; }
        public Conta Conta { get; set; }

        public Mesa()
        {
        }

        public Mesa(int numero)
        {
            Numero = numero;
            Conta = null; 
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (Numero <= 0)
                erros.Add("Número da mesa é obrigatório e deve ser maior que zero");

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Mesa novaMesa = (Mesa)novoRegistro;
            Numero = novaMesa.Numero;
            Conta = novaMesa.Conta;
        }

        public override string ToString()
        {
            return $"Mesa: {Numero}, Conta: {(Conta != null ? Conta.ToString() : "Nenhuma")}";
        }
    }
}