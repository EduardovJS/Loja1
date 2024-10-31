using Loja1.Context;

namespace Loja1.Models
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext _context;

        public CarrinhoCompra(AppDbContext context)
        {
            _context = context;
        }

        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompra> CarrinhoComprasItems { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            //definindo sessão
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //obtem um serviço do tipo nosso context
            var context = services.GetService<AppDbContext>();

            // atribui o id do carrinho na session
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();


            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId,
            };
        }

        public void AdicionarAoCarrinho(Lanche lanche)
        {
            // Atende o unico elemento das  duas condições SingleOrDefault
            var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(x => x.Lanches.LancheId == lanche.LancheId && x.CarrinhoCompraId == CarrinhoCompraId);

            if (carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Lanches = lanche,
                    Quantidade = 1
                };
                _context.CarrinhoCompraItens.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }
            _context.SaveChanges();
        }

        public void RemoverDoCarrinho(Lanche lanche)
        {
            var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(x => x.Lanches.LancheId == lanche.LancheId && x.CarrinhoCompraId == CarrinhoCompraId);

            if(carrinhoCompraItem != null)
            {
                //Se for maior que um decrementa, se não simplesmente remove do CarrinhoCompraItens
                if(carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                }
                else
                {
                    _context.CarrinhoCompraItens.Remove(carrinhoCompraItem);
                }

            }
            _context.SaveChanges();
        }













    }
}
