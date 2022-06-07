using MarketMedia.src.Entities;

namespace MarketMedia.src.Services
{
    public interface IRepository
    {
        Task Save();
        void Add<T>(T Entity) where T : class;
        void Add<T>(List<T> entity) where T : class;
        void Update<T>(T Entity) where T : class;
        void Update<T>(List<T> entity) where T : class;
        void Delete<T>(T Entity) where T : class;
        void Delete<T>(List<T> entity) where T : class;

        //Address
        Task<Address> GetAddress(int id);
        Task<List<Address>> GetAllAddresses();
        Task<List<Address>> GetAddressesByVillage(int villageID);


        //Branch
        Task<Branch> GetBranch(int id);
        Task<List<Branch>> GetBranchesBySeller(int sellerId);
        Task<List<Branch>> GetBranchesByVillage(int villageId);
        Task<List<Branch>> GetBranchesByStreet(string streetNumber);
        Task<List<Branch>> GetAllBranches();

        //Category
        Task<Category> GetCategory(int id);
        Task<List <Category>> GetAllCategories();

        //Cell
        Task<Cell> GetCell(int id);
        Task<List<Cell>> GetCellsBySector(int sectorId);
        Task<List<Cell>> GetAllCells();

        // Contact
        Task<Contact> GetContact(int id);
        Task<List<Contact>> GetAllContacts();

        //Customer
        Task<Customer> GetCustomer(int id);
        Task<List<Customer>> GetAllCustomers();
        Task<List<Customer>> GetCustomersByAddress(int addressId);

        //District
        Task<District> GetDistrict(int id);
        Task<List<District>> GetAllDistricts();
        Task<List<District>> GetAllDistrictsByProvince(int ProvinceId);

        //Order
        Task<Order> GetOrder (int id);
        Task<List<Order>> GetAllOrders();
        Task<List<Order>> GetAllOrdersByCustomer(int customerId);
        Task<List<Order>> GetAllOrdersByProduct(int productId);
        Task<List<Order>> GetAllOrdersByPayment(int paymentId);

        //Payment
        Task<Payment> GetPayment(int id);
        Task<List <Payment>> GetAllPayments();

        //Product
        Task<Product> GetProduct(int id);
        Task<List<Product>> GetAllProducts();
        Task<List<Product>> GetAllProductsByCategory(int categoryId);

        //ProductSeller
        Task<ProductSeller> GetProductSeller(int productId, int sellerId);
        Task<List<ProductSeller>> GetAllProductsBySeller(int sellerId);
        Task<List<ProductSeller>> GetAllsellersByProduct(int productId); //All sellers who sell a certain product
        Task<List<ProductSeller>> GetAllProductSellers();
        Task<List<ProductSeller>> GetAllProductsOnDiscount();
        Task<List<ProductSeller>> GetProductOnDiscount(int productId);
        Task<List<ProductSeller>> GetAllProductsOnPromotion();
        Task<List<ProductSeller>> GetProductOnPromotion(int productId);
        Task<List <ProductSeller>> GetAllProductsByPrice(int productId, decimal lowBound, decimal highBound);

        //Province
        Task<Province> GetProvince(int id);
        Task<List<Province>> GetAllProvinces();

        //Sector
        Task<Sector> GetSector(int id);
        Task<List<Sector>> GetAllSectors();
        Task<List<Sector>> GetAllSectorsByDistrict(int DistrictId);

        //Seller
        Task<Seller> GetSeller(int id);
        Task<List<Seller>> GetAllSellers ();

        //Village
        Task<Village> GetVillage(int id);
        Task<List<Village>> GetAllVillages();
        Task<List<Village>> GetAllVillageByCell(int CellId);
    }
}
