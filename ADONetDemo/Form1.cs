using System;
using System.Windows.Forms;

namespace ADONetDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

     

        ProductDAL _productDAL = new ProductDAL();

        private void Form1_Load(object sender, EventArgs e)
        {
            //Tüm verileri çekip ekranda gösteriyor.
            LoadProducts();
        }

        private void LoadProducts()
        {
            dgwProducts.DataSource = _productDAL.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDAL.Add(new Product
            {
                Name = tbxName.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                StockAmount = Convert.ToInt32(tbxStockAmount.Text),
            });
            LoadProducts(); 
            MessageBox.Show("Product Add!"); 
        }
     

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUnitPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                ID = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                Name = tbxNameUpdate.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text)

            };
            _productDAL.Update(product);
            LoadProducts(); 
            MessageBox.Show("Updated!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value);
            _productDAL.Delete(ID);
            LoadProducts();
            MessageBox.Show("Deleted!");
        }
    }
}
