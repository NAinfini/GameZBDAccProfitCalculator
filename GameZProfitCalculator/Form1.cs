using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace GameZProfitCalculator
{
    public partial class Form1 : Form
    {
        private List<Item> items = new List<Item>();
        private List<int> Ids = new List<int>();
        private language Lan = null;
        private int stackNumber = 50;
        public Form1()
        {
            InitializeComponent();
            loadJson();
            loadItemList();
            updateEnhanceChance();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void loadJson()
        {
            try{
                string text = File.ReadAllText(@"./DefaultLanguage.json");
                Lan = JsonSerializer.Deserialize<language>(text);
                EveCheck.Text = Lan.eveCheckText;
                PreCheck.Text = Lan.preCheckText;
                stackCountLbl.Text = Lan.SClblText;
                updateBtn.Text = Lan.updateBtnText;
                dataGridView1.Columns[0].HeaderText = Lan.ItemIDText;
                dataGridView1.Columns[1].HeaderText = Lan.ItemCountText;
                dataGridView1.Columns[2].HeaderText = Lan.ItemNameText;
                dataGridView1.Columns[3].HeaderText = Lan.ItemGradeText;
                dataGridView1.Columns[4].HeaderText = Lan.ItemProfitText;
                dataGridView1.Columns[5].HeaderText = Lan.ItemGrossText;
            }catch (Exception E)
            {
                MessageBox.Show(Lan.noFile + "\"" + "DefaultLanguage.json" + "\"");
            }
            

        }

        private void loadItemList()
        {
            string fileName = @"./Items.txt";
            if (!File.Exists(fileName))
            {
                FileStream fs = File.Create(fileName);
                MessageBox.Show(Lan.noFile + "\"" + "items.json" + "\"");
                Close();
            }
            String[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                if (!line.Contains(':'))
                {
                    MessageBox.Show(Lan.NoColumnError + "\"" + line + "\"");
                }
                else
                {
                    string[] tempStr = line.Split(':');

                    if (!int.TryParse(tempStr[0], out int value))
                    {
                        MessageBox.Show(Lan.NotAInt + "\"" + line + "\"");
                    }
                    else
                    {
                        Ids.Add(value);
                    }
                }
            }
        }

        private async Task loadPriceAsync(string url)
        {
            items = new List<Item>();
            HttpClient cl = new HttpClient() { BaseAddress = new Uri(url) };
            HttpResponseMessage response = await cl.GetAsync(url);
            foreach(int id in Ids)
            {
                HttpRequestMessage request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri("https://ingame-web.gamezbd.com/Market/GetWorldMarketSubList");
                request.Content = new StringContent("mainKey="+id+"&usingCleint=0", Encoding.UTF8, "application/x-www-form-urlencoded");
                response = await cl.SendAsync(request);
                string jsonResponse = await response.Content.ReadAsStringAsync();
                queryResult tempResult = JsonSerializer.Deserialize<queryResult>(jsonResponse);
                foreach(Item tempItem in tempResult.detailList)
                {
                    items.Add(tempItem);
                }
            }
            updateDataGridView();
        }

        private void StackNoBox_TextChanged(object sender, EventArgs e)
        {
            TextBox Bo = (TextBox)sender;
            if (!int.TryParse(Bo.Text, out int value))
            {
                Bo.Text = stackNumber.ToString();
            }
            else
            {
                stackNumber = value;
                updateEnhanceChance();
                updateDataGridView();
            }
        }

        private void EveCheck_CheckedChanged(object sender, EventArgs e)
        {
            updateEnhanceChance();
            updateDataGridView();
        }

        private void PreCheck_CheckedChanged(object sender, EventArgs e)
        {
            updateEnhanceChance();
            updateDataGridView();
        }

        private void updateEnhanceChance()
        {
            double multiplier = 1;
            if (EveCheck.Checked)
            {
                multiplier *= 1.2;
            }
            if (PreCheck.Checked)
            {
                multiplier *= 1.3;
            }

            EnhanceChanceLbl.Text = "Pri : " + (25 + stackNumber * 0.5 * multiplier) + "%\n" +
                                    "Duo : " + (10 + stackNumber * 0.5 * multiplier) + "%\n" +
                                    "Tri : " + (7.5 + stackNumber * 0.5 * multiplier) + "%\n" +
                                    "Tet : " + (2.5 + stackNumber * 0.5 * multiplier) + "%\n" +
                                    "Pen : " + (0.5 + stackNumber * 0.5 * multiplier) + "%\n";
        }

        private void updateDataGridView()
        {
            dataGridView1.Rows.Clear();
            foreach (var tempItem in items)
            {
                if(tempItem.subKey!=0)
                {
                    dataGridView1.Rows.Add(tempItem.mainKey.ToString(), getLowerCount(tempItem),tempItem.name, tempItem.subKey.ToString(), getProfit(tempItem).ToString("N0"), getGrossProfit(tempItem).ToString("N0"));
                }
            }
            dataGridView1.Update();
        }

        private long getProfit(Item item)
        {
            foreach(Item tempItem in items)
            {
                if (tempItem.mainKey.Equals(item.mainKey) && (tempItem.subKey + 1).Equals(item.subKey))
                {
                    return item.pricePerOne - tempItem.pricePerOne;
                }
            }
            return -1;
        }

        private double getGrossProfit(Item item)
        {
            double basePrice=0;
            double lowerPrice=0;
            
            foreach (Item tempItem in items)
            {
                if (tempItem.mainKey.Equals(item.mainKey) && (tempItem.subKey + 1).Equals(item.subKey))
                {
                    lowerPrice = tempItem.pricePerOne;
                }
                if (tempItem.mainKey.Equals(item.mainKey) && tempItem.subKey == 0)
                {
                    basePrice = tempItem.pricePerOne;
                }

                if( basePrice !=0 && lowerPrice != 0)
                {
                    double chance = getEnhanceChance(item.subKey);
                    if (chance > 1)
                    {
                        return item.pricePerOne - basePrice - lowerPrice;
                    }
                    else
                    {
                        return chance * (item.pricePerOne - basePrice - lowerPrice);
                    }
                }
                
            }
            return -1;
        }

        private string getLowerCount(Item item)
        {
            foreach (Item tempItem in items)
            {
                if (tempItem.mainKey.Equals(item.mainKey) && (tempItem.subKey + 1).Equals(item.subKey))
                {
                    return tempItem.count.ToString();
                }
            }
            return "-1";
        }
        private double getEnhanceChance(int grade)
        {
            double multiplier = 1;
            if (EveCheck.Checked)
            {
                multiplier *= 1.2;
            }
            if (PreCheck.Checked)
            {
                multiplier *= 1.3;
            }
            if (grade == 1)
            {
                return (25 + stackNumber * 0.5 * multiplier) / 100;
            }
            else if(grade == 2)
            {
                return (10 + stackNumber * 0.5 * multiplier) / 100;
            }else if(grade == 3)
            {
                return (7.5 + stackNumber * 0.5 * multiplier) / 100;
            }else if(grade == 4)
            {
                return (2.5 + stackNumber * 0.5 * multiplier) / 100;
            }
            else if(grade == 5)
            {
                return (0.5 + stackNumber * 0.5 * multiplier) / 100;
            }
            else
            {
                return -1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadPriceAsync(URLBox.Text);
        }

        private void dataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            double number1;
            double number2;
            if (double.TryParse((string)e.CellValue1, out number1) && double.TryParse((string)e.CellValue2, out number2))
            {
                if (number1 < number2)
                {
                    e.SortResult = 1;
                }
                else if(number1 > number2)
                {
                    e.SortResult = -1;
                }
                else
                {
                    e.SortResult = 0;
                }
            }
            else
            {
                e.SortResult = System.String.Compare(
            e.CellValue1.ToString(), e.CellValue2.ToString());
            }

            // If the cells are equal, sort based on the ID column.
            if (e.SortResult == 0 && e.Column.Name != "ItemID")
            {
                e.SortResult = System.String.Compare(
                    dataGridView1.Rows[e.RowIndex1].Cells["ItemID"].Value.ToString(),
                    dataGridView1.Rows[e.RowIndex2].Cells["ItemID"].Value.ToString());
            }
            e.Handled = true;
        }
    }
}