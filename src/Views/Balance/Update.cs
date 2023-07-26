using Models;
using Controllers;
using System.Windows.Forms;

namespace Views{
    public class BalanceUpdate : Form{
        public Label lblid;
        public TextBox txtid;
        public Label lblproductid;
        public TextBox txtproductid;
        public Label lblwarehouseid;
        public TextBox txtwarehouseid;
        public Label lblquantity;
        public TextBox txtquantity;
        public Button btUpdate;

        public Models.Balance balance;

        private void btUpdate_Click(object sender, EventArgs e){
            Models.Balance balanceUpdate = this.balance;
            balanceUpdate.Id = int.Parse(txtid.Text);
            balanceUpdate.ProductId = int.Parse(txtproductid.Text);
            balanceUpdate.WarehouseId = int.Parse(txtwarehouseid.Text);
            balanceUpdate.Quantity = int.Parse(txtquantity.Text);

            try{
                if(balanceUpdate.Id == 0 || balanceUpdate.ProductId == 0 || balanceUpdate.WarehouseId == 0 || balanceUpdate.Quantity == 0 || balanceUpdate.ProductId.ToString().Length > 0 || balanceUpdate.WarehouseId.ToString().Length > 0 || balanceUpdate.Quantity.ToString().Length > 0){
                    MessageBox.Show("You must fill all the fields");
                    return;
                }else{
                    Models.Balance.update(balanceUpdate);
                    MessageBox.Show("Balance updated successfully");
                    ClearForm();
                }
                this.Close();
            }catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }
        
        private void ClearForm(){
            txtid.Text = "";
            txtproductid.Text = "";
            txtwarehouseid.Text = "";
            txtquantity.Text = "";
        }

        public BalanceUpdate(){
            
        }
    }
}