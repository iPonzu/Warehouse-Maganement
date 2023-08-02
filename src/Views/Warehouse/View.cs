using Models;
using Controllers;

namespace Views{
    public class WarehouseView : Form{
        public enum Option {Update, Delete}

        ListView warehouseList;

        private void AddListView(Models.Warehouse warehouse){
            string [] row = {
                warehouse.Id.ToString(),
                warehouse.Name.ToString(),
                warehouse.Address.ToString(),
            };
        
            ListViewItem item = new ListViewItem(row);
            warehouseList.Items.Add(item);
        }

        public void RefreshList(){
            warehouseList.Items.Clear();
            List<Models.Warehouse> warehouses = Models.Warehouse.Read();
            foreach(Models.Warehouse warehouse in warehouses){
                AddListView(warehouse);
            }
        }

        public Models.Warehouse GetSelectedWarehouse (Option option){
            if(warehouseList.SelectedItems.Count > 0){
                int selectedWarehouse = int.Parse(warehouseList.SelectedItems[0].Text);
                return Models.Warehouse.ReadById(selectedWarehouse);
            }else{
                throw new Exception($"Select an item to {(option == Option.Update ? "update" : "delete")})");
            }
   
        }

        private void btCreate_Click(object sender, EventArgs e){
            try{
                var WarehouseCreate = new Views.WarehouseCreate();
                WarehouseCreate.Show();
            }catch(Exception err){
                MessageBox.Show(err.Message);
            }
        }

        private void btUpdate_Click(object sender, EventArgs e){
            try{
                Models.Warehouse warehouse = GetSelectedWarehouse(Option.Update);
                RefreshList();
                DialogResult r = MessageBox.Show($"Are you sure you want to update the warehouse {warehouse.Id}?", "Update", MessageBoxButtons.YesNo);
                if(r == DialogResult.Yes){
                    Models.Warehouse.update(warehouse);
                    RefreshList();
                    MessageBox.Show("Warehouse updated successfully");
                }
            }catch (Exception err){
                MessageBox.Show(err.Message);
            }
        }

        private void btDelete_Click(object sender, EventArgs e){
            try{
                Models.Warehouse warehouse = GetSelectedWarehouse(Option.Delete);
                DialogResult r = MessageBox.Show($"Are you sure you want to delete the warehouse {warehouse.Id}?", "Delete", MessageBoxButtons.YesNo);
                if(r == DialogResult.Yes){
                    Models.Warehouse.delete(warehouse);
                    RefreshList();
                    MessageBox.Show("Warehouse deleted successfully");
                }
            }catch (Exception err){
                MessageBox.Show(err.Message);
            }
        }

        private void btClose_Click(object sender, EventArgs e){
            this.Close();
        }

        public WarehouseView(){
            

        }
    }
}