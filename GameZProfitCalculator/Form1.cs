using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
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

        private async Task loadPriceAsync(string url)
        {
            
            webBrowser1.Url = new Uri(url);
            HtmlWeb web = new HtmlWeb();
            web.UseCookies = true;
            web.LoadFromBrowser(url);
            HtmlAgilityPack.HtmlDocument document = web.Load(url);
            var html = document.DocumentNode.InnerHtml;
            string LMAO = document.Text;
            /*
            HttpClient client = new HttpClient();
           //var nodes = document.DocumentNode.SelectNodes("//[@item=\"market\"]/div[2]").ToList();
            var values = new Dictionary<string, string>
              {
                  { "mainKey", "12068"},
                  { "usingCleint", "0"}
              };

            string fileName = @"./header.txt";
            String[] lines = File.ReadAllLines(fileName);


            Uri myUri = new Uri(url);
            string query_id = HttpUtility.ParseQueryString(myUri.Query).Get("query_id");
            string user = HttpUtility.ParseQueryString(myUri.Query).Get("user");
            string auth_date = HttpUtility.ParseQueryString(myUri.Query).Get("auth_date");
            string hash = HttpUtility.ParseQueryString(myUri.Query).Get("hash");

            var content = new FormUrlEncodedContent(values);

            client.DefaultRequestHeaders.Add("query_id", query_id);
            client.DefaultRequestHeaders.Add("user", user);
            client.DefaultRequestHeaders.Add("auth_date", auth_date);
            client.DefaultRequestHeaders.Add("hash", hash);
            string param ="";

            for(int i = 0; i < lines.Length; i++)
            {
                if (i%2 == 0){
                    param = lines[i].Remove(lines[i].Length - 1, 1);
                }
                else
                {
                    client.DefaultRequestHeaders.Add(param, lines[i]);
                }
            }
            string ok ="oos";
            var response =await client.PostAsync(url, content);
            var responseString = await response.Content.ReadAsStringAsync();
            foreach (Item temp in items)
            {
            }
            */
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

        private void URLBox_TextChanged(object sender, EventArgs e)
        {
            loadPriceAsync(((TextBox)sender).Text);
        }
    }
}