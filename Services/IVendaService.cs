using System.Collections.Generic;
using ExercicioLinqAPI.Data.Entities;
using ExercicioLinqAPI.DTOs;

namespace ExercicioLinqAPI.Services
{
    public interface IVendaService
    {

        /// <summary>
        /// Busca todas as Vendas
        /// </summary>
        /// <returns>Objeto com VendaId, VendaItemId, ProdutoId, ValorUnitario</returns>
        List<VendaItem> ObterTodasVendas();

        /// <summary>
        /// Pesquisa os itens que foram vendidos sem desconto
        /// </summary>
        /// <returns>Objeto com VendaId, VendaItemId, ProdutoId, ValorUnitario</returns>
        List<dynamic> ObterVendasSemDesconto();

        /// <summary>
        /// Pesquisa os itens que foram vendidos com desconto. 
        /// <seealso cref="ValorVendido">
        /// O valor vendido é igual ao ValorUnitario - (ValorUnitario*(Desconto/100)).
        /// </seealso>
        /// </summary>
        /// <returns>Objeto com VendaId, VendaItemId, ProdutoId, ValorUnitario, ValorVendido</returns>
        List<dynamic> ObterVendasComDesconto();

        /// <summary>
        /// Altere o valor do desconto (para zero) de todos os registros onde este campo é nulo
        /// </summary>
        /// <returns></returns>
        bool ZerarDescontosNulos();

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
        List<dynamic> ObterTodosItensPorVenda();

        /// <summary>
        /// Pesquisar o valor total das vendas, ordene o resultado do maior valor para o menor 
        /// e agrupe o resultado da consulta por venda
        /// </summary>
        /// <seealso cref="ValorTotal">
        /// O valor total é igual ao ∑ Quantidade * ValorUnitario
        /// </seealso>
        /// <returns>Objeto com VendaId, ValorTotal</returns>        
        List<dynamic> ObterValorTotalPorVenda();

        /// <summary>
        /// Pesquisar o valor total das vendas, ordene o resultado do maior valor para o menor 
        /// e agrupe o resultado da consulta por venda
        /// </summary>
        /// <seealso cref="ValorVendido">
        /// O valor vendido é igual ao ∑ ValorUnitario - (ValorUnitario*(DESCONTO/100)).
        /// </seealso>
        /// <returns>Objeto com VendaId, ValorVendido</returns>        
        List<dynamic> ObterValorTotalVendidoPorProduto();

        /// <summary>
        /// Consulte o produto que mais vendeu no geral e agrupe por ProdutoId
        /// </summary>
        /// <returns>Objeto com ProdutoId, Quantidade</returns>
        List<dynamic> ObterProdutosMaisVendidos();

        /// <summary>
        /// Consulte as NF que foram vendidas mais de 10 unidades de pelo menos um produto
        /// </summary>
        /// <seealso cref="ValorTotal">
        /// O valor total é igual ao ∑ Quantidade * ValorUnitario
        /// </seealso>
        /// <returns>Objeto com VendaId, VendaTotal</returns>
        List<dynamic> ObterVendasComMais10Produtos();

        /// <summary>
        /// Obter o valor médio dos descontos por produtos
        /// </summary>
        /// <returns>Objeto com ProdutoId, Media</returns>
        decimal ObterValorMedioPorProduto();


        /// <summary>
        /// Obter  o menor, maior e o valor médio dos descontos dados por produto
        /// </summary>
        /// <returns>Objeto com ProdutoId, Menor, Maior, Medio</returns>
        List<dynamic> ObterMetricasVendaPorProduto();
    }
}