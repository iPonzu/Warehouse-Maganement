using Data;
using System;

namespace Models{
    public class Balance{
        public int Id {get; set;}
        public int ProductId {get; set;}
        public int WarehouseId {get; set;}
        public double Value {get; set;}

        public Balance(int id, int productId, int warehouseId, double value){
            this.Id = id;
            this.ProductId = productId;
            this.WarehouseId = warehouseId;
            this.Value = value;
        }

        public Balance(){}

        public void register(Balance balance){
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