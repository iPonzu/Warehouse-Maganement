using Controllers;
using Models;
using Data;

namespace Views{
    public class ProductCreate : Form{
        public Label lblid;
        public TextBox txtid;
        public Label lblname;
        public TextBox txtname;
        public Label lblprice;
        public TextBox txtprice;
        public Button btCreate;

        public void btCreate_Click(object sender, EventArgs e){
            if(txtid.Text == "" || txtname.Text == "" || txtprice.Text == "" || txtname.Text.Length > 0 || txtprice.Text.Length > 0){
                MessageBox.Show("You must fill all the fields");
                return;
            }else{
                Controllers.Product.create(int.Parse(txtid.Text), txtname.Text, Convert.ToDouble(txtprice.Text));
                MessageBox.Show("Product created successfully");
                ClearForm();
            }
            ProductView productList = Application.OpenForms.OfType<ProductView>().FirstOrDefault();
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

        public ProductCreate(){
            
        }
    }
}