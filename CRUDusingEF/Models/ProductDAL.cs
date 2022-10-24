using CRUDusingEF.Data;

namespace CRUDusingEF.Models
{
    public class ProductDAL
    {
        private readonly ApplicationDbContext context;
        public ProductDAL(ApplicationDbContext context)
        {
            this.context = context;
        }
        public List<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }
        public Product GetProductById(int id)
        {
            var product = context.Products.Where(x => x.Id == id).FirstOrDefault();
            return product;
        }
        public int AddProduct(Product prod)
        {
            context.Products.Add(prod);  // add data to the DbSet
            int res = context.SaveChanges(); // to reflect the changes to DB
            return res;
        }
        public int UpdateProduct(Product prod)
        {
            Product p = context.Products.Where(x => x.Id == prod.Id).FirstOrDefault();
            if (p != null)
            {
                p.Name = prod.Name;
                p.CompanyName = prod.CompanyName;
                p.Price = prod.Price;
                int res = context.SaveChanges();
                if (res == 1)
                    return 1;
                else
                    return 0;
            }
            else
            {
                return 0;
            }
        }
        public int DeleteProduct(int id)
        {
            Product p = context.Products.Where(x => x.Id == id).FirstOrDefault();
            if (p != null)
            {
                context.Products.Remove(p);
                int res = context.SaveChanges();
                if (res == 1)
                    return 1;
                else
                    return 0;
            }
            else
            {
                return 0;
            }
        }

    }
}
