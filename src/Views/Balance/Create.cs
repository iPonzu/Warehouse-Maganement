using Controllers;
using Models;
using Data;

namespace Views{
    public class Balance{
        public Label lblid;
        public TextBox txtid;
        public Label lblproductid;
        public TextBox txtproductid;
        public Label lblwarehouseid;
        public TextBox txtwarehouseid;
        public Label lblquantity;
        public TextBox txtquantity;
        public Button btCreate;

        public void btCreate_Click(object sender, EventArgs e){
            if(txtid.Text == "" || txtproductid.Text == "" || txtwarehouseid.Text == "" || txtquantity.Text == "" || txtproductid.Text.Length > 0 || txtwarehouseid.Text.Length > 0 || txtquantity.Text.Length > 0){
                MessageBox.Show("You must fill all the fields");
                return;
            }else{
                Controllers.Balance.create(int.Parse(txtid.Text), int.Parse(txtproductid.Text), int.Parse(txtwarehouseid.Text), int.Parse(txtquantity.Text));
                MessageBox.Show("Balance created successfully");
                ClearForm();
            }
            View.Balance balanceList = Application.OpenForms.OfType<View.Balance>().FirstOrDefault();
            if(balanceList != null){
                balanceList.RefreshList();
            }
            this.Close();
        }
        
        private void ClearForm(){
            txtid.Text = "";
            txtproductid.Text = "";
            txtwarehouseid.Text = "";
            txtquantity.Text = "";
        }

        public Balance(){
            
        }
    }
}