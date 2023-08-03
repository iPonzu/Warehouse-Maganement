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
            this.Text = "Warehouse";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            warehouseList = new ListView();
            warehouseList.Size = new Size(780, 400);
            warehouseList.Location = new Point(10, 10);
            warehouseList.View = View.Details;
            warehouseList.FullRowSelect = true;
            warehouseList.MultiSelect = false;
            warehouseList.Columns.Add("Id", -2, HorizontalAlignment.Center);
            warehouseList.Columns.Add("Name", -2, HorizontalAlignment.Center);
            warehouseList.Columns.Add("Address", -2, HorizontalAlignment.Center);
            RefreshList();
            this.Controls.Add(warehouseList);

            Button btCreate = new Button();
            btCreate.Text = "Create";
            btCreate.Size = new Size(100, 30);
            btCreate.Location = new Point(10, 420);
            btCreate.Click += new EventHandler(btCreate_Click);
            this.Controls.Add(btCreate);

            Button btUpdate = new Button();
            btUpdate.Text = "Update";
            btUpdate.Size = new Size(100, 30);
            btUpdate.Location = new Point(120, 420);
            btUpdate.Click += new EventHandler(btUpdate_Click);
            this.Controls.Add(btUpdate);

            Button btDelete = new Button();
            btDelete.Text = "Delete";
            btDelete.Size = new Size(100, 30);
            btDelete.Location = new Point(230, 420);
            btDelete.Click += new EventHandler(btDelete_Click);
            this.Controls.Add(btDelete);

            Button btClose = new Button();
            btClose.Text = "Close";
            btClose.Size = new Size(100, 30);
            btClose.Location = new Point(340, 420);
            btClose.Click += new EventHandler(btClose_Click);
            this.Controls.Add(btClose);
        }
    }
}