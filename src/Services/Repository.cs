using AutoMapper;
using MarketMedia.src.EF;
using MarketMedia.src.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketMedia.src.Services
{
    public class Repository:IRepository
    {
        private readonly IRepository _repository;
        private readonly IMapper mapper;
        private readonly MMDbContext _Context;
        public Repository(MMDbContext mMDbContext)
        {
            _Context = mMDbContext;


        }
        public async Task Save()
        {
            await _Context.SaveChangesAsync();
        }
        public void  Add<T> (T entity) where T: class
        {
            _Context.Add<T>(entity);
        }

        public void Add<T>(List<T> entity) where T : class
        {
            _Context.AddRange(entity);
        }

        public void Delete<T> (T entity) where T : class
        {
            _Context.Remove<T>(entity);
        }

        public void Delete<T>(List<T> entity) where T : class
        {
            _Context.RemoveRange(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _Context.Update<T>(entity);
        }

        public void Update<T>(List<T> entity) where T : class
        {
            _Context.UpdateRange(entity);
        }

        #region Address
        //Address
        public async Task<Address> GetAddress(int id)
        {
            return await _Context.Addresses.Where(a => a.Id == id).Include(i => i.Village).FirstOrDefaultAsync();
        }

        public async Task<List<Address>> GetAddressesByVillage(int villageId)
        {
            return await _Context.Addresses.Where(a => a.VillageId == villageId).Include(i => i.Village).ToListAsync();
        }

        public async Task<List<Address>> GetAllAddresses()
        {
            return await _Context.Addresses.Include(i => i.Village).ToListAsync();
        }
        #endregion

        #region Branch
        public async Task<Branch> GetBranch(int id)
        {
            return await _Context.Branches.Where(a => a.Id == id).Include(i => i.Seller).Include(i => i.Village).FirstOrDefaultAsync();
        }

        public async Task<List<Branch>> GetBranchesBySeller(int sellerId)
        {
            return await _Context.Branches.Where(a => a.sellerId == sellerId).Include(i => i.Seller).Include(i => i.Village).ToListAsync();
        }

        public async Task<List<Branch>> GetBranchesByVillage(int villageId)
        {
            return await _Context.Branches.Where(a => a.villageId == villageId).Include(i => i.Seller).Include(i => i.Village).ToListAsync();
        }

        public async Task<List<Branch>> GetBranchesByStreet(string streetNumber)
        {
            return await _Context.Branches.Where(a => a.Street_number == streetNumber).Include(i => i.Seller).Include(i => i.Village).ToListAsync();
        }

        public async Task<List<Branch>> GetAllBranches()
        {
            return await _Context.Branches.Include(i => i.Seller).Include(i => i.Village).ToListAsync();
        }

        #endregion

        #region Category
        public async Task<Category> GetCategory(int id)
        {
            return await _Context.Categories.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _Context.Categories.ToListAsync();
        }
        #endregion

        #region Cell
        public async Task<Cell> GetCell(int id)
        {
            return await _Context.Cells.Where(a => a.Id == id).Include(i => i.Sector).FirstOrDefaultAsync();
        }

        public async Task<List<Cell>> GetCellsBySector(int sectorId)
        {
            return await _Context.Cells.Where(a => a.sectorId == sectorId).Include(i => i.Sector).ToListAsync();
        }

        public async Task<List<Cell>> GetAllCells()
        {
            return await _Context.Cells.Include(i => i.Sector).ToListAsync();
        }
        #endregion

        #region Contact
        public async Task<Contact> GetContact(int id)
        {
            return await _Context.Contacts.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            return await _Context.Contacts.ToListAsync();
        }
        #endregion

        #region Customer
        public async Task<Customer> GetCustomer(int id)
        {
            return await _Context.Customers.Where(a => a.Id == id).Include(i => i.Address).Include(i => i.Contact).FirstOrDefaultAsync();
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _Context.Customers.Include(i => i.Address).Include(i => i.Contact).ToListAsync();
        }

        public async Task<List<Customer>> GetCustomersByAddress(int addressId)
        {
            return await _Context.Customers.Where(a => a.AddressId == addressId).Include(i => i.Address).Include(i => i.Contact).ToListAsync();
        }
        #endregion

        #region District
        public async Task<District> GetDistrict(int id)
        {
            return await _Context.Districts.Where(a => a.Id == id).Include(i => i.Province).FirstOrDefaultAsync();
        }

        public async Task<List<District>> GetAllDistricts()
        {
            return await _Context.Districts.Include(i => i.Province).ToListAsync();
        }

        public async Task<List<District>> GetAllDistrictsByProvince(int ProvinceId)
        {
            return await _Context.Districts.Where(a => a.ProvinceId == ProvinceId).Include(i => i.Province).ToListAsync();
        }
        #endregion

        #region Order
        public async Task<Order> GetOrder(int id)
        {
            return await _Context.Orders.Where(a => a.Id == id).Include(i => i.Customer).Include(i => i.Product).Include(i => i.Payment).FirstOrDefaultAsync();
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _Context.Orders.Include(i => i.Customer).Include(i => i.Product).Include(i => i.Payment).ToListAsync();
        }

        public async Task<List<Order>> GetAllOrdersByCustomer(int customerId)
        {
            return await _Context.Orders.Where(a => a.CustomerId == customerId).Include(i => i.Customer).Include(i => i.Product).Include(i => i.Payment).ToListAsync();
        }

        public async Task<List<Order>> GetAllOrdersByProduct(int productId)
        {
            return await _Context.Orders.Where(a => a.ProductId == productId).Include(i => i.Customer).Include(i => i.Product).Include(i => i.Payment).ToListAsync();
        }

        public async Task<List<Order>> GetAllOrdersByPayment(int paymentId)
        {
            return await _Context.Orders.Where(a => a.PaymentId == paymentId).Include(i => i.Customer).Include(i => i.Product).Include(i => i.Payment).ToListAsync();
        }
        #endregion

        #region Payment
        public async Task<Payment> GetPayment(int id)
        {
            return await _Context.payments.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Payment>> GetAllPayments()
        {
            return await _Context.payments.ToListAsync();
        }
        #endregion

        #region Product
        public async Task<Product> GetProduct(int id)
        {
            return await _Context.Products.Where(a => a.Id == id).Include(i => i.Category).FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _Context.Products.Include(i => i.Category).ToListAsync();
        }

        public async Task<List<Product>> GetAllProductsByCategory(int categoryId)
        {
            return await _Context.Products.Where(a => a.CategoryId == categoryId).Include(i => i.Category).ToListAsync();
        }
        #endregion

        #region ProductSeller
        public async Task<ProductSeller> GetProductSeller(int productId, int sellerId)
        {
            return await _Context.ProductSellers.Where(a => a.ProductId == productId && a.SellerId == sellerId).Include(i => i.Product).Include(i => i.Seller).FirstOrDefaultAsync();
        }

        public async Task<List<ProductSeller>> GetAllProductsBySeller(int sellerId)
        {
            return await _Context.ProductSellers.Where(a => a.SellerId == sellerId).Include(i => i.Product).Include(i => i.Seller).ToListAsync();
        }

        public async Task<List<ProductSeller>> GetAllsellersByProduct(int productId)
        {
            return await _Context.ProductSellers.Where(a => a.ProductId == productId).Include(i => i.Product).Include(i => i.Seller).ToListAsync();
        }

        public async Task<List<ProductSeller>> GetAllProductSellers()
        {
            return await _Context.ProductSellers.Include(i => i.Product).Include(i => i.Seller).ToListAsync();
        }

        public async Task<List<ProductSeller>> GetAllProductsOnDiscount()
        {
            return await _Context.ProductSellers.Where(i => i.discount > 0).Include(i => i.Product).Include(i => i.Seller).OrderByDescending(i=>i.discount).ToListAsync();
        }

        public async Task<List<ProductSeller>> GetAllProductsByPrice(int productId, decimal lowBound, decimal highBound)
        {
            return await _Context.ProductSellers.Where(i=>i.ProductId == productId && lowBound <= i.price && i.price <= highBound).Include(i => i.Product).Include(i => i.Seller).OrderByDescending(i=>i.price).ToListAsync();
        }

        public async Task<List<ProductSeller>> GetProductOnDiscount(int productId)
        {
            return await _Context.ProductSellers.Where(i => i.discount > 1 && i.ProductId == productId).Include(i => i.Product).Include(i => i.Seller).OrderByDescending(i => i.discount).ToListAsync();
        }

        public async Task<List<ProductSeller>> GetAllProductsOnPromotion()
        {
            return await _Context.ProductSellers.Where(i => i.promotion != null).Include(i => i.Product).Include(i => i.Seller).ToListAsync();
        }

        public async Task<List<ProductSeller>> GetProductOnPromotion(int productId)
        {
            return await _Context.ProductSellers.Where(i => i.promotion != null && i.ProductId == productId).Include(i => i.Product).Include(i => i.Seller).ToListAsync();
        }
        #endregion

        #region Province
        public async Task<Province> GetProvince(int id)
        {
            return await _Context.Provinces.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Province>> GetAllProvinces()
        {
            return await _Context.Provinces.ToListAsync();
        }
        #endregion

        #region Sector
        public async Task<Sector> GetSector(int id)
        {
            return await _Context.Sectors.Where(a => a.Id == id).Include(i => i.District).FirstOrDefaultAsync();
        }

        public async Task<List<Sector>> GetAllSectors()
        {
            return await _Context.Sectors.Include(i => i.District).ToListAsync();
        }

        public async Task<List<Sector>> GetAllSectorsByDistrict(int DistrictId)
        {
            return await _Context.Sectors.Where(a => a.DistrictId == DistrictId).Include(i => i.District).ToListAsync();
        }
        #endregion

        #region Seller
        public async Task<Seller> GetSeller(int id)
        {
            return await _Context.Sellers.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Seller>> GetAllSellers()
        {
            return await _Context.Sellers.ToListAsync();
        }
        #endregion

        #region Village
        public async Task<Village> GetVillage(int id)
        {
            return await _Context.Villages.Where(a => a.Id == id).Include(i => i.Cell).FirstOrDefaultAsync();
        }

        public async Task<List<Village>> GetAllVillages()
        {
            return await _Context.Villages.Include(i => i.Cell).ToListAsync();
        }

        public async Task<List<Village>> GetAllVillageByCell(int CellId)
        {
            return await _Context.Villages.Where(a => a.cellId == CellId).Include(i => i.Cell).ToListAsync();
        }
        #endregion

    }

}
