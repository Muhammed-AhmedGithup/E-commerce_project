using E_commerce_project.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_project.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Actor_Movie>().HasKey(m => new
			{
				m.MovieId,
				m.ActorId
			});
			modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(m => m.Actors_Movies)
				.HasForeignKey(m => m.MovieId);
			modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(m => m.Actors_Movies)
				.HasForeignKey(m => m.ActorId);
		}

        internal Task GetAll(Func<object, object> value)
        {
            throw new NotImplementedException();
        }

        public DbSet<Actor_Movie> Actors_Movies { get; set; }
		public DbSet<Actor> Actors { get; set; }
		public DbSet<Movie> Movies { get; set; }
		public DbSet<Cinema> Cinemas { get; set; }
		public DbSet<Producer> Producers { get; set; }

		//Orders
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
		public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
	}
}