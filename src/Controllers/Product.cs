using Models;
using Data;

namespace Controllers{
    public class Product{
        public static void create(int id, string name, string description, double price){
            if(id == 0 || name == "" || description == "" || price == 0){
                throw new Exception("Invalid data");
            }

            new Models.Product(id, name, description, Convert.ToDouble(price));
        }

        public static void update(int id, string name, string description, int price){
            if(id == 0 || name == "" || name.Length > 0 || description == "" || description.Length > 0 || price == 0){
                throw new Exception("Invalid data");
            }
            if(name != null && description != null && price != 0){
                Models.Product product = Models.Product.ReadById(id);
                product.Name = name;
                product.Description = description;
                product.Price = Convert.ToDouble(price);
                
                
                Models.Product.update(product);
            }
        }

        public static void delete(int id){
            using(var context = new Context()){
                var product = context.products.FirstOrDefault(p => p.Id == id);
                if(product != null){
                    Models.Product.delete(product);
                }
            }
        }
        public static List<Models.Product>Read(){
            return Models.Product.Read();
        }
        public static Models.Product ReadById(int id){
            return Models.Product.ReadById(id);
        }
    }
}