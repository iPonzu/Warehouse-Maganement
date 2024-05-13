using Models;
using Controllers;
using Data;

namespace Views{
    public class WarehouseCreate : Form{
        public Label lblid;
        public TextBox txtid;
        public Label lblname;
        public TextBox txtname;
        public Label lbladdress;
        public TextBox txtaddress;
        public Button btCreate;
        public Button btBack;

        public void btCreate_Click(object sender, EventArgs e){
            if(txtid.Text == "" || txtname.Text == "" || txtaddress.Text == "" || txtname.Text.Length > 0 || txtaddress.Text.Length > 0){
                MessageBox.Show("You must fill all the fields");
                return;
            }else{
                Controllers.Warehouse.create(int.Parse(txtid.Text), txtname.Text, txtaddress.Text);
                MessageBox.Show("Warehouse created successfully");
                ClearForm();
            }
            WarehouseView warehouseList = Application.OpenForms.OfType<WarehouseView>().FirstOrDefault();
            if(warehouseList != null){
                warehouseList.RefreshList();
            }
            this.Close();
        }
        public void btBack_click(object sender, EventArgs e){
            this.Close();
            // Menu.Show();
        }

        private void ClearForm(){
            txtid.Text = "";
            txtname.Text = "";
            txtaddress.Text = "";
        }


        public WarehouseCreate(){
            this.Text = "Create Warehouse";
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

            this.lblname = new Label();
            this.lblname.Text = "Name";
            this.lblname.Location = new Point(10, 70);
            
            this.txtname = new TextBox();
            this.txtname.Location = new Point(10, 90);
            this.txtname.Size = new Size(260, 20);

            this.lbladdress = new Label();
            this.lbladdress.Text = "Address";
            this.lbladdress.Location = new Point(10, 120);
            
            this.txtaddress = new TextBox();
            this.txtaddress.Location = new Point(10, 140);
            this.txtaddress.Size = new Size(260, 20);

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
            this.Controls.Add(lblname);
            this.Controls.Add(txtname);
            this.Controls.Add(lbladdress);
            this.Controls.Add(txtaddress);
            this.Controls.Add(btCreate);
            this.Controls.Add(btBack);
            
        }

    }
}