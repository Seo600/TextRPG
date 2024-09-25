namespace TextRPG
{
    class Character //캐릭터 정보
    {
        public int Lv { get; set; } = 1;
        public string Name { get; set; }
        public int Atk { get; set; }
        public int? AtkE { get; set; } = null;
        public int Def { get; set; }
        public int? DefE { get; set; } = null;
        public int Hp { get; set; }
        public int Gold { get; set; } = 10000;
        

        public List<Item> inventory = new List<Item>();
        public string item;
        string ename;

        private int count = 0;


        public virtual void Stat()
        {
            Console.WriteLine($"Lv. {Lv}");
            Console.WriteLine($"이름 ( {Name} )");
            Console.WriteLine($"공격력 : {Atk}");
            Console.WriteLine($"방어력 : {Def}");
            Console.WriteLine($"체 력 : {Hp}");
            Console.WriteLine($"Gold :  {Gold}G\n");
        }

        public string ItemString(int i)
        {
            if (inventory[i].itemE == false)
            {
                if (inventory[i].atk > 0)
                {
                    item = "-  " + (i + 1) + " " + inventory[i].itemname.PadRight(12) + "  ㅣ " + "공격력 +" + inventory[i].atk + " ㅣ " + inventory[i].explanation;
                }
                else
                {
                    item = "-  " + (i + 1) + " " + inventory[i].itemname.PadRight(12) + "  ㅣ " + "방어력 +" + inventory[i].def + " ㅣ " + inventory[i].explanation;
                }
            }
            else if (inventory[i].itemE == true)
            {
                if (inventory[i].atk > 0)
                {

                    item = "-  " + (i + 1) + " [E]" + inventory[i].itemname.PadRight(12) + "  ㅣ " + "공격력 +" + inventory[i].atk + " ㅣ " + inventory[i].explanation;
                }
                else
                {
                    item = "-  " + (i + 1) + " [E]" + inventory[i].itemname.PadRight(12) + "  ㅣ " + "방어력 +" + inventory[i].def + " ㅣ " + inventory[i].explanation;
                }
            }

            return item;
        }
        
    }

}

