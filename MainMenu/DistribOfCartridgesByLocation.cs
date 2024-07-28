﻿using CartrigeAltstar.Model;
using System;
using System.Data.Entity;
using System.Linq;
using System.Resources;
using System.Windows.Forms;

namespace CartrigeAltstar
{
    public partial class DistribOfCartridgesByLocation : Form
    {
        private ContexAltstar db = new ContexAltstar();
        private ResourceManager resourceManager;
        private Cartrige CartrigeModel;

        private void DistribOfCartridgesByLocation_Load(object sender, EventArgs e)
        {
            cbDepartment.DataSource = db.Departments.Select(x => x.Name).ToArray();

            TranslateMenu();
        }

        private void TranslateMenu()
        {
            lbCartrige.Text = resourceManager.GetString("Cartrige");
            lbDepartment.Text = resourceManager.GetString("Department");
            gpSearchArticle.Text = resourceManager.GetString("SearchArticle");
            gbListAvilableCartrigeFarSedning.Text = resourceManager.GetString("ListAvilableCartrigeFarSedning");
           this.Text = resourceManager.GetString("tsmiSendToLocation");
        }

        public DistribOfCartridgesByLocation(ResourceManager resourceManager)
        {
            InitializeComponent();
            this.resourceManager = resourceManager;
        }

        private void tbSearchCartrigeArticle_TextChanged(object sender, System.EventArgs e)
        {
            string searchText = tbSearchCartrigeArticle.Text; // Получаем текст из текстового поля
            if (!string.IsNullOrEmpty(searchText))
            {

                //var data = db.Cartriges
                //   .Where(x => x.ArticleCartrige.StartsWith(searchText) && x.IsService != true)
                //   .Select(c => new
                //   {
                //       id = c.Id,
                //       Model = c.ModelCartrige,
                //       Article = c.ArticleCartrige
                //   }).ToList();



                //исключить виборку картриджей из сервиса и те которые уже добавлены в подразделения(таблица Tolocation)
                var data = (from cartrige in db.Cartriges
                            where cartrige.ArticleCartrige.StartsWith(searchText)
                                //  && cartrige.IsService != true
                                  && db.Cartriges.Any(location => location.ArticleCartrige == cartrige.ArticleCartrige)
                            select new
                            {
                                id = cartrige.Id,
                                Model = cartrige.ModelCartrige,
                                Article = cartrige.ArticleCartrige,
                                Count = cartrige.CountCartrige
                                
                            }).ToList();


                if (data.Count > 0)
                {

                    dgvFindArticleResult.DataSource = null;
                    dgvFindArticleResult.DataSource = data;
                }
            }
            else
            {
                dgvFindArticleResult.DataSource = null;
            }
        }

        private void tsbAdd_Click(object sender, EventArgs e) => dgvFindArticleResult_MouseDoubleClick(sender, e as MouseEventArgs);
        private void dgvFindArticleResult_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (dgvFindArticleResult.SelectedRows.Count >0)
            {
                var selectedRow = dgvFindArticleResult.SelectedRows[0];
                tbId.Text = Convert.ToInt32(selectedRow.Cells["id"].Value).ToString();
                tbCaretigeModel.Text = selectedRow.Cells["Model"].Value.ToString();
                tbCartrigeArticle.Text = selectedRow.Cells["Article"].Value.ToString();
            }
        }

        private void okAdd_Click(object sender, EventArgs e)
        {

           

            try
            {
                if (cbDepartment.SelectedItem == null) 
                {
                    MessageBox.Show("Department is not selected!!!");
                    return;
                }
                if (numericUpDown1.Value.ToString() == "0")
                {
                    MessageBox.Show("Виберіть кількість!!!");
                    return;
                }
                

                
                string searchValue = cbDepartment.SelectedItem.ToString();

              //не отслеживать поток данних
                CartrigeModel = db.Cartriges.Where(x => x.ModelCartrige == tbCaretigeModel.Text).AsNoTracking().FirstOrDefault();


                if(CartrigeModel.CountCartrige - int.Parse(numericUpDown1.Value.ToString()) <0)
                {
                    MessageBox.Show($"Для  моделі {CartrigeModel.ModelCartrige}, недостаня кількість, на складі: {CartrigeModel.CountCartrige}");
                    return;
                }

                Cartrigelolocation tolocation = new Cartrigelolocation()
                {
                    Cartrige = tbCaretigeModel.Text,
                    Article = tbCartrigeArticle.Text,
                    Data = dtpData.Value,
                    Department = cbDepartment.SelectedItem.ToString(),
                    CountCartige = int.Parse(numericUpDown1.Value.ToString())
                };

                db = new ContexAltstar();
                db.Cartrigelolocations.Add(tolocation);


                CartrigeModel.CountCartrige -= int.Parse(numericUpDown1.Value.ToString());
                db.Entry(CartrigeModel).State = EntityState.Modified;
              


                db.SaveChanges();

                MessageBox.Show("Sucessfull!!");


                ///проверка наличия картриджа на подраздилениях
                //var chkCartrige = db.Cartrigelolocations.Where(x => x.Article == tbCartrigeArticle.Text).FirstOrDefault();

                //if (chkCartrige == null)
                //{
                //    db = new ContexAltstar();
                //    db.Cartrigelolocations.Add(tolocation);
                //    db.SaveChanges();
                //    MessageBox.Show("Sucessfull!!");

                //}
                //else
                //{
                //    MessageBox.Show("Такой картридж уже на подразделении");
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
         

        }

       
        
    }
}
