using Models;
using Data;

namespace Controllers{
    public class Warehouse{
        public static void create(int id, string name, string address){
            if(id == 0 || name == "" || address == "" || name.Length > 0 || address.Length > 0){
                throw new Exception("Invalid data");
            }

            new Models.Warehouse(id, name, address);
        }

        public static void update(int id, string name, string address){
            if(id != 0 && name != null && address != null){
                Models.Warehouse warehouse = Models.Warehouse.ReadById(id);
                warehouse.Name = name;
                warehouse.Address = address;
                
                
                Models.Warehouse.update(warehouse);
            }
        }
        
        public static void delete(int id){
            using(var context = new Context()){
                var warehouse = context.warehouses.FirstOrDefault(w => w.Id == id);
                if(warehouse != null){
                    Models.Warehouse.delete(warehouse);
                }
            }
        }
        
        public static List<Models.Warehouse> Read(){
            return Models.Warehouse.Read();
        }
        
        public static Models.Warehouse ReadById(int id){
            return Models.Warehouse.ReadById(id);
        }
    }

}