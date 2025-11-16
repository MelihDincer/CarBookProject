using CarBookProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarBookProject.Persistence.Context;

public class CarBookContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-PBE5IS4\\SQLEXPRESS; initial Catalog=CarBookDb;integrated Security=true; TrustServerCertificate=true");
    }
    public DbSet<About> Abouts { get; set; }
    public DbSet<Banner> Banners { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarDescription> CarDescriptions { get; set; }
    public DbSet<CarFeature> CarFeatures { get; set; }
    public DbSet<CarPricing> CarPricings { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<FooterAddress> FooterAddresses { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Pricing> Pricings { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<SocialMedia> SocialMedias { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<TagCloud> TagClouds { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<RentACar> RentACars { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reservation>()
            .HasOne(x => x.PickUpLocation)
            .WithMany(y => y.PickUpReservation)
            .HasForeignKey(z => z.PickUpLocationID)
            .OnDelete(DeleteBehavior.ClientSetNull);

        modelBuilder.Entity<Reservation>()
            .HasOne(x => x.DropOffLocation)
            .WithMany(y => y.DropOffReservation)
            .HasForeignKey(z => z.DropOffLocationID)
            .OnDelete(DeleteBehavior.ClientSetNull);

        modelBuilder.Entity<CarFeature>()
        .HasKey(cf => cf.CarFeatureID);

        modelBuilder.Entity<CarFeature>()
            .HasOne(cf => cf.Car)
            .WithMany(c => c.CarFeatures)
            .HasForeignKey(cf => cf.CarID)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CarFeature>()
            .HasOne(cf => cf.Feature)
            .WithMany(f => f.CarFeatures)
            .HasForeignKey(cf => cf.FeatureID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
