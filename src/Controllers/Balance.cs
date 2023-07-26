using Models;
using Data;

namespace Controllers{
    public class Balance{
        public static void create(int id, int productId, int warehouseId, int quantity){
            if(id == 0 || productId == 0 || warehouseId == 0 || quantity == 0){
                throw new System.Exception("Invalid data");
            }

            new Models.Balance(id, productId, warehouseId, quantity);
        }
        public static void update(int id, int productId, int warehouseId, int quantity){
            if(id == 0 || productId == 0 || warehouseId == 0 || quantity == 0){
                throw new System.Exception("Invalid data");
            }
            if(id != 0 && productId != 0 && warehouseId != 0 && quantity != 0){
                Models.Balance balance = Models.Balance.ReadById(id);
                balance.ProductId = productId;
                balance.WarehouseId = warehouseId;
                balance.Quantity = quantity;
                
                
                Models.Balance.update(balance);
            }
        }
        public static void delete(int id){
            using(var context = new Context()){
                var balance = context.balances.FirstOrDefault(b => b.Id == id);
                if(balance != null){
                    Models.Balance.delete(balance);
                }
            }
        }
        public static List<Models.Balance> Read(){
            return Models.Balance.Read();
        }
        public static Models.Balance ReadById(int id){
            return Models.Balance.ReadById(id);
        }
    }
}