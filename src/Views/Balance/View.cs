using Models;
using Controllers;
using System;

namespace Views{
    public class BalanceView : Form{
        public enum Option {Update, Delete}

        ListView balanceList;

        private void AddListView(Models.Balance balance){
            string [] row = {
                balance.Id.ToString(),
                balance.ProductId.ToString(),
                balance.WarehouseId.ToString(),
                balance.Quantity.ToString()
            };
            ListViewItem item = new ListViewItem(row);
            balanceList.Items.Add(item);
        }

        public void RefreshList(){
            balanceList.Items.Clear();
            List<Models.Balance> balances = Models.Balance.Read();
            foreach(Models.Balance balance in balances){
                AddListView(balance);
            }
        }
        
        public Models.Balance GetSelectedBalance (Option option){
            if(balanceList.SelectedItems.Count > 0){
                int selectedBalance = int.Parse(balanceList.SelectedItems[0].Text);
                return Models.Balance.ReadById(selectedBalance);
            }else{
                throw new Exception($"Select an item to {(option == Option.Update ? "update" : "delete")})");
            }     
        }

        private void btCreate_Click(object sender, EventArgs e){
            try{
                var BalanceCreate = new Views.BalanceCreate();
                BalanceCreate.Show();
            }catch(Exception err){
                MessageBox.Show(err.Message);
            }
        }
        
        private void btUpdate_Click(object sender, EventArgs e){
            try{
                Models.Balance balance = GetSelectedBalance(Option.Update);
                RefreshList();
                DialogResult r = MessageBox.Show($"Are you sure you want to update the balance {balance.Id}?", "Update", MessageBoxButtons.YesNo);
                if(r == DialogResult.Yes){
                    var BalanceUpdate = new Views.BalanceUpdate(balance);
                    if(BalanceUpdate.ShowDialog() == DialogResult.OK){
                        RefreshList();
                        MessageBox.Show("Balance updated successfully");
                    }
                }
            }catch(Exception err){
                MessageBox.Show(err.Message);
            }
        }
        private void btDelete_Click(object sender, EventArgs e){
            try{
                Models.Balance balance = GetSelectedBalance(Option.Delete);
                RefreshList();
                DialogResult r = MessageBox.Show($"Are you sure you want to delete the balance {balance.Id}?", "Delete", MessageBoxButtons.YesNo);
                if(r == DialogResult.Yes){
                    Controllers.Balance.delete(balance.Id);
                    RefreshList();
                    MessageBox.Show("Balance deleted successfully");
                }
            }catch(Exception err){
                MessageBox.Show("We could not update this product, try again later" + err.Message);
            }
        }
        private void btClose_Click(object sender, EventArgs e){
            this.Close();
        }

        public BalanceView(){

        }

    }
}