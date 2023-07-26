using Controllers;
using Models;
using Data;

namespace Views{
    public class Product{
        public Label lblid;
        public TextBox txtid;
        public Label lblname;
        public TextBox txtname;
        public Label lblprice;
        public TextBox txtprice;
        public Label lblwarehouseid;
        public TextBox txtwarehouseid;
        public Button btCreate;

        public void btCreate_Click(object sender, EventArgs e){
            if(txtid.Text == "" || txtname.Text == "" || txtprice.Text == "" || txtname.Text.Length > 0 || txtprice.Text.Length > 0 || txtwarehouseid == null || txtwarehouseid.Text.Length > 0){
                MessageBox.Show("You must fill all the fields");
                return;
            }else{
                Controllers.Product.create(int.Parse(txtid.Text), txtname.Text, txtprice.Text, int.Parse(txtwarehouseid.Text));
                MessageBox.Show("Product created successfully");
                ClearForm();
            }
            View.Product productList = Application.OpenForms.OfType<View.Product>().FirstOrDefault();
            if(productList != null){
                productList.RefreshList();
            }
            this.Close();
        }

        private void ClearForm(){
            txtid.Text = "";
            txtname.Text = "";
            txtprice.Text = "";
        }

        public Product(){
            
        }
    }
}