using System.Collections.Generic;
using System.Linq;
using ExercicioLinqAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExercicioLinqAPI.Services
{
    public class VendaService : IVendaService
    {
        private readonly EfDbContext _context;

        public VendaService(EfDbContext context)
        {
            _context = context;
        }

        public List<dynamic> ObterMetricasVendaPorProduto()
        {
            throw new System.NotImplementedException();
        }

        public List<dynamic> ObterProdutosMaisVendidos()
        {
            throw new System.NotImplementedException();
        }

        public List<VendaItem> ObterTodasVendas()
        {
            return _context.VendaItens.AsNoTracking().ToList();
        }

        public List<dynamic> ObterTodosItensPorVenda()
        {
            throw new System.NotImplementedException();
        }

        public decimal ObterValorMedioPorProduto()
        {
            throw new System.NotImplementedException();
        }

        public List<dynamic> ObterValorTotalPorVenda()
        {
            throw new System.NotImplementedException();
        }

        public List<dynamic> ObterValorTotalVendidoPorProduto()
        {
            throw new System.NotImplementedException();
        }

        public List<dynamic> ObterVendasComDesconto()
        {
            throw new System.NotImplementedException();
        }

        public List<dynamic> ObterVendasComMais10Produtos()
        {
            throw new System.NotImplementedException();
        }

        public List<dynamic> ObterVendasSemDesconto()
        {
            throw new System.NotImplementedException();
        }

        public bool ZerarDescontosNulos()
        {
            throw new System.NotImplementedException();
        }
    }
}