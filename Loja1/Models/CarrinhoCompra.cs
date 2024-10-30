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

        public static CarrinhoCompra GetCarrinho (IServiceProvider services)
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

    }
}
