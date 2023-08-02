using Controllers;
using Models;

namespace Views{
    public class ProductView : Form{
        public enum Option {Update, Delete}

        ListView productList;

        private void AddListView(Models.Product product){
            string [] row = {
                product.Id.ToString(),
                product.Name.ToString(),
                product.Price.ToString(),
            };
        
            ListViewItem item = new ListViewItem(row);
            productList.Items.Add(item);
        }

        public void RefreshList(){
            productList.Items.Clear();
            List<Models.Product> products = Models.Product.Read();
            foreach(Models.Product product in products){
                AddListView(product);
            }
        }

        public Models.Product GetSelectedProduct (Option option){
            if(productList.SelectedItems.Count > 0){
                int selectedProduct = int.Parse(productList.SelectedItems[0].Text);
                return Models.Product.ReadById(selectedProduct);
            }else{
                throw new Exception($"Select an item to {(option == Option.Update ? "update" : "delete")})");
            }
   
        }

        private void btCreate_Click(object sender, EventArgs e){
            try{
                var ProductCreate = new Views.ProductCreate();
                ProductCreate.Show();
            }catch(Exception err){
                MessageBox.Show(err.Message);
            }
        }

        private void btUpdate_Click(object sender, EventArgs e){
            try{
                Models.Product product = GetSelectedProduct(Option.Update);
                RefreshList();
                DialogResult r = MessageBox.Show($"Are you sure you want to update the product {product.Id}?", "Update", MessageBoxButtons.YesNo);
                if(r == DialogResult.Yes){
                    var ProductUpdate = new Views.ProductUpdate(product);
                    if(ProductUpdate.ShowDialog() == DialogResult.OK){
                        RefreshList();
                        MessageBox.Show("Product updated successfully");
                    }
                }
            }catch(Exception err){
                MessageBox.Show(err.Message);
            }
        }

        private void btDelete_Click(object sender, EventArgs e){
            try{
                Models.Product product = GetSelectedProduct(Option.Delete);
                RefreshList();
                DialogResult r = MessageBox.Show($"Are you sure you want to delete the product {product.Id}?", "Delete", MessageBoxButtons.YesNo);
                if(r == DialogResult.Yes){
                    Models.Product.delete(product);
                    RefreshList();
                    MessageBox.Show("Product deleted successfully");
                }
            }catch(Exception err){
                MessageBox.Show(err.Message);
            }
        }

        private void btClose_Click(object sender, EventArgs e){
            this.Close();
        }

        public ProductView(){
            
        }
        
    }
}