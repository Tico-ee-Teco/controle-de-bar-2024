using ControleDeBar.Dominio.ModuloGarçon;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.Infra.ModuloMesa
{
    public class RepositorioMesa : IRepositorioMesa
    {
        ControleDeBarDbContext dbContext;

        public RepositorioMesa(ControleDeBarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Adicionar(Mesa mesa)
        {
            dbContext.Mesa.Add(mesa);
            dbContext.SaveChanges();
        }

        public bool Editar(int id, Mesa mesaAtualizada)
        {
            Mesa mesa = dbContext.Mesa.Find(id)!;

            if (mesa == null)
            {
                return false;
            }

            mesa.AtualizarRegistro(mesaAtualizada);

            dbContext.Mesa.Update(mesa);
            dbContext.SaveChanges();

            return true;
        }

        public bool Excluir(int id)
        {
            Mesa mesa = dbContext.Mesa.Find(id)!;

            if (mesa == null)
            {
                return false;
            }

            dbContext.Mesa.Remove(mesa);
            dbContext.SaveChanges();

            return true;
        }

        public Mesa SelecionarPorId(int id)
        {
            return dbContext.Mesa.Find(id)!;
        }

        public List<Mesa> SelecionarTodos()
        {
            return dbContext.Mesa.ToList();
        }
    }
}
