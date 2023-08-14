namespace GameZProfitCalculator
{
    internal class Item
    {
        public int itemID;
        public string itemName;
        public int[] itemPrice;
        public int itemCount;

        public Item()
        {
            itemID = -1;
            itemName = "";
            itemPrice = new int[6];
            itemCount = -1;
        }

        public Item(string name, int ID)
        {
            itemID = ID;
            itemName = name;
            itemPrice = new int[6];
            itemCount = -1;
        }
    }
}