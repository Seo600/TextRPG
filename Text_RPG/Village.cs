namespace TextRPG
{
    class Village
    {
        private string inputNum;
        private int num;
        bool success;
        string item = "";
        public Item[] stuffs = new Item[10];
        int count = 0;


        public void VillageMenu()
        {
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
            Console.WriteLine("1. 상태 보기 \n2. 인벤토리 \n3. 상점\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>>");

            inputNum = Console.ReadLine();
            success = int.TryParse(inputNum, out num);
            if (success && num > 0 && num < 4)
            {
                switch (num)
                {
                    case 1:
                        VillageMenuOne();
                        break;
                    case 2:
                        VillageMenuTwo();
                        break;
                    case 3:
                        VillageMenuThree();
                        break;
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다");
                Thread.Sleep(500);
                VillageMenu();
            }
        }

        //인터페이스로 만들면 어떨까요??
        void VillageMenuOne() //1번 상태창
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("상태  보기");
            Console.ResetColor();
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
            Program.character.Stat();
            Console.WriteLine("0. 나가기\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>>");
            inputNum = Console.ReadLine();
            if (int.TryParse(inputNum, out num) && num == 0)
            {
                VillageMenu();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다");
                Thread.Sleep(500);
                VillageMenuOne();
            }
        }

        void VillageMenuTwo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("인벤토리");
            Console.ResetColor();
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
            Console.WriteLine("아이템 목록");

            for (int i = 0; i < Program.character.inventory.Count; i++)
            {
                Console.WriteLine(Program.character.ItemString(i));
            }

            Console.WriteLine("\n1. 장착 관리\n2. 나가기\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>>");
            inputNum = Console.ReadLine();
            if (int.TryParse(inputNum, out num) && num > 0 && num < 3)
            {
                switch (num)
                {
                    case 1:
                        InventoryTakeMenu();
                        break;
                    case 2:
                        VillageMenu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(500);
                VillageMenuTwo();
            }
        }

        public void InventoryTakeMenu()
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("인벤토리 - 장착 관리");
            Console.ResetColor();
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
            Console.WriteLine("아이템 목록");
            for (int i = 0; i < Program.character.inventory.Count; i++)
            {
                Console.WriteLine(Program.character.ItemString(i));
            }

            Console.WriteLine("\n0. 나가기\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>>");

            inputNum = Console.ReadLine();
            if (int.TryParse(inputNum, out num) && num >= 0 && num <= Program.character.inventory.Count)
            {
                if (num == 0) { Program.village.VillageMenu(); }
                else if (num > Program.character.inventory.Count && num < 0) {
                    Console.WriteLine("잘못된 입력입니다");
                    Thread.Sleep(500);
                    InventoryTakeMenu();
                }
                for(int i = 1; i <= Program.character.inventory.Count; i++)
                {
                    if(num == i)
                    {
                        if (Program.character.inventory[i-1].itemE == false)
                        {
                            Console.WriteLine("장착완료");
                            Thread.Sleep(500);
                            Program.character.inventory[i-1].itemE = true;
                            if (Program.character.inventory[i-1].atk > 0)
                            {
                                Console.WriteLine("Atk");
                                Program.character.Atk += Program.character.inventory[i - 1].atk;
                            }
                            else
                            {
                                Console.WriteLine("Def");
                                Program.character.Def += Program.character.inventory[i - 1].def;
                            }

                            InventoryTakeMenu();
                        }
                        else
                        {
                            Console.WriteLine("장착 해제");
                            Thread.Sleep(500);
                            Program.character.inventory[i-1].itemE = false;
                            if (Program.character.Atk > 0)
                            {
                                Program.character.Atk -= Program.character.inventory[i - 1].atk;
                            }
                            else if (Program.character.Def > 0)
                            {
                                Program.character.Def -= Program.character.inventory[i - 1].def;
                            }
                            InventoryTakeMenu();
                        }
                    }
                }
                
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다");
                Thread.Sleep(500);
                InventoryTakeMenu();
            }
        }

        public void VillageMenuThree()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("상점");
            Console.ResetColor();
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine(Program.character.Gold + " G\n");
            Console.WriteLine("[아이템 목록]");
            for(int i = 0; i < count; i++)
            {
                Console.WriteLine(ItemStuff(i));
            }

            Console.WriteLine("\n1. 아이템 구매\n0. 나가기\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>>");
            inputNum= Console.ReadLine();
            if(int.TryParse(inputNum, out num) && num == 0 || num == 1)
            {
                switch (num)
                {
                    case 0:
                        VillageMenu();
                        break;
                    case 1:
                        VillageMenuThree_One();
                        break;
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다");
                Thread.Sleep(500);
                VillageMenuThree();
            }
        }

        public void VillageMenuThree_One()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("상점 - 아이템 구매");
            Console.ResetColor();
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine(Program.character.Gold + " G\n");
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(ItemStuff_I(i, (i+1)));
            }

            Console.WriteLine("\n0. 나가기\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>>");
            inputNum = Console.ReadLine();
            if(int.TryParse(inputNum, out num) && num <= count && num >= 0)
            {
                if(num == 0)
                {
                    Thread.Sleep(500);
                    VillageMenu();
                }
                for(int i = 0; i < count; i++)
                {
                    if(num == (i+1))
                    {
                        if (stuffs[i].storeprice == false)
                        {
                            if(Program.character.Gold >= stuffs[i].price)
                            {
                                Console.WriteLine("구매를 완료했습니다.");
                                stuffs[i].storeprice = true;
                                Program.character.Gold -= stuffs[i].price;
                                Program.character.inventory.Add(stuffs[i]);
                                Thread.Sleep(500);
                                VillageMenuThree_One();
                            }
                            else
                            {
                                Console.WriteLine("Gold 가 부족합니다. ");
                                Thread.Sleep(500);
                                VillageMenuThree_One();
                            }
                        }
                        else
                        {
                            Console.WriteLine("이미 구매한 아이템입니다");
                            Thread.Sleep(500);
                            VillageMenuThree_One();
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다");
                Thread.Sleep(500);
                VillageMenuThree_One();
            }
        }

        public string ItemStuff(int i)
        {

            if (stuffs[i].storeprice == false)
            {
                if (stuffs[i].atk > 0)
                {
                    item = "-  "  + " " + stuffs[i].itemname.PadRight(12) + "  ㅣ " + "공격력 +" + stuffs[i].atk + " ㅣ " + stuffs[i].explanation.PadRight(12) + "ㅣ  " + stuffs[i].price + " G";
                }
                else
                {
                    item = "-  "  + " " + stuffs[i].itemname.PadRight(12) + "  ㅣ " + "방어력 +" + stuffs[i].def + " ㅣ " + stuffs[i].explanation.PadRight(12) + "ㅣ  " + stuffs[i].price + " G";
                }
            }
            else if (stuffs[i].storeprice == true)
            {
                if (stuffs[i].atk > 0)
                {
                    item = "-  " + " " + stuffs[i].itemname.PadRight(12) + "  ㅣ " + "공격력 +" + stuffs[i].atk + " ㅣ " + stuffs[i].explanation.PadRight(12) + "ㅣ  "+ "구매완료";
                }
                else
                {
                    item = "-  "  + " " + stuffs[i].itemname.PadRight(12) + "  ㅣ " + "방어력 +" + stuffs[i].def + " ㅣ " + stuffs[i].explanation.PadRight(12) + "ㅣ  " + "구매완료";
                }
            }

            return item;
        }

        public string ItemStuff_I(int i, int a)
        {

            if (stuffs[i].storeprice == false)
            {
                if (stuffs[i].atk > 0)
                {
                    item = "-  " + (a) + " " + stuffs[i].itemname.PadRight(12) + "  ㅣ " + "공격력 +" + stuffs[i].atk + " ㅣ " + stuffs[i].explanation.PadRight(12) + "ㅣ  " + stuffs[i].price + " G";
                }
                else
                {
                    item = "-  " + (a) + " " + stuffs[i].itemname.PadRight(12) + "  ㅣ " + "방어력 +" + stuffs[i].def + " ㅣ " + stuffs[i].explanation.PadRight(12) + "ㅣ  " + stuffs[i].price + " G";
                }
            }
            else if (stuffs[i].storeprice == true)
            {
                if (stuffs[i].atk > 0)
                {
                    item = "-  " + (a) + " " + stuffs[i].itemname.PadRight(12) + "  ㅣ " + "공격력 +" + stuffs[i].atk + " ㅣ " + stuffs[i].explanation.PadRight(12) + "ㅣ  " + "구매완료";
                }
                else
                {
                    item = "-  " + (a) + " " + stuffs[i].itemname.PadRight(12) + "  ㅣ " + "방어력 +" + stuffs[i].def + " ㅣ " + stuffs[i].explanation.PadRight(12) + "ㅣ  " + "구매완료";
                }
            }

            return item;
        }


        public void ListAdd(Item item)
        {
            stuffs[count] = item;
            count++;
        }
    }

}

