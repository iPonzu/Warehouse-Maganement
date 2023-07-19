using Data;

namespace Models{
    public class Product{
        public int Id {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public string Price {get; set;}

        public Product(int id, string name, string description, string price){
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Price = price;
        }

        public Product(){}

        public void register(Product product){
            using(Context context = new Context()){
                context.products.Add(product);
                context.SaveChanges();
            }
        }
        public static void update(Product product){
            using(Context context = new Context()){
                context.products.Update(product);
                context.SaveChanges();
            }
        }
        public static void delete(Product product){
            using(Context context = new Context()){
                context.products.Remove(product);
                context.SaveChanges();
            }
        }
        public static List<Product> Read(){
            using(Context context = new Context()){
                return context.products.ToList();
            }
        }
        public static Product ReadById(int id){
            using(Context context = new Context()){
                var product =  context.products.Find(id);
                return product;
            }
        }
    }
}