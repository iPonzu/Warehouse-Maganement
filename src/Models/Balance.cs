using Data;
using System;

namespace Models{
    public class Balance{
        public int Id {get; set;}
        public int ProductId {get; set;}
        public int WarehouseId {get; set;}
        public int Quantity {get; set;}

        public Balance(int id, int productId, int warehouseId, int quantity){
            this.Id = id;
            this.ProductId = productId;
            this.WarehouseId = warehouseId;
            this.Quantity = quantity;

            this.create(this);
        }

        public Balance(){}

        public void create(Balance balance){
            using(Context context = new Context()){
                context.balances.Add(balance);
                context.SaveChanges();
            }
        }
        public static void update(Balance balance){
            using(Context context = new Context()){
                context.balances.Update(balance);
                context.SaveChanges();
            }
        }
        public static void delete(Balance balance){
            using(Context context = new Context()){
                context.balances.Remove(balance);
                context.SaveChanges();
            }
        }
        public static List<Balance> Read(){
            using(Context context = new Context()){
                return context.balances.ToList();
            }
        }
        public static Balance ReadById(int id){
            using(Context context = new Context()){
                var balance =  context.balances.Find(id);
                return balance;
            }
        }
    }
}