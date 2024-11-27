using Loja1.Context;
using Loja1.Models;
using Loja1.Repositories.Interfaces;

namespace Loja1.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly CarrinhoCompra _carrinhocompra;

        public PedidoRepository(AppDbContext appDbContext, CarrinhoCompra carrinhocompra)
        {
            _appDbContext = appDbContext;
            _carrinhocompra = carrinhocompra;
        }

        public void CriarPedido(Pedido pedidos)
        {
                pedidos.PedidoEnviado = DateTime.Now;
                _appDbContext.Pedido.Add(pedidos);
                _appDbContext.SaveChanges();

                var carrinhoCompraItens = _carrinhocompra.CarrinhoCompraItems;

            foreach (var carrinhoItem in carrinhoCompraItens)
            {
                var pedidoDetail = new PedidoDetalhe()
                {
                    Quantidade = carrinhoItem.Quantidade,
                    LancheId = carrinhoItem.Lanches.LancheId,
                    PedidoId = pedidos.PedidoId,
                    Preco = carrinhoItem.Lanches.Preco
                };
                _appDbContext.PedidoDetalhe.Add(pedidoDetail);
            }
            _appDbContext.SaveChanges();
        }





    }
}
