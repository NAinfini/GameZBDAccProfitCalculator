using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using HtmlAgilityPack;
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
            string text = File.ReadAllText(@"./DefaultLanguage.json");
            Lan = JsonSerializer.Deserialize<language>(text);
            EveCheck.Text = Lan.eveCheckText;
            PreCheck.Text = Lan.preCheckText;
            stackCountLbl.Text = Lan.SClblText;
            updateBtn.Text = Lan.updateBtnText;
            dataGridView1.Columns[0].HeaderText = Lan.ItemIDText;
            dataGridView1.Columns[1].HeaderText = Lan.ItemNameText;
            dataGridView1.Columns[2].HeaderText = Lan.ItemGradeText;
            dataGridView1.Columns[3].HeaderText = Lan.ItemProfitText;
            dataGridView1.Columns[4].HeaderText = Lan.ItemGrossText;

        }

        private void loadItemList()
        {
            string fileName = @"./Items.txt";
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
            HttpClient cl = new HttpClient() { BaseAddress = new Uri(url) };
            HttpResponseMessage response = await cl.GetAsync(url);
            HttpRequestMessage request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri("https://ingame-web.gamezbd.com/Market/GetWorldMarketSubList");
            foreach(int id in Ids)
            {
                request.Content = new StringContent("mainKey="+id+"&usingCleint=0", Encoding.UTF8, "application/x-www-form-urlencoded");
                response = await cl.SendAsync(request);
                string jsonResponse = await response.Content.ReadAsStringAsync();
                queryResult tempResult = JsonSerializer.Deserialize<queryResult>(jsonResponse);
                items = new List<Item>();
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
            }
        }

        private void EveCheck_CheckedChanged(object sender, EventArgs e)
        {
            updateEnhanceChance();
        }

        private void PreCheck_CheckedChanged(object sender, EventArgs e)
        {
            updateEnhanceChance();
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
                    dataGridView1.Rows.Add(tempItem.mainKey, tempItem.name, tempItem.subKey, getProfit(tempItem).ToString("N"), getGrossProfit(tempItem).ToString("N"));
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
            
            foreach (Item tempItem in items)
            {
                if (tempItem.mainKey.Equals(item.mainKey) && (tempItem.subKey + 1).Equals(item.subKey))
                {
                    double chance = getEnhanceChance(item.subKey);
                    if (chance > 1)
                    {
                        return item.pricePerOne - tempItem.pricePerOne;
                    }
                    else
                    {
                        return chance * (item.pricePerOne - tempItem.pricePerOne);
                    }
                }
            }
            return -1;
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
    }
}