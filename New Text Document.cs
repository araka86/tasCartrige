//Шаг 2: Ввод данных о покупке картриджей
public void AddCartrigePurchase(int modelId, DateTime purchaseDate, int quantity)
{
    var purchase = new CartrigePurchase
    {
        ModelId = modelId,
        PurchaseDate = purchaseDate,
        Quantity = quantity
    };

    db.CartrigePurchases.Add(purchase);
    db.SaveChanges();
}


//Шаг 3: Ввод данных о выдаче картриджей
public void AddCartrigeIssue(int modelId, DateTime issueDate, int quantity, string department)
{
    var issue = new CartrigeIssue
    {
        ModelId = modelId,
        IssueDate = issueDate,
        Quantity = quantity,
        Department = department
    };

    db.CartrigeIssues.Add(issue);
    db.SaveChanges();
}

//Шаг 4: Расчет статистики использования картриджей
public Dictionary<DateTime, int> GetCartrigeUsageStatistics(int modelId)
{
    Dictionary<DateTime, int> usageStatistics = new Dictionary<DateTime, int>();

    var purchases = db.CartrigePurchases.Where(p => p.ModelId == modelId).OrderBy(p => p.PurchaseDate);
    var issues = db.CartrigeIssues.Where(i => i.ModelId == modelId).OrderBy(i => i.IssueDate);

    int currentStock = 0;
    foreach (var purchase in purchases)
    {
        currentStock += purchase.Quantity;
        usageStatistics[purchase.PurchaseDate] = currentStock;
    }

    foreach (var issue in issues)
    {
        currentStock -= issue.Quantity;
        if (usageStatistics.ContainsKey(issue.IssueDate))
        {
            usageStatistics[issue.IssueDate] = currentStock;
        }
        else
        {
            usageStatistics.Add(issue.IssueDate, currentStock);
        }
    }

    return usageStatistics.OrderByDescending(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
}

//Шаг 5: Отображение статистики
private void DisplayCartrigeUsageStatistics(int modelId, string modelName)
{
    var usageStatistics = GetCartrigeUsageStatistics(modelId);

    ChartValues<int> values = new ChartValues<int>();
    List<string> dates = new List<string>();

    foreach (var data in usageStatistics)
    {
        values.Add(data.Value);
        dates.Add(data.Key.ToShortDateString());
    }

    cartesianChart1.AxisX.Clear();
    cartesianChart1.AxisX.Add(new Axis
    {
        Title = "Dates",
        Labels = dates
    });

    LineSeries lineSeries = new LineSeries
    {
        Title = modelName,
        Values = values
    };

    SeriesCollection series = new SeriesCollection { lineSeries };
    cartesianChart1.Series = series;
}
//Пример использования
private void toolStripMenuItem1_Click(object sender, EventArgs e)
{
    try
    {
        var selectedModel = tscbCartriges.SelectedItem.ToString();
        var modelId = db.CartrigeModels.FirstOrDefault(m => m.ModelName == selectedModel)?.Id;

        if (modelId == null)
        {
            throw new Exception($"Cartridge model {selectedModel} is not found");
        }

        DisplayCartrigeUsageStatistics(modelId.Value, selectedModel);
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
        Console.WriteLine(ex.Message);
    }
}
