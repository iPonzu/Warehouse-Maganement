using Data;
using System;

namespace Models{
    public class Warehouse{
        public int Id {get; set;}
        public string Name {get; set;}
        public string Address {get; set;}

        public Warehouse(int id, string name, string address){
            this.Id = id;
            this.Name = name;
            this.Address = address;
        }

        public Warehouse(){}

        public void register(Warehouse warehouse){
            using(Context context = new Context()){
                context.warehouses.Add(warehouse);
                context.SaveChanges();
            }
        }
        public static void update(Warehouse warehouse){
            using(Context context = new Context()){
                context.warehouses.Update(warehouse);
                context.SaveChanges();
            }
        }
        public static void delete(Warehouse warehouse){
            using(Context context = new Context()){
                context.warehouses.Remove(warehouse);
                context.SaveChanges();
            }
        }
        public static List<Warehouse> Read(){
            using(Context context = new Context()){
                return context.warehouses.ToList();
            }
        }
        public static Warehouse ReadById(int id){
            using(Context context = new Context()){
                var warehouse =  context.warehouses.Find(id);
                return warehouse;
            }
        }
    }
}