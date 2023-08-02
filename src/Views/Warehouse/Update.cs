using Controllers;
using Models;

namespace Views{
    public class WarehouseUpdate : Form{
        public Label lblid;
        public TextBox txtid;
        public Label lblname;
        public TextBox txtname;
        public Label lbladdress;
        public TextBox txtaddress;
        public Button btUpdate;
        public Button btBack;

        public Models.Warehouse warehouse;

        private void btUpdate_Click(object sender, EventArgs e){
            Models.Warehouse warehouseToUpdate = this.warehouse;
            warehouseToUpdate.Id = int.Parse(this.txtid.Text);
            warehouseToUpdate.Name = this.txtname.Text;
            warehouseToUpdate.Address = this.txtaddress.Text;

            try{
                if(warehouseToUpdate.Id == 0 || warehouseToUpdate.Name == "" || warehouseToUpdate.Address == "" || warehouseToUpdate.Name.Length > 0 || warehouseToUpdate.Address.Length > 0){
                    MessageBox.Show("You must fill all the fields");
                    return;
                }else{
                    Models.Warehouse.update(warehouseToUpdate);
                }
                this.Close();
            }catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void btBack_click(object sender, EventArgs e){
            this.Close();
        }

        private void ClearForm(){
            txtid.Text = "";
            txtname.Text = "";
            txtaddress.Text = "";
        }

        public WarehouseUpdate(Models.Warehouse warehouse){
            
        }
    }
}