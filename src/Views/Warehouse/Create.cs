using Models;
using Controllers;
using Data;

namespace Views{
    public class Warehouse{
        public Label lblid;
        public TextBox txtid;
        public Label lblname;
        public TextBox txtname;
        public Label lbladdress;
        public TextBox txtaddress;
        public Button btCreate;

        public void btCreate_Click(object sender, EventArgs e){
            if(txtid.Text == "" || txtname.Text == "" || txtaddress.Text == "" || txtname.Text.Length > 0 || txtaddress.Text.Length > 0){
                MessageBox.Show("You must fill all the fields");
                return;
            }else{
                Controllers.Warehouse.create(int.Parse(txtid.Text), txtname.Text, txtaddress.Text);
                MessageBox.Show("Warehouse created successfully");
                ClearForm();
            }
            View.Warehouse warehouseList = Application.OpenForms.OfType<View.Warehouse>().FirstOrDefault();
            if(warehouseList != null){
                warehouseList.RefreshList();
            }
            this.Close();
        }

        private void ClearForm(){
            txtid.Text = "";
            txtname.Text = "";
            txtaddress.Text = "";
        }


        public Warehouse(){
            
        }

    }
}