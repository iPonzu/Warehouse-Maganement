using Controllers;
using Models;
using System.Windows.Forms;

namespace Views{
    public class BalanceCreate : Form{
        public Label lblid;
        public TextBox txtid;
        public Label lblproductid;
        public TextBox txtproductid;
        public Label lblwarehouseid;
        public TextBox txtwarehouseid;
        public Label lblquantity;
        public TextBox txtquantity;
        public Button btCreate;
        public Button btBack;

        private void btCreate_Click(object sender, EventArgs e){
            if(txtid.Text == "" || txtproductid.Text == "" || txtwarehouseid.Text == "" || txtquantity.Text == "" || txtproductid.Text.Length > 0 || txtwarehouseid.Text.Length > 0 || txtquantity.Text.Length > 0){
                MessageBox.Show("You must fill all the fields");
                return;
            }else{
                Controllers.Balance.create(int.Parse(txtid.Text), int.Parse(txtproductid.Text), int.Parse(txtwarehouseid.Text), int.Parse(txtquantity.Text));
                MessageBox.Show("Balance created successfully");
                ClearForm();
            }
            BalanceView balanceList = Application.OpenForms.OfType<BalanceView>().FirstOrDefault();
            if(balanceList != null){
                balanceList.RefreshList();
            }
            this.Close();
        }

        private void btBack_click(object sender, EventArgs e){
            this.Close();
            // Menu.Show();
        }
        
        private void ClearForm(){
            txtid.Text = "";
            txtproductid.Text = "";
            txtwarehouseid.Text = "";
            txtquantity.Text = "";
        }

        public BalanceCreate(){
            this.Text = "Create Balance";
            this.Size = new System.Drawing.Size(800, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.Size = new System.Drawing.Size(300, 360);

            this.lblid = new Label();
            this.lblid.Text = "ID";
            this.lblid.Location = new Point(10, 20);
            
            this.txtid = new TextBox();
            this.txtid.Location = new Point(10, 40);
            this.txtid.Size = new Size(260, 20);

            this.lblquantity = new Label();
            this.lblquantity.Text = "Quantity";
            this.lblquantity.Location = new Point(10, 80);

            this.txtquantity = new TextBox();
            this.txtquantity.Location = new Point(10, 110);
            this.txtquantity.Size = new Size(260, 20);

            this.lblproductid = new Label();
            this.lblproductid.Text = "Product ID";
            this.lblproductid.Location = new Point(10, 150);

            this.txtproductid = new TextBox();
            this.txtproductid.Location = new Point(10, 170);
            this.txtproductid.Size = new Size(260, 20);

            this.btCreate = new Button();
            this.btCreate.Text = "Create";
            this.btCreate.Location = new Point(10, 270);
            this.btCreate.Size = new Size(100, 30);
            this.btCreate.Click += new EventHandler(btCreate_Click);

            this.btBack = new Button();
            this.btBack.Text = "Back";
            this.btBack.Location = new Point(170, 270);
            this.btBack.Size = new Size(100, 30);
            this.btBack.Click += new EventHandler(btBack_click);

            this.Controls.Add(lblid);
            this.Controls.Add(txtid);
            this.Controls.Add(lblquantity);
            this.Controls.Add(txtquantity);
            this.Controls.Add(lblproductid);
            this.Controls.Add(txtproductid);
            this.Controls.Add(btCreate);
            this.Controls.Add(btBack);
            
        }
    }
}