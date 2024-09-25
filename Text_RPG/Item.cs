namespace TextRPG
{
    public class Item
    {
        string inputNum;
        int num;

        public bool itemE;
        public string itemname;
        public int atk;
        public int def;
        public string explanation;
        public int price;
        public bool storeprice;

        public Item(bool itemE, string itemname, int atk, int def, string explanation)
        {
            this.itemE = itemE;
            this.itemname = itemname;
            this.atk = atk;
            this.def = def;
            this.explanation = explanation;

        }

        public Item(bool itemE, string itemname, int atk, int def, string explanation, int price, bool storeprice)
        {
            this.itemE = itemE;
            this.itemname = itemname;
            this.atk = atk;
            this.def = def;
            this.explanation = explanation;
            this.price = price;
            this.storeprice = storeprice;
        }
    }

}

