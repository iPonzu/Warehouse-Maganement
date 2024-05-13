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
        public Button btBack;

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
        public void btBack_click(object sender, EventArgs e){
            this.Close();
            // Menu.Show();
        }


        private void ClearForm(){
            txtid.Text = "";
            txtname.Text = "";
            txtprice.Text = "";
        }

        public ProductCreate(){
            this.Text = "Create Product";
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
            this.lblname.Location = new Point(10, 80);
            
            this.txtname = new TextBox();
            this.txtname.Location = new Point(10, 110);
            this.txtname.Size = new Size(260, 20);

            this.lblprice = new Label();
            this.lblprice.Text = "Price";
            this.lblprice.Location = new Point(10, 150);
            
            this.txtprice = new TextBox();
            this.txtprice.Location = new Point(10, 170);
            this.txtprice.Size = new Size(260, 20);

            this.btCreate = new Button();
            this.btCreate.Text = "Create";
            this.btCreate.Location = new Point(10, 270);
            this.btCreate.Size = new Size(100, 30);
            this.btCreate.Click += new EventHandler(this.btCreate_Click);

            this.btBack = new Button();
            this.btBack.Text = "Back";
            this.btBack.Location = new Point(170, 270);
            this.btBack.Size = new Size(100, 30);
            this.btBack.Click += new EventHandler(this.btBack_click);

            this.Controls.Add(lblid);
            this.Controls.Add(txtid);
            this.Controls.Add(lblname);
            this.Controls.Add(txtname);
            this.Controls.Add(lblprice);
            this.Controls.Add(txtprice);
            this.Controls.Add(btCreate);
            this.Controls.Add(btBack);
            
        }
    }
}