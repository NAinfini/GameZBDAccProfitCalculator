using System;
using System.Collections.Generic;
using System.Linq;

namespace GameZProfitCalculator
{
    class accessory
    {
        public List<Item> allGrades = new List<Item>();
        public int ID;
        public accessory(int otherID)
        {
            ID = otherID;
        }

        public void addItem(Item item)
        {
            if (!allGrades.Any(x => x.subKey == item.subKey))
            {
                allGrades.Add(item);
            }
        }
        public Item getItem(int grade)
        {
            return allGrades.Find(item => item.subKey == grade);
        }
        public long getProfit(int grade)
        {
            if (grade == 0) return -1;
            return Math.Abs(allGrades.Find(item => item.subKey == grade).pricePerOne - allGrades.Find(item => item.subKey == grade - 1).pricePerOne);
        }
        public double getGrossProfit(int finalGrade, double successChance)
        {
            if (finalGrade == 0) return -1;

            long basePrice = allGrades.Find(item => item.subKey == 0).pricePerOne;
            long price1 = allGrades.Find(item => item.subKey == finalGrade - 1).pricePerOne;
            long price2 = allGrades.Find(item => item.subKey == finalGrade).pricePerOne;
            if (successChance > 1) successChance = 1;
            return (price2 - price1 - basePrice) * successChance - (price1 + basePrice) * (1 - successChance);
        }
        public int getLowerCount(int grade)
        {
            return allGrades.Find(item => item.subKey == grade - 1).count;
        }
        public long GetLowerPrice(int grade)
        {
            if (grade == 1 || grade == 16) return allGrades.Find(item => item.subKey == grade).pricePerOne;
            return allGrades.Find(item => item.subKey == grade - 1).pricePerOne;
        }
        public long GetPrice(int grade)
        {
            return allGrades.Find(item => item.subKey == grade).pricePerOne;
        }
        public long GetUpperPrice(int grade)
        {
            if(grade == 5 || grade == 20) return allGrades.Find(item => item.subKey == grade).pricePerOne;
            return allGrades.Find(item => item.subKey == grade + 1).pricePerOne;
        }
    }
}
