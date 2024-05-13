using Controllers;
using Models;

namespace Views{
    public class ProductUpdate : Form{
        public Label lblid;
        public TextBox txtid;
        public Label lblname;
        public TextBox txtname;
        public Label lblprice;
        public TextBox txtprice;
        public Button btUpdate;
        public Button btBack;

        public Models.Product product;

        private void btUpdate_Click(object sender, EventArgs e){
            Models.Product productUpdate = this.product;
            productUpdate.Id = int.Parse(txtid.Text);
            productUpdate.Name = txtname.Text;
            productUpdate.Price = double.Parse(txtprice.Text);

            try{
                if(productUpdate.Id == 0 || productUpdate.Name == "" || productUpdate.Price == 0 || productUpdate.Name.Length > 0 || productUpdate.Price.ToString().Length > 0){
                    MessageBox.Show("You must fill all the fields");
                    return;
                }else{
                    Models.Product.update(productUpdate);
                    MessageBox.Show("Product updated successfully");
                    ClearForm();
                }
                this.Close();
            }catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }
        private void btBack_click(object sender, EventArgs e){
            this.Close();
            // Menu.Show();
        }

        private void ClearForm(){
            txtid.Text = "";
            txtname.Text = "";
            txtprice.Text = "";
        }

        public ProductUpdate(Models.Product product){

        }
    }
}