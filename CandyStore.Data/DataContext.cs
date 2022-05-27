using CandyStore.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CandyStore.Data;

public class DataContext : IdentityDbContext<IdentityUser>
{
    readonly IHttpContextAccessor _httpContextAccessor;

    public DataContext(DbContextOptions<DataContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public DbSet<Candy> Candy => Set<Candy>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<ShoppingCartItem> ShoppingCartItems => Set<ShoppingCartItem>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();
    public DbSet<Sale> Sales => Set<Sale>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>().HasData(new Category { CategoryID = 1, Name = "Chocolate Candy", });
        modelBuilder.Entity<Category>().HasData(new Category { CategoryID = 2, Name = "Fruit Candy", });
        modelBuilder.Entity<Category>().HasData(new Category { CategoryID = 3, Name = "Gummy Candy", });
        modelBuilder.Entity<Category>().HasData(new Category { CategoryID = 4, Name = "Halloween Candy", });
        modelBuilder.Entity<Category>().HasData(new Category { CategoryID = 5, Name = "Hard Candy", });

        modelBuilder.Entity<Candy>()
                    .HasData(new Candy
                    {
                        CandyID = 1,
                        Name = "Assorted Chocolate Candy",
                        Price = 4.95M,
                        Description = "Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                        CategoryID = 1,
                        ImageURL = @"\img\chocolet.candy.jpg",
                        ImageThumbnailURL = @"\img\thumbnails\chocolateCandy3-small.jpg",
                        IsInStock = true,
                        IsOnSale = false,
                    });
        modelBuilder.Entity<Candy>()
                    .HasData(new Candy
                    {
                        CandyID = 2,
                        Name = "Assorted Chocolate Candy",
                        Price = 3.95M,
                        Description = "Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                        CategoryID = 1,
                        ImageURL = @"\img\chocolateCandy.jpg",
                        ImageThumbnailURL = @"\img\thumbnails\chocolateCandy-small.jpg",
                        IsInStock = true,
                        IsOnSale = true,
                    });
        modelBuilder.Entity<Candy>()
                    .HasData(new Candy
                    {
                        CandyID = 3,
                        Name = "Assorted Chocolate Candy",
                        Price = 2.95M,
                        Description = "Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                        CategoryID = 1,
                        ImageURL = @"\img\chocolateCandy2.jpg",
                        ImageThumbnailURL = @"\img\thumbnails\chocolateCandy2-small.jpg",
                        IsInStock = true,
                        IsOnSale = true,
                    });
        modelBuilder.Entity<Candy>()
                    .HasData(new Candy
                    {
                        CandyID = 4,
                        Name = "Assorted Fruit Candy",
                        Price = 6.95M,
                        Description = "Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                        CategoryID = 2,
                        ImageURL = @"\img\FruitCandy.jpg",
                        ImageThumbnailURL = @"\img\thumbnails\FruitCandy-small.jpg",
                        IsInStock = true,
                        IsOnSale = true,
                    });
        modelBuilder.Entity<Candy>()
                    .HasData(new Candy
                    {
                        CandyID = 5,
                        Name = "Assorted Fruit Candy",
                        Price = 3.95M,
                        Description = "Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                        CategoryID = 2,
                        ImageURL = @"\img\fruitCandy2.jpg",
                        ImageThumbnailURL = @"\img\thumbnails\fruitCandy2-small.jpg",
                        IsInStock = true,
                        IsOnSale = false,
                    });
        modelBuilder.Entity<Candy>()
                    .HasData(new Candy
                    {
                        CandyID = 6,
                        Name = "Assorted Fruit Candy",
                        Price = 4.95M,
                        Description = "Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                        CategoryID = 2,
                        ImageURL = @"\img\fruitCandy3.jpg",
                        ImageThumbnailURL = @"\img\thumbnails\fruitCandy3-small.jpg",
                        IsInStock = false,
                        IsOnSale = true,
                    });
        modelBuilder.Entity<Candy>()
                    .HasData(new Candy
                    {
                        CandyID = 7,
                        Name = "Assorted Gummy Candy",
                        Price = 4.95M,
                        Description = "Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                        CategoryID = 3,
                        ImageURL = @"\img\gummyCandy.jpg",
                        ImageThumbnailURL = @"\img\thumbnails\gummyCandy-small.jpg",
                        IsInStock = true,
                        IsOnSale = false,
                    });
        modelBuilder.Entity<Candy>()
                    .HasData(new Candy
                    {
                        CandyID = 8,
                        Name = "Assorted Gummy Candy",
                        Price = 6.95M,
                        Description = "Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                        CategoryID = 3,
                        ImageURL = @"\img\gummyCandy2.jpg",
                        ImageThumbnailURL = @"\img\thumbnails\gummyCandy2-small.jpg",
                        IsInStock = true,
                        IsOnSale = true,
                    });
        modelBuilder.Entity<Candy>()
                    .HasData(new Candy
                    {
                        CandyID = 9,
                        Name = "Assorted Gummy Candy",
                        Price = 4.95M,
                        Description = "Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                        CategoryID = 3,
                        ImageURL = @"\img\gummyCandy3.jpg",
                        ImageThumbnailURL = @"\img\thumbnails\gummyCandy3-small.jpg",
                        IsInStock = true,
                        IsOnSale = true,
                    });
        modelBuilder.Entity<Candy>()
                    .HasData(new Candy
                    {
                        CandyID = 10,
                        Name = "Assorted Halloween Candy",
                        Price = 3.95M,
                        Description = "Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                        CategoryID = 4,
                        ImageURL = @"\img\halloweenCandy.jpg",
                        ImageThumbnailURL = @"\img\thumbnails\halloweenCandy-small.jpg",
                        IsInStock = true,
                        IsOnSale = true,
                    });
        modelBuilder.Entity<Candy>()
                    .HasData(new Candy
                    {
                        CandyID = 11,
                        Name = "Assorted Halloween Candy",
                        Price = 5.95M,
                        Description = "Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                        CategoryID = 4,
                        ImageURL = @"\img\halloweenCandy2.jpg",
                        ImageThumbnailURL = @"\img\thumbnails\halloweenCandy2-small.jpg",
                        IsInStock = false,
                        IsOnSale = true,
                    });
        modelBuilder.Entity<Candy>()
                    .HasData(new Candy
                    {
                        CandyID = 12,
                        Name = "Assorted Halloween Candy",
                        Price = 6.95M,
                        Description = "Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                        CategoryID = 4,
                        ImageURL = @"\img\halloweenCandy3.jpg",
                        ImageThumbnailURL = @"\img\thumbnails\halloweenCandy3-small.jpg",
                        IsInStock = true,
                        IsOnSale = true,
                    });
        modelBuilder.Entity<Candy>()
                    .HasData(new Candy
                    {
                        CandyID = 13,
                        Name = "Assorted Hard Candy",
                        Price = 3.95M,
                        Description = "Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                        CategoryID = 5,
                        ImageURL = @"\img\hardCandy.jpg",
                        ImageThumbnailURL = @"\img\thumbnails\hardCandy-small.jpg",
                        IsInStock = true,
                        IsOnSale = false,
                    });
        modelBuilder.Entity<Candy>()
                    .HasData(new Candy
                    {
                        CandyID = 14,
                        Name = "Assorted Hard Candy",
                        Price = 2.95M,
                        Description = "Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                        CategoryID = 5,
                        ImageURL = @"\img\hardCandy2.jpg",
                        ImageThumbnailURL = @"\img\thumbnails\hardCandy2-small.jpg",
                        IsInStock = false,
                        IsOnSale = true,
                    });
        modelBuilder.Entity<Candy>()
                    .HasData(new Candy
                    {
                        CandyID = 15,
                        Name = "Assorted Hard Candy",
                        Price = 5.95M,
                        Description = "Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                        CategoryID = 5,
                        ImageURL = @"\img\hardCandy3.jpg",
                        ImageThumbnailURL = @"\img\thumbnails\hardCandy3-small.jpg",
                        IsInStock = true,
                        IsOnSale = false,
                    });
    }
}