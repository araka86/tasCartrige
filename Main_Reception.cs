using CartrigeAltstar.Helpers;
using CartrigeAltstar.MainMenu;
using CartrigeAltstar.Model;
using CartrigeAltstar.Nomenclatura.Cartriges;
//using OxyPlot.Series;
//using OxyPlot;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Windows.Forms;
//using OxyPlot.WindowsForms;
using System.Drawing;
using LiveCharts;
using LiveCharts.Wpf;
using CartrigeAltstar.Nomenclatura.History;
//using System.Windows.Forms.DataVisualization.Charting;

namespace CartrigeAltstar
{
    public partial class main_Reception : Form
    {
        //false - от
        private static bool ChekMode = false;
        private string CultureDefine;
        private ContexAltstar db;
        public ResourceManager resourceManager;

        protected override void OnShown(EventArgs e)
        {



            base.OnShown(e);
            db = new ContexAltstar();
            //   db.Departments.Load();
            //  TranslateMenu();
            //  FillCombobox();
            //   FillDataGrid();
            SetOperationAccess();


            RefreshMainDatagrid(this, null);


        }




        private string currentUserId;

        // Метод для установки текущего UserId из LoginForm
        public void SetCurrentUserId(string userId)
        {
            currentUserId = userId;
        }







        private void SetOperationAccess()
        {
            tsbDelete.Enabled = (dgwMain.Rows.Count > 0) ? true : false;
            tsbUpdate.Enabled = (dgwMain.Rows.Count > 0) ? true : false;
            tsbExport.Enabled = (dgwMain.Rows.Count > 0) ? true : false;
        }









        public main_Reception()
        {
            CultureDefine = CultureInfo.CurrentCulture.Name;

            if (CultureDefine == "uk-UA")
            {
                // Создаем новый объект resourceManager, извлекающий из сборки 
                resourceManager = new ResourceManager("CartrigeAltstar.Resources.langUA", Assembly.GetExecutingAssembly());
            }
            else if (CultureDefine == "en")
            {
                resourceManager = new ResourceManager("CartrigeAltstar.Resources.langEN", Assembly.GetExecutingAssembly());
            }
            else
            {
                resourceManager = new ResourceManager("CartrigeAltstar.Resources.langRU", Assembly.GetExecutingAssembly());
            }

            InitializeComponent();
        }




        private void TranslateMenu()
        {
            tsmiMenu.Text = resourceManager.GetString("tsmiMenu");
            this.Text = resourceManager.GetString("main_Reception");
            tslFilter.Text = resourceManager.GetString("tslFilter");
            tslCartriges.Text = resourceManager.GetString("tslCartriges");
            tslDepartment.Text = resourceManager.GetString("tslDepartment");
            tsbApply.Text = resourceManager.GetString("tsbApply");
            tsbResetFiltr.Text = resourceManager.GetString("tsbReset");
            //tsbChangeMode.Text = ChekMode ? resourceManager.GetString("tsbChangeModeSend") : resourceManager.GetString("tsbChangeModeArrival");
            //tsbChangeMode.ToolTipText = resourceManager.GetString("tsbChangeModeToolTipText");
            tsniPrinters.Text = resourceManager.GetString("tsniPrinters");
            tsmiCartriges.Text = resourceManager.GetString("tslCartriges");
            tsmiDepartment.Text = resourceManager.GetString("tslDepartment");
            tsmenuLanguage.Text = resourceManager.GetString("tsmenuLanguage");
            tsmiSendCartrige.Text = resourceManager.GetString("tsmiSendCartrige");
            tsmiAcceptCartriges.Text = resourceManager.GetString("tsmiAcceptCartriges");
            tsmiSendToLocation.Text = resourceManager.GetString("tsmiSendToLocation");
            tsmiAcceptFromLocation.Text = resourceManager.GetString("tsmiAcceptFromLocation");
            gbCartrigeOnDepartment.Text = resourceManager.GetString("gbCartrigeOnDepartment");
            tsmiUA.Text = resourceManager.GetString("tsmiUA");
            tsmiEn.Text = resourceManager.GetString("tsmiEn");
            tsmiRu.Text = resourceManager.GetString("tsmiRu");
        }




        #region Click Change Language
        private void tsmiUA_Click(object sender, EventArgs e)
        {
            // Устанавливаем выбранную культуру в качестве культуры  пользовательского интерфейса 
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("uk-UA", true);
            // Устанавливаем в качестве текущей культуры выбранную
            Thread.CurrentThread.CurrentCulture = new CultureInfo("uk-UA", true);
            this.Hide();
            new main_Reception().Show();
        }

        private void tsmiRu_Click(object sender, EventArgs e)
        {
            // Устанавливаем выбранную культуру в качестве культуры  пользовательского интерфейса 
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-UA", true);
            // Устанавливаем в качестве текущей культуры выбранную
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-UA".ToString(), true);
            this.Hide();
            new main_Reception().Show();
        }

        private void tsmiEn_Click(object sender, EventArgs e)
        {
            // Устанавливаем выбранную культуру в качестве культуры  пользовательского интерфейса 
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en", true);
            // Устанавливаем в качестве текущей культуры выбранную
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en", true);
            main_Reception main_Reception = new main_Reception();
            this.Hide();
            new main_Reception().Show();
        }
        #endregion

        #region Admin Edit Nomenclatura

        //Edit Printers
        private void tsniPrinters_Click(object sender, EventArgs e)
        {
            var listSettingPinterForm = new ListSettingPinterForm(resourceManager);
            listSettingPinterForm.Show();
        }
        //Edit Cartriges
        private void tsmiCartriges_Click(object sender, EventArgs e)
        {
            var listCartrigeForm = new ListCartrigeForm(resourceManager);
            listCartrigeForm.FormClosing += RefreshMainDatagrid;
            listCartrigeForm.Show();
        }
        //Edit Department
        private void tsmiDepartment_Click(object sender, EventArgs e)
        {
            ListSubdivisionForm listSubdivisionForm = new ListSubdivisionForm(resourceManager);
            listSubdivisionForm.FormClosing += RefreshMainDatagrid;
            listSubdivisionForm.Show();

        }
        #endregion


        #region Fill Data

        public void FillCombobox()
        {
            db = new ContexAltstar();
            var ListCartrige = db.Cartriges.Select(c => c.ModelCartrige).ToList();
            tscbCartriges.ComboBox.DataSource = db.Cartriges.Select(c => c.ModelCartrige).Distinct().ToList();
            tscbDepartment.ComboBox.DataSource = db.Departments.Select(s => s.Name).ToList();



            List<string> cartrigeModels = db.Cartriges.Select(c => c.ModelCartrige).Distinct().ToList();
            cartrigeModels.Insert(0, "select_item");
            tscbCartriges.ComboBox.DataSource = cartrigeModels;

            List<string> departmentModels = db.Departments.Select(c => c.Name).Distinct().ToList();
            departmentModels.Insert(0, "select_item");
            tscbDepartment.ComboBox.DataSource = departmentModels;

        }

        private void FillDataGrid()
        {
            try
            {
                db = new ContexAltstar();
                dgwMain.DataSource = db.Cartrigelolocations.Local.ToBindingList();
                dgwMain.Columns["Id"].Width = 35;
                dgwMain.Columns["Data"].Width = 80;
                dgwMain.Columns["Data"].DefaultCellStyle.Format = "dd.MM.yyyy";
                dgwMain.Columns["Article"].Width = 80;
                dgwMain.Columns["Cartrige"].Width = 80;
                dgwMain.Columns["Department"].Width = 300;

                dgwMain.Columns["CountCartige"].Width = 30;


                dgwMain.Columns["Status"].Visible = false;
                dgwMain.Columns["Weight"].Visible = false;
                db.Cartrigelolocations.Load();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        #endregion


        #region Отправка/Прием Сервис

        private void tsmiSendCartrige_Click(object sender, EventArgs e)
        {
            SendingForFilling sendingForFilling = new SendingForFilling(resourceManager, true);
            if (sendingForFilling.ShowDialog() != DialogResult.OK)
                return;
        }

        private void tsmiAcceptCartriges_Click(object sender, EventArgs e)
        {
            var sendingForFilling = new SendingForFilling(resourceManager, false);
            DialogResult result = sendingForFilling.ShowDialog();
            if (result == DialogResult.Cancel) return;
        }
        #endregion

        #region Отправка/Прием Локации
        private void tsbAdd_Click(object sender, EventArgs e) => tsmiSendToLocation_Click(sender, e);
        private void tsmiSendToLocation_Click(object sender, EventArgs e)
        {
            var distribOfCartridgesByLocation = new DistribOfCartridgesByLocation(resourceManager);
            distribOfCartridgesByLocation.FormClosing += RefreshMainDatagrid;
            distribOfCartridgesByLocation.Show();

        }

        /// update whenForm will be Closed
        private void RefreshMainDatagrid(object sender, FormClosingEventArgs e)
        {
            db.Cartrigelolocations.Load();
            dgwMain.DataSource = db.Cartrigelolocations.Local.ToBindingList();

            FillCombobox();
            SetOperationAccess();
        }



        private void tsmiAcceptFromLocation_Click(object sender, EventArgs e)
        {
            var acceptСartridgesFromLocations = new AcceptСartridgesFromLocations(resourceManager);
            DialogResult result = acceptСartridgesFromLocations.ShowDialog();
            if (result != DialogResult.OK)
            {
                dgwMain.DataSource = db.Cartrigelolocations.ToList();
                return;
            }
        }
        #endregion



        private void tsUpdateButton_Click(object sender, EventArgs e) => dgwMain.DataSource = db.Cartrigelolocations.ToList();
        //private void tsbChangeMode_Click(object sender, EventArgs e)
        //{
        //    tsbChangeMode.Text = ChekMode ? resourceManager.GetString("tsbChangeModeSend") : resourceManager.GetString("tsbChangeModeArrival");
        //    ChekMode = !ChekMode;
        //}

        //export
        private void tsbExport_Click(object sender, EventArgs e) => ExelHelper.MyExportExel(dgwMain, true, resourceManager.GetString("ListOfCartrige"));


        private void tsbUpdate_Click(object sender, EventArgs e)
        {



            var uid = this.currentUserId;

            if (dgwMain.SelectedRows.Count > 0)
            {
                var getDatagridrow = dgwMain.SelectedRows[0];
                int idValue = int.Parse(getDatagridrow.Cells["id"].Value.ToString());

                var updateCartrigeLocation = new UpdateCartrigeLocation(idValue);
                if (updateCartrigeLocation.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Item is updated");
                    RefreshMainDatagrid(this, null);

                }


            }
        }



        private void tsbDelete_Click(object sender, EventArgs e)
        {

            try
            {
                if (dgwMain.SelectedRows.Count > 0)
                {
                    var getDatagridrow = dgwMain.SelectedRows[0];
                    int idValue = int.Parse(getDatagridrow.Cells["id"].Value.ToString());
                    DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить запись?", "Подтверждение удаления", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {




                        db.Cartrigelolocations.Remove(db.Cartrigelolocations.Find(idValue));

                        db.SaveChanges();
                        MessageBox.Show("Запись удалена!!!");
                        dgwMain.DataSource = db.Cartrigelolocations.ToList();
                        SetOperationAccess();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void tsb_ClickFilter(object sender, EventArgs e)
        {
            db.Cartrigelolocations.Load();
            if (tscbCartriges.SelectedItem.ToString() != "select_item"
                && tscbDepartment.SelectedItem.ToString() != "select_item")
            {
                dgwMain.DataSource = db.Cartrigelolocations.Local.ToBindingList().Where(x => x.Cartrige == tscbCartriges.SelectedItem.ToString() &&
               x.Department == tscbDepartment.SelectedItem.ToString()).ToList().OrderBy(y => y.Data).ToArray().OrderBy(y => y.Data).ToArray();
            }
            else if (tscbCartriges.SelectedItem.ToString() != "select_item")
            {


                dgwMain.DataSource = db.Cartrigelolocations.Where(x => x.Cartrige == tscbCartriges.SelectedItem.ToString())
                    .OrderBy(y => y.Data).ToArray();
            }
            else
            {

                dgwMain.DataSource = db.Cartrigelolocations.Local.ToBindingList().Where(x => x.Department == tscbDepartment.SelectedItem.ToString()).ToList()
                    .OrderBy(y => y.Data).ToArray(); ;
            }



        }

        private void tsbResetFiltr_Click(object sender, EventArgs e) => RefreshMainDatagrid(this, null);





        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {



            //SeriesCollection series  = new SeriesCollection();
            //ChartValues<int> sportsValues = new ChartValues<int>();
            //List<string> dates = new List<string>();
            //int[] val = { 5, 2, 3, 6, 10 };
            //int i = 0;
            //foreach (var data in val)
            //{
            //    // var cart = data.ModelCartrige;
            //    sportsValues.Add(data);
            //    dates.Add(DateTime.Now.AddDays(i).ToShortDateString().ToString());
            //    i++;
            //}

            //cartesianChart1.AxisX.Clear();
            //cartesianChart1.AxisX.Add(new Axis
            //{
            //    Title = "Dates",
            //    Labels = dates
            //});
            //LineSeries line = new LineSeries();
            //line.Title = "canon725";
            //line.Values = sportsValues;
            //series.Add(line);   
            //cartesianChart1.Series = series;



            //SeriesCollection series2 = new SeriesCollection();
            //ChartValues<int> sportsValues2 = new ChartValues<int>();
            //List<string> dates2 = new List<string>();
            //int[] val2 = { 2, 3, 5, 9, 7 };
            //int i2 = 0;
            //foreach (var data in val2)
            //{
            //    // var cart = data.ModelCartrige;
            //    sportsValues2.Add(data);

            //    i2++;
            //}



            //LineSeries line2 = new LineSeries();
            //line2.Title = "canon726";
            //line2.Values = sportsValues2;
            //series2.Add(line2);
            //cartesianChart1.Series = series2;




            //    SeriesCollection series = new SeriesCollection();





            //// Первая линия
            //ChartValues<int> sportsValues = new ChartValues<int>();
            //List<string> dates = new List<string>();
            //int[] val = { 10, 8, 7, 6, 5,2 };
            //int i = 0;
            //foreach (var data in val)
            //{
            //    sportsValues.Add(data);
            //    dates.Add(DateTime.Now.AddDays(i).ToShortDateString());
            //    i++;
            //}

            //cartesianChart1.AxisX.Clear();
            //cartesianChart1.AxisX.Add(new Axis
            //{
            //    Title = "Dates",
            //    Labels = dates
            //});

            //LineSeries line1 = new LineSeries
            //{
            //    Title = "canon725",
            //    Values = sportsValues
            //};
            //series.Add(line1);

            //// Вторая линия
            //ChartValues<int> sportsValues2 = new ChartValues<int>();
            //int[] val2 = { 10, 7, 6, 3, 2,0 };
            //foreach (var data in val2)
            //{
            //    sportsValues2.Add(data);
            //}

            //LineSeries line2 = new LineSeries
            //{
            //    Title = "canon726",
            //    Values = sportsValues2
            //};
            //series.Add(line2);

            //// Присваиваем общий SeriesCollection графику
            //cartesianChart1.Series = series;


            //try
            //{





            //    SeriesCollection series = new SeriesCollection();

            //    Dictionary<DateTime, int> keyValuePairs = new Dictionary<DateTime, int>();

            //    //    var testDate = db.Cartrigelolocations.Select(x => x.Data.Value.ToShortDateString).ToArray();
            //    var tstto = dtp_from.Value;
            //    var tstFrom = dtp_to.Value;

            //    var selectedCartrige = tscbCartriges.SelectedItem.ToString();



            //    if (!db.Cartrigelolocations.Any(x => x.Cartrige == selectedCartrige))
            //        throw new Exception($"Cartridge {selectedCartrige} is not found");




            //    //находим по датам в уже отправленних локациях
            //    var startCountBuy = db.Cartrigelolocations
            //        .Where(y => y.Data >= dtp_from.Value && y.Data <= dtp_to.Value && y.Cartrige == selectedCartrige)
            //        .Sum(x => x.CountCartige);

            //    // находим колличество на момент(дата) пополнения
            //    var startDataBuy = db.CountCartiges.Where(y => y.ModelCartrige == selectedCartrige).FirstOrDefault();

            //    var startDataBuy2 = db.CountCartiges.Where(y => y.ModelCartrige == selectedCartrige).ToArray();


            //    // добавляем первое значение
            //    //  keyValuePairs.Add(startDataBuy.purchase_date.Value, startDataBuy.CountCartrige);
            //    keyValuePairs.Add(startDataBuy2[0].purchase_date.Value, startDataBuy2[0].CountCartrige);
            //    var statrtitem = startDataBuy2[0].CountCartrige;

            //    keyValuePairs.Add(startDataBuy2[1].purchase_date.Value, startDataBuy2[1].CountCartrige);

            //    var statrtitem2 = startDataBuy2[1].CountCartrige;




            //    foreach (var item in db.Cartrigelolocations)
            //    {

            //        if (item.Cartrige == selectedCartrige)
            //        {
            //            if (startDataBuy2[1].purchase_date >= dtp_from.Value)
            //            {
            //                keyValuePairs.Add(item.Data.Value, statrtitem2 - item.CountCartige);
            //            }
            //            else
            //            {
            //                keyValuePairs.Add(item.Data.Value, statrtitem - item.CountCartige);
            //            }




            //        }


            //    }



            //    keyValuePairs.OrderByDescending(kvp => kvp.Key);

            //    // Сортировка по дате в порядке убывания
            //    var sortedKeyValuePairs = keyValuePairs.OrderBy(kvp => kvp.Key).ToList();







            //    // Первая линия
            //    ChartValues<int> sportsValues = new ChartValues<int>();
            //    List<string> dates = new List<string>();

            //    int i = 0;

            //    foreach (var data in sortedKeyValuePairs)
            //    {
            //        sportsValues.Add(data.Value);
            //        dates.Add(data.Key.ToShortDateString());
            //        i++;
            //    }
            //    cartesianChart1.AxisX.Clear();
            //    cartesianChart1.AxisX.Add(new Axis
            //    {
            //        Title = "Dates",
            //        Labels = dates
            //    });

            //    LineSeries line1 = new LineSeries
            //    {
            //        Title = "ТК-3160",
            //        Values = sportsValues
            //    };
            //    series.Add(line1);
            //    // Присваиваем общий SeriesCollection графику
            //    cartesianChart1.Series = series;




            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //    return;
            //}




            try
            {
                DisplayAllCartrigeUsageStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
            }

        }


        public Dictionary<DateTime, Dictionary<string, int>> GetAllCartrigeUsageStatistics()
        {
            var usageStatistics = new SortedDictionary<DateTime, Dictionary<string, int>>();
            var models = db.CartrigeModels.ToList();

            foreach (var model in models)
            {
                var modelStats = new Dictionary<DateTime, int>();
                int currentStock = 0;

                var purchases = db.CartrigePurchases
                    .Where(p => p.ModelId == model.Id)
                    .OrderBy(p => p.PurchaseDate)
                    .ToList();

                var issues = db.CartrigeIssues
                    .Where(i => i.ModelId == model.Id)
                    .OrderBy(i => i.IssueDate)
                    .ToList();

                foreach (var purchase in purchases)
                {
                    currentStock += purchase.Quantity;
                    modelStats[purchase.PurchaseDate] = currentStock;
                }

                foreach (var issue in issues)
                {
                    if (modelStats.ContainsKey(issue.IssueDate))
                    {
                        modelStats[issue.IssueDate] -= issue.Quantity;
                    }
                    else
                    {
                        currentStock -= issue.Quantity;
                        modelStats[issue.IssueDate] = currentStock;
                    }
                }

                foreach (var entry in modelStats.OrderBy(e => e.Key))
                {
                    if (!usageStatistics.ContainsKey(entry.Key))
                    {
                        usageStatistics[entry.Key] = new Dictionary<string, int>();
                    }
                    usageStatistics[entry.Key][model.ModelName] = entry.Value;
                }
            }

            return usageStatistics.OrderBy(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }



        private void DisplayAllCartrigeUsageStatistics()
        {
            var usageStatistics = GetAllCartrigeUsageStatistics();

            cartesianChart1.AxisX.Clear();
            cartesianChart1.Series.Clear();

            var seriesDict = new Dictionary<string, ChartValues<int>>();
            List<string> dates = new List<string>();

            foreach (var dateEntry in usageStatistics)
            {
                dates.Add(dateEntry.Key.ToShortDateString());

                foreach (var modelEntry in dateEntry.Value)
                {
                    if (!seriesDict.ContainsKey(modelEntry.Key))
                    {
                        seriesDict[modelEntry.Key] = new ChartValues<int>();
                    }
                    seriesDict[modelEntry.Key].Add(modelEntry.Value);
                }
            }

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Dates",
                Labels = dates
            });

            SeriesCollection seriesCollection = new SeriesCollection();
            foreach (var seriesEntry in seriesDict)
            {
                seriesCollection.Add(new LineSeries
                {
                    Title = seriesEntry.Key,
                    Values = seriesEntry.Value
                });
            }

            cartesianChart1.Series = seriesCollection;
        }




























        private void tsddbutton_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dtpFrom = dtp_from.Value;
            var dtpTo = dtp_to.Value;


        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var _listHistoryForms = new ListHistoryForms();
            _listHistoryForms.FormClosing += RefreshMainDatagrid;
            _listHistoryForms.Show();
        }
    }
}
