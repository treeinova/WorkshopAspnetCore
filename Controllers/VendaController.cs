using ExercicioLinqAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExercicioLinqAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : Controller
    {

        private readonly IVendaService _vendaService;

        public VendaController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }

        /// <summary>
        /// Busca todas as Vendas
        /// </summary>
        /// <returns>Objeto com VendaId, VendaItemId, ProdutoId, ValorUnitario</returns>
        [HttpGet("")]

        public IActionResult ObterTodasVendas()
        {
            return Ok(_vendaService.ObterTodasVendas());
        }

        /// <summary>
        /// Pesquisa os itens que foram vendidos sem desconto
        /// </summary>
        /// <returns>Objeto com VendaId, VendaItemId, ProdutoId, ValorUnitario</returns>
        [HttpGet("SemDesconto")]
        public IActionResult ObterVendasSemDesconto()
        {
            return Ok(_vendaService.ObterVendasSemDesconto());
        }

        /// <summary>
        /// Pesquisa os itens que foram vendidos com desconto. 
        /// <seealso cref="ValorVendido">
        /// O valor vendido é igual ao ValorUnitario - (ValorUnitario*(Desconto/100)).
        /// </seealso>
        /// </summary>
        /// <returns>Objeto com VendaId, VendaItemId, ProdutoId, ValorUnitario, ValorVendido</returns>
        [HttpGet("ComDesconto")]
        public IActionResult ObterVendasComDesconto()
        {
            return Ok(_vendaService.ObterVendasComDesconto());
        }

        /// <summary>
        /// Altere o valor do desconto (para zero) de todos os registros onde este campo é nulo
        /// </summary>
        /// <returns></returns>
        [HttpPut("ZerarDescontosNulos")]
        public IActionResult ZerarDescontosNulos()
        {
            bool sucesso = _vendaService.ZerarDescontosNulos();
            if (sucesso)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500, "Problemas ao zeras os descontos");
            }
        }

        /// <summary>
        /// Pesquise os itens que foram vendidos
        /// <seealso cref="ValorVendido">
        /// O valor vendido é igual ao ValorUnitario - (ValorUnitario*(DESCONTO/100)).
        /// </seealso>
        /// <seealso cref="ValorTotal">
        /// O valor total é igual ao ValorUnitario * Quantidade.
        /// </seealso>
        /// </summary>
        /// <returns>Objeto com VendaId, VendaItemId, ProdutoId, ValorUnitario, ValorVendido, ValorTotal</returns>
        [HttpGet("ItensPorVenda")]
        public IActionResult ObterTodosItensPorVenda()
        {
            return Ok(_vendaService.ObterTodosItensPorVenda());
        }

        /// <summary>
        /// Pesquisar o valor total das vendas, ordene o resultado do maior valor para o menor 
        /// e agrupe o resultado da consulta por venda
        /// </summary>
        /// <seealso cref="ValorTotal">
        /// O valor total é igual ao ∑ Quantidade * ValorUnitario
        /// </seealso>
        /// <returns>Objeto com VendaId, ValorTotal</returns>    
        [HttpGet("ValorTotalPorVenda")]
        public IActionResult ObterValorTotalPorVenda()
        {
            return Ok(_vendaService.ObterValorTotalPorVenda());
        }

        /// <summary>
        /// Pesquisar o valor total das vendas, ordene o resultado do maior valor para o menor 
        /// e agrupe o resultado da consulta por venda
        /// </summary>
        /// <seealso cref="ValorVendido">
        /// O valor vendido é igual ao ∑ ValorUnitario - (ValorUnitario*(DESCONTO/100)).
        /// </seealso>
        /// <returns>Objeto com VendaId, ValorVendido</returns>        
        [HttpGet("ValorTotalVendidoPorProduto")]
        public IActionResult ObterValorTotalVendidoPorProduto()
        {
            return Ok(_vendaService.ObterValorTotalVendidoPorProduto());
        }

        /// <summary>
        /// Consulte o produto que mais vendeu no geral e agrupe por ProdutoId
        /// </summary>
        /// <returns>Objeto com ProdutoId, Quantidade</returns>
        [HttpGet("ProdutosMaisVendidos")]

        public IActionResult ObterProdutosMaisVendidos()
        {
            return Ok(_vendaService.ObterProdutosMaisVendidos());
        }

        /// <summary>
        /// Consulte as NF que foram vendidas mais de 10 unidades de pelo menos um produto
        /// </summary>
        /// <seealso cref="ValorTotal">
        /// O valor total é igual ao ∑ Quantidade * ValorUnitario
        /// </seealso>
        /// <returns>Objeto com VendaId, VendaTotal</returns>
        [HttpGet("VendasComMais10Produto")]
        public IActionResult ObterVendasComMais10Produtos()
        {
            return Ok(_vendaService.ObterVendasComMais10Produtos());
        }

        /// <summary>
        /// Obter o valor médio dos descontos por produtos
        /// </summary>
        /// <returns>Objeto com ProdutoId, Media</returns>
        [HttpGet("ValorMedioPorProduto")]
        public IActionResult ObterValorMedioPorProduto()
        {
            return Ok(_vendaService.ObterValorMedioPorProduto());
        }


        /// <summary>
        /// Obter  o menor, maior e o valor médio dos descontos dados por produto
        /// </summary>
        /// <returns>Objeto com ProdutoId, Menor, Maior, Medio</returns>
        [HttpGet("MetricasVendaPorProduto")]
        public IActionResult ObterMetricasVendaPorProduto()
        {
            return Ok(_vendaService.ObterMetricasVendaPorProduto());
        }
    }
}