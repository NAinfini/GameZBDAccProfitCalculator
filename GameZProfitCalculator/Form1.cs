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
        private List<accessory> items = new List<accessory>();
        private List<int> Ids = new List<int>();
        private language Lan = null;
        private int stackNumber = 50;
        private List<long> enhancementPrices = new List<long>();
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
            try
            {
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
            }
            catch (Exception E)
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
            items = new List<accessory>();
            HttpClient cl = new HttpClient() { BaseAddress = new Uri(url) };
            HttpResponseMessage response = await cl.GetAsync(url);
            /*int MemoryFragmentID = 44195;
            int BlackStoneWeaponID = 16001;
            int BlackStoneArmorID = 16002;
            int ConcentratedBlackStoneWeaponID = 16004;
            int ConcentratedBlackStoneArmorID = 16005;*/
            int[] arr = new int[] { 44195, 16001, 16002, 16004, 16005 };
            Ids.Add(719898);//fallen god
            Ids.Add(11017);//tree armor
            Ids.Add(719901);//black star hel
            foreach (int id in Ids)
            {
                items.Add(new accessory(id));
                HttpRequestMessage request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri("https://ingame-web.gamezbd.com/Market/GetWorldMarketSubList");
                request.Content = new StringContent("mainKey=" + id + "&usingCleint=0", Encoding.UTF8, "application/x-www-form-urlencoded");
                response = await cl.SendAsync(request);
                string jsonResponse = await response.Content.ReadAsStringAsync();
                queryResult tempResult = JsonSerializer.Deserialize<queryResult>(jsonResponse);
                foreach (Item tempItem in tempResult.detailList)
                {
                    items.Find(x => x.ID == tempItem.mainKey).addItem(tempItem);
                }
            }
            foreach (int id in arr)
            {
                HttpRequestMessage request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri("https://ingame-web.gamezbd.com/Market/GetWorldMarketSubList");
                request.Content = new StringContent("mainKey=" + id + "&usingCleint=0", Encoding.UTF8, "application/x-www-form-urlencoded");
                response = await cl.SendAsync(request);
                string jsonResponse = await response.Content.ReadAsStringAsync();
                queryResult tempResult = JsonSerializer.Deserialize<queryResult>(jsonResponse);
                foreach (Item tempItem in tempResult.detailList)
                {
                    enhancementPrices.Add(tempItem.pricePerOne);
                }
            }
            enhancementPrices.Add(enhancementPrices[((int)EnhancementItems.ConcentratedBlackStoneArmorID)] + enhancementPrices[((int)EnhancementItems.ConcentratedBlackStoneArmorID)]);
            enhancementPrices.Add(enhancementPrices[((int)EnhancementItems.FlawlessMagicalBlackStone)] + 4000000);
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

            updateEnhancementProcedure();
        }

        private void updateEnhancementProcedure()
        {
            if (enhancementPrices.Count == 0) return;
            List<string>  enhancementProcedure = new List<string>();
            double enhancementPrice=0;
            int enhancementStack = 20;
            while(enhancementStack < stackNumber)
            {
                double tempPrice=double.MaxValue;
                double efficiency = double.MinValue;
                string tempString="";
                int numberOfStack = 0;
                for(int i = 2; i < 6; i++)
                {
                    double oppotunityCost = 0;
                    oppotunityCost = getOppotunityCost(enhancementPrice, getArmorEnhancementChance(i, enhancementStack), items.Find(x => x.ID == 11017).GetLowerPrice(i+15), 
                        items.Find(x => x.ID == 11017).GetUpperPrice(i+15), items.Find(x => x.ID == 11017).GetPrice(i+15), 
                        enhancementPrices[((int)EnhancementItems.ConcentratedBlackStoneArmorID)], 2*enhancementPrices[((int)EnhancementItems.MemoryFragment)]);
                    if (efficiency < oppotunityCost/(i+1))
                    {
                        numberOfStack = i + 1;
                        efficiency = oppotunityCost / (i + 1);
                        tempPrice = enhancementPrices[((int)EnhancementItems.ConcentratedBlackStoneArmorID)]+ 2 * enhancementPrices[((int)EnhancementItems.MemoryFragment)];
                        tempString = "Grade" + i + " tap Boss Gear";
                    }
                    oppotunityCost = getOppotunityCost(enhancementPrice, getBlackStarENhancementChance(i, enhancementStack), items.Find(x => x.ID == 719901).GetLowerPrice(i +15),
                         items.Find(x => x.ID == 719901).GetUpperPrice(i +15), items.Find(x => x.ID == 719901).GetPrice(i +15),
                         enhancementPrices[((int)EnhancementItems.FlawlessMagicalBlackStone)], 4 * enhancementPrices[((int)EnhancementItems.MemoryFragment)]);
                    if (efficiency < oppotunityCost / (i + 1))
                    {
                        numberOfStack = i + 1;
                        efficiency = oppotunityCost / (i + 1);
                        tempPrice = enhancementPrices[((int)EnhancementItems.FlawlessMagicalBlackStone)]+ 4 * enhancementPrices[((int)EnhancementItems.MemoryFragment)];
                        tempString = "Grade" + i + " tap Black Star";
                    }
                    oppotunityCost = getOppotunityCost(enhancementPrice, getFallenGodEnhancementChance(i, enhancementStack), items.Find(x => x.ID == 719898).GetLowerPrice(i),
                        items.Find(x => x.ID == 719898).GetUpperPrice(i), items.Find(x => x.ID == 719898).GetPrice(i),
                        enhancementPrices[((int)EnhancementItems.FlawlessChaoticMagicalBlackStone)], 6 * enhancementPrices[((int)EnhancementItems.MemoryFragment)]);
                    if (efficiency < oppotunityCost / (i + 1))
                    {
                        numberOfStack = i + 1;
                        efficiency = oppotunityCost / (i + 1);
                        tempPrice = enhancementPrices[((int)EnhancementItems.FlawlessChaoticMagicalBlackStone)]+ 6 * enhancementPrices[((int)EnhancementItems.MemoryFragment)];
                        tempString = "Grade" + i + " tap Fallen God";
                    }
                }
                enhancementProcedure.Add(tempString);
                enhancementStack += numberOfStack;
                enhancementPrice += tempPrice;
            }
            SPPricelbl.Text = enhancementPrice.ToString("N0");
            string toPring = "";
            foreach(string tempStr in enhancementProcedure)
            {
                toPring += tempStr;
                toPring += "\n";
            }
            SPDescriptionlbl.Text = toPring.ToString();
        }

        private void updateDataGridView()
        {
            dataGridView1.Rows.Clear();
            List<int> notShow = new List<int>() {719898,11017, 719901 };
            foreach (var acc in items)
            {
                foreach (var tempItem in acc.allGrades)
                {
                    if (notShow.Contains(tempItem.mainKey)) continue;
                    int itemGrade = tempItem.subKey;
                    if (itemGrade != 0 /*&& acc.getLowerCount(itemGrade) != 0*/)
                    {
                        dataGridView1.Rows.Add(tempItem.mainKey.ToString(), acc.getLowerCount(itemGrade), tempItem.name, tempItem.subKey.ToString(), acc.getProfit(itemGrade).ToString("N0"), acc.getGrossProfit(itemGrade, getEnhanceChance(itemGrade,stackNumber)).ToString("N0"));
                    }
                }
            }
            dataGridView1.Update();
        }

        private double getEnhanceChance(int grade,int stacks)
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
                return (25 + stacks * 0.5 * multiplier) / 100;
            }
            else if (grade == 2)
            {
                return (10 + stacks * 0.5 * multiplier) / 100;
            }
            else if (grade == 3)
            {
                return (7.5 + stacks * 0.5 * multiplier) / 100;
            }
            else if (grade == 4)
            {
                return (2.5 + stacks * 0.5 * multiplier) / 100;
            }
            else if (grade == 5)
            {
                return (0.5 + stacks * 0.5 * multiplier) / 100;
            }
            else
            {
                return -1;
            }
        }

        private double getArmorEnhancementChance(int grade,int stacks)
        {
            double multiplier = 1;
            if (EveCheck.Checked) multiplier *= 1.2;
            if (PreCheck.Checked) multiplier *= 1.3;
            if (grade == 1)
            {
                return (11.76 + stacks * 0.5 * multiplier) / 100;
            }
            else if (grade == 2)
            {
                return (7.69 + stacks * 0.5 * multiplier) / 100;
            }
            else if (grade == 3)
            {
                return (6.25 + stacks * 0.5 * multiplier) / 100;
            }
            else if (grade == 4)
            {
                return (2 + stacks * 0.5 * multiplier) / 100;
            }
            else if (grade == 5)
            {
                return (0.3 + stacks * 0.5 * multiplier) / 100;
            }
            else
            {
                return -1;
            }
        }
        private double getFallenGodEnhancementChance(int grade, int stacks)
        {
            double multiplier = 1;
            if (EveCheck.Checked) multiplier *= 1.2;
            if (PreCheck.Checked) multiplier *= 1.2;
            if (grade == 1)
            {
                return (2 + stacks * 0.2 * multiplier) / 100;
            }
            else if (grade == 2)
            {
                return (1+ stacks * 0.2 * multiplier) / 100;
            }
            else if (grade == 3)
            {
                return (0.5 + stacks * 0.2 * multiplier) / 100;
            }
            else if (grade == 4)
            {
                return (0.2 + stacks * 0.2 * multiplier) / 100;
            }
            else if (grade == 5)
            {
                return (0.0025 + stacks * 0.2 * multiplier) / 100;
            }
            else
            {
                return -1;
            }
        }
        private double getBlackStarENhancementChance(int grade,int stacks)
        {
            double multiplier = 1;
            if (EveCheck.Checked) multiplier *= 1.2;
            if (PreCheck.Checked) multiplier *= 1.2;
            if (grade == 1)
            {
                return (13.08 + stacks * 0.2 * multiplier) / 100;
            }
            else if (grade == 2)
            {
                return (10.63 + stacks * 0.2 * multiplier) / 100;
            }
            else if (grade == 3)
            {
                return (3.4 + stacks * 0.2 * multiplier) / 100;
            }
            else if (grade == 4)
            {
                return (0.51 + stacks * 0.2 * multiplier) / 100;
            }
            else if (grade == 5)
            {
                return (0.2 + stacks * 0.2 * multiplier) / 100;
            }
            else
            {
                return -1;
            }
        }
        private double getOppotunityCost(double StackCost,double SuccessChance,double LowerPrice,double UpperPrice,double OrigionalPrice,double Material,double Memory)
        {
            double tempdou = SuccessChance * (UpperPrice - OrigionalPrice - StackCost - Material) + (1 - SuccessChance) * (LowerPrice - OrigionalPrice - Material - Memory);
            return tempdou;
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
                else if (number1 > number2)
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

    internal enum EnhancementItems
    {
        MemoryFragment = 0,
        BlackStoneWeapon = 1,
        BlackStoneArmor = 2,
        ConcentratedBlackStoneWeapon = 3,
        ConcentratedBlackStoneArmorID = 4,
        FlawlessMagicalBlackStone = 5,
        FlawlessChaoticMagicalBlackStone = 6
    }
}