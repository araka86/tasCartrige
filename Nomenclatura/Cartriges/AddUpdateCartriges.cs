using CartrigeAltstar.Model;
using System;
using System.Data.Entity;
using System.Linq;
using System.Resources;

using System.Windows.Forms;

namespace CartrigeAltstar.Nomenclatura.Cartriges
{
    public partial class AddUpdateCartriges : Form
    {

        private ResourceManager resourceManager;
        ContexAltstar db;

        
        private readonly int? id;
        private Cartrige CartrigeModel;
        private CountCartige _countCartige;
        private Cartrigelolocation _cartrigelolocation;
       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_resourceManager">языковая среда</param>
        /// <param name="_id">присутствие  id означает что картридж будет обновлен </param>
        public AddUpdateCartriges(ResourceManager _resourceManager,int? _id)
        {
            InitializeComponent();
            db = new ContexAltstar();
            resourceManager = _resourceManager;
            
            id = _id;

            

            txbAddCntCtr.KeyPress += new KeyPressEventHandler(txbAddCntCtr_Press);
        }

        private void txbAddCntCtr_Press(object sender, KeyPressEventArgs e)
        {
            // Проверяем, является ли введенный символ цифрой или управляющим символом (например, Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Если введенный символ не является цифрой или управляющим символом, отменяем ввод
                e.Handled = true;
            }
        }

        private void AddCartriges_Load(object sender, System.EventArgs e)
        {
            try
            {
                if (id != null && id != 0)
                {
                    CartrigeModel = db.Cartriges.Find(id);
                    dtpDatetimeCartrige.Text = CartrigeModel.purchase_date.ToString();
                    tbModelCartrige.Text = CartrigeModel.ModelCartrige;
                    tbArticleCartrige.Text = CartrigeModel.ArticleCartrige;
                    lblcntCartige.Text = CartrigeModel.CountCartrige.ToString();
        
                }

                this.Text = id == null ? resourceManager.GetString("AddCartigeModal") : resourceManager.GetString("UpdateCartigeModal");
                lblArticle.Text = resourceManager.GetString("lblArticle");
                lblModel.Text = resourceManager.GetString("lblModel");
                lblDatePurchase.Text = resourceManager.GetString("lblDatePurchase");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        
        }

        private void AddCartriges_FormClosing(object sender, FormClosingEventArgs e)
        {

            if(id==null) 
            {
                if (this.DialogResult == DialogResult.OK)
                    e.Cancel = !this.SaveData();
            }
            else 
            {
                if (this.DialogResult == DialogResult.OK)
                    e.Cancel = !this.UpdateData();
            }
        }

        private bool SaveData() 
        {

            try
            {

                //Check
                if (!string.IsNullOrEmpty(tbArticleCartrige.Text) && !string.IsNullOrEmpty(tbArticleCartrige.Text) )
                {
                    CartrigeModel = new Cartrige();
                    CartrigeModel.purchase_date = dtpDatetimeCartrige.Value;
                    CartrigeModel.ModelCartrige = tbModelCartrige.Text;
                    CartrigeModel.ArticleCartrige = tbArticleCartrige.Text;
                    CartrigeModel.CountCartrige += int.Parse(txbAddCntCtr.Text);
                    db.Cartriges.Add(CartrigeModel);
                    db.SaveChanges();
                    MessageBox.Show(resourceManager.GetString("AddNewCartrigeMsgBox"));
                }
                else
                {
                    MessageBox.Show(resourceManager.GetString("ChekFieldMessage"));
                    return false;
                }

            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return true;
        } 

        private bool UpdateData() 
        {

            var id =  this.id;

            try
            {
                if (!string.IsNullOrEmpty(tbArticleCartrige.Text) && !string.IsNullOrEmpty(tbArticleCartrige.Text))
                {
                    CartrigeModel.purchase_date = dtpDatetimeCartrige.Value;
                    CartrigeModel.ModelCartrige = tbModelCartrige.Text;
                    CartrigeModel.ArticleCartrige = tbArticleCartrige.Text;
                    CartrigeModel.CountCartrige += int.Parse(txbAddCntCtr.Text);
                    
                    db.Entry(CartrigeModel).State = EntityState.Modified;

                    //////add


                    _cartrigelolocation = new Cartrigelolocation()
                    {
                        Status = "+",
                        Cartrige = CartrigeModel.ModelCartrige,
                        Data = dtpDatetimeCartrige.Value,
                        CountCartige = CartrigeModel.CountCartrige,
                        Department = "office"
                        

                        
                    };
                    db.Cartrigelolocations.Add(_cartrigelolocation);
                    db.SaveChanges();

                    //var tmpCart = db.Cartriges.FirstOrDefault(x => x.Id == this.id);

                    //_countCartige = new CountCartige();


                    //_countCartige.CartrigeId = tmpCart.Id;
                    //_countCartige.purchase_date = dtpDatetimeCartrige.Value;
                    //_countCartige.ModelCartrige = tbModelCartrige.Text;
                    //_countCartige.CountCartrige = CartrigeModel.CountCartrige;
                    //db.CountCartiges.Add(_countCartige);
                    //db.SaveChanges();


                    MessageBox.Show(resourceManager.GetString("ChekFieldMessageUpdate"));
                }
                else 
                {
                    MessageBox.Show(resourceManager.GetString("ChekFieldMessage"));
                    return false;
                } 

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }       
            return true;

        }


    }
}
