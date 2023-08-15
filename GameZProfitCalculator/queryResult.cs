using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZProfitCalculator
{
    public class Item
    {
        public int keyType { get; set; }
        public int mainKey { get; set; }
        public int subKey { get; set; }
        public int count { get; set; }
        public string name { get; set; }
        public int grade { get; set; }
        public bool isGodrAyed { get; set; }
        public int mainCategory { get; set; }
        public int subCategory { get; set; }
        public int chooseKey { get; set; }
        public long pricePerOne { get; set; }
        public int totalTradeCount { get; set; }
        public bool godrAyed { get; set; }
    }

    public class queryResult
    {
        public int resultCode { get; set; }
        public string resultMsg { get; set; }
        public List<Item> detailList { get; set; }
    }
}
