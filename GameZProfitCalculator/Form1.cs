using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace GameZProfitCalculator
{
    public partial class Form1 : Form
    {
        private List<Item> items = new List<Item>();
        private language Lan = null;
        private int stackNumber = 50;

        public Form1()
        {
            loadJson();
            loadItemList();
            loadPrice();
            InitializeComponent();
            updateEnhanceChance();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void loadJson()
        {
            string text = File.ReadAllText(@"./DefaultLanguage.json");
            Lan = JsonSerializer.Deserialize<language>(text);
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
                        Item item = new Item(tempStr[1], value);
                        items.Add(item);
                    }
                }
            }
        }

        private void loadPrice()
        {
            string url = "https://ingame-web.gamezbd.com/Market/Login?query_id=AAHwc0QAAwAAAPBzRADgJsmQ&user=%7B%22id%22%3A6446937072%2C%22first_name%22%3A%22NAInfini%22%2C%22last_name%22%3A%22%22%2C%22language_code%22%3A%22en%22%2C%22allows_write_to_pm%22%3Atrue%7D&auth_date=1691418569&hash=43da507e1a0873e405f6c81f01d3c08fb3d665c06997e6ecf51f9f096e11f05f";
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument document = web.Load(url);

            var loginPageUrl = "https://ingame-web.gamezbd.com/Market/list/hot";
            CookieContainer cookieContainer = new CookieContainer();
            var req = (HttpWebRequest)WebRequest.Create(loginPageUrl);
            req.CookieContainer = cookieContainer;
            req.Method = "GET";

            WebResponse resp = req.GetResponse();

            HttpWebResponse response = resp as HttpWebResponse;

            CookieCollection cookies;
            if (response != null)
            {
                cookies = response.Cookies; //Use this cookies in above code to send with username and password.
            }
            var nodes = document.DocumentNode.SelectNodes("//[@item=\"market\"]/div[2]").ToList();

            foreach (var node in nodes)
                Console.WriteLine(node.InnerText);
            foreach (Item temp in items)
            {
            }
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
        }
    }
}