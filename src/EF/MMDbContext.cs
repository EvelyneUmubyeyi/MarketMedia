using MarketMedia.src.Entities;
using MarketMedia.src.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketMedia.src.EF
{
    public class MMDbContext:DbContext
    {
        public MMDbContext(DbContextOptions<MMDbContext> options) : base(options)
        {


        }

        public MMDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);

            // options.UseExceptionProcessor();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Address>().ToTable(nameof(Address), Schema.Lookup);
            modelBuilder.Entity<Branch>().ToTable(nameof(Branch), Schema.Lookup);
            modelBuilder.Entity<Category>().ToTable(nameof(Category), Schema.Lookup);
            modelBuilder.Entity<Category>().ToTable(nameof(Category), Schema.Lookup);
            modelBuilder.Entity<Cell>().ToTable(nameof(Cell), Schema.Lookup);
            modelBuilder.Entity<Contact>().ToTable(nameof(Contact), Schema.Lookup);
            modelBuilder.Entity<Customer>().ToTable(nameof(Customer), Schema.Lookup);
            modelBuilder.Entity<District>().ToTable(nameof(District), Schema.Lookup);
            modelBuilder.Entity<Order>().ToTable(nameof(Order), Schema.Lookup);
            modelBuilder.Entity<Payment>().ToTable(nameof(Payment), Schema.Lookup);
            modelBuilder.Entity<Product>().ToTable(nameof(Product), Schema.Lookup);
            modelBuilder.Entity<ProductSeller>().ToTable(nameof(ProductSeller), Schema.Lookup)
                .HasKey(i => new { i.ProductId, i.SellerId });
            //modelBuilder.Entity<Address>().ToTable(nameof(Address), Schema.Lookup).HasIndex(i=>i.Details).IsUnique();
            modelBuilder.Entity<Province>().ToTable(nameof(Province), Schema.Lookup);
            modelBuilder.Entity<Sector>().ToTable(nameof(Sector), Schema.Lookup);
            modelBuilder.Entity<Seller>().ToTable(nameof(Seller), Schema.Lookup);
            modelBuilder.Entity<Village>().ToTable(nameof(Village), Schema.Lookup);
            modelBuilder.Entity<AddressInputDto>().HasNoKey();
            modelBuilder.Entity<AddressOutputDto>().HasNoKey();
            modelBuilder.Entity<BranchInputDto>().HasNoKey();
            modelBuilder.Entity<BranchOutputDto>().HasNoKey();
            modelBuilder.Entity<CategoryInputDto>().HasNoKey();
            modelBuilder.Entity<CategoryOutputDto>().HasNoKey();
            modelBuilder.Entity<CellInputDto>().HasNoKey();
            modelBuilder.Entity<CellOutputDto>().HasNoKey();
            modelBuilder.Entity<ContactInputDto>().HasNoKey();
            modelBuilder.Entity<ContactOutputDto>().HasNoKey();
            modelBuilder.Entity<CustomerInputDto>().HasNoKey();
            modelBuilder.Entity<CustomerOutputDto>().HasNoKey();
            modelBuilder.Entity<DistrictInputDto>().HasNoKey();
            modelBuilder.Entity<DistrictOutputDto>().HasNoKey();
            modelBuilder.Entity<OrderInputDto>().HasNoKey();
            modelBuilder.Entity<OrderOutputDto>().HasNoKey();
            modelBuilder.Entity<PaymentInputDto>().HasNoKey();
            modelBuilder.Entity<PaymentOutputDto>().HasNoKey();
            modelBuilder.Entity<ProductInputDto>().HasNoKey();
            modelBuilder.Entity<ProductOutputDto>().HasNoKey();
            modelBuilder.Entity<ProductSellerInputDto>().HasNoKey();
            modelBuilder.Entity<ProductSellerOutputDto>().HasNoKey();
            modelBuilder.Entity<ProvinceInputDto>().HasNoKey();
            modelBuilder.Entity<ProvinceOutputDto>().HasNoKey();
            modelBuilder.Entity<SectorInputDto>().HasNoKey();
            modelBuilder.Entity<SectorOutputDto>().HasNoKey();
            modelBuilder.Entity<SellerInputDto>().HasNoKey();
            modelBuilder.Entity<SellerOutputDto>().HasNoKey();
            modelBuilder.Entity<VillageInputDto>().HasNoKey();
            modelBuilder.Entity<VillageOutputDto>().HasNoKey();
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cell> Cells { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSeller> ProductSellers { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Village> Villages { get; set; }
        
        public virtual DbSet<AddressInputDto> AddressInputDtos { get; set; }
        public virtual DbSet<AddressOutputDto> AddressOutputDtos { get; set; }
        public virtual DbSet<BranchInputDto> BranchInputDtos { get; set; }
        public virtual DbSet<BranchOutputDto> BranchOutputDtos { get; set; }
        public virtual DbSet<CategoryInputDto> CategoryInputDtos { get; set; }
        public virtual DbSet<CategoryOutputDto> CategoryOutputDtos { get; set; }
        public virtual DbSet<CellInputDto> CellInputDtos { get; set; }
        public virtual DbSet<CellOutputDto> CellOutputDtos { get; set; }
        public virtual DbSet<ContactInputDto> ContactInputDtos { get; set; }
        public virtual DbSet<ContactOutputDto> ContactOutputDtos { get; set; }
        public virtual DbSet<CustomerInputDto> CustomerInputDtos { get; set; }
        public virtual DbSet<CustomerOutputDto> CustomerOutputDtos { get; set; }
        public virtual DbSet<DistrictInputDto> DistrictInputDtos { get; set; }
        public virtual DbSet<DistrictOutputDto> DistrictOutputDtos { get; set; }
        public virtual DbSet<OrderInputDto> OrderInputDtos { get; set; }
        public virtual DbSet<OrderOutputDto> OrderOutputDtos { get; set; }
        public virtual DbSet<PaymentInputDto> PaymentInputDtos { get; set; }
        public virtual DbSet<PaymentOutputDto> PaymentOutputDtos { get; set; }
        public virtual DbSet<ProductInputDto> ProductInputDtos { get; set; }
        public virtual DbSet<ProductOutputDto> ProductOutputDtos { get; set; }
        public virtual DbSet<ProductSellerInputDto> ProductSellerInputDtos { get; set; }
        public virtual DbSet<ProductSellerOutputDto> ProductSellerOutputDtos { get; set; }
        public virtual DbSet<ProvinceInputDto> ProvinceInputDtos { get; set; }
        public virtual DbSet<ProvinceOutputDto> ProvinceOutputDtos { get; set; }
        public virtual DbSet<SectorInputDto> SectorInputDtos { get; set; }
        public virtual DbSet<SectorOutputDto> SectorOutputDtos { get; set; }
        public virtual DbSet<SellerInputDto> SellerInputDtos { get; set; }
        public virtual DbSet<SellerOutputDto> SellerOutputDtos { get; set; }
        public virtual DbSet<VillageInputDto> VillageInputDtos { get; set; }
        public virtual DbSet<VillageOutputDto> VillageOutputDtos { get; set; }

    }
}
