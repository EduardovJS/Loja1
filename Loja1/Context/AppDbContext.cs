﻿using Loja1.Models;
using Microsoft.EntityFrameworkCore;

namespace Loja1.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Lanche> Lanches { get; set; }
        public DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }
        public DbSet<PedidoDetalhe> PedidoDetalhe { get; set; }
        public DbSet<Pedido> Pedido { get; set; }



    }
}
