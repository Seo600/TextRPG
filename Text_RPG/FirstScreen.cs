namespace TextRPG
{
    class FirstScreen()
    {
        string numChoice;
        int num;
        bool success;


        public void InputName()
        {
            Console.Clear();
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("원하시는 이름을 선택해주세요.");
            Program.character.Name = Console.ReadLine();
            Console.WriteLine($"입력하신 이름은 {Program.character.Name} 입니다.\n");
            Console.WriteLine("1. 저장\n2. 취소\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            numChoice = Console.ReadLine();
            success = int.TryParse(numChoice, out num);
            if (success && num > 0 && num < 3)
            {
                switch (num)
                {
                    case 1:
                        Console.WriteLine("저장되었습니다");
                        Thread.Sleep(500);
                        InputChad();
                        break;
                    case 2:
                        Console.WriteLine("취소되었습니다");
                        Thread.Sleep(500);
                        InputName();
                        break;
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(500);
                InputName();
            }
        }

        public void InputChad()
        {
            Console.Clear();
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("원하시는 직업을 선택해주세요.\n");
            Console.WriteLine("1. 도적\n2. 전사\n3. 궁수\n");
            Console.WriteLine("원하시는 행동을 입력하세요.");
            success = int.TryParse(Console.ReadLine(), out num);
            if (success && num > 0 && num < 4)
            {
                switch (num)
                {
                    case 1:
                        Console.WriteLine("도적을 선택하셨습니다.\n");
                        Program.character = new Bandit(Program.character);
                        break;
                    case 2:
                        Console.WriteLine("전사을 선택하셨습니다.\n");
                        Program.character = new Warrior(Program.character);
                        break;
                    case 3:
                        Console.WriteLine("궁수을 선택하셨습니다.\n");
                        Program.character = new Archer(Program.character);
                        break;
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(500);
                InputChad();
            }
            Console.WriteLine("1. 저장\n2. 취소\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            numChoice = Console.ReadLine();
            success = int.TryParse(numChoice, out num);
            if (success && num > 0 && num < 3)
            {
                switch (num)
                {
                    case 1:
                        Console.WriteLine("저장되었습니다");
                        Thread.Sleep(500);

                        //Program.character.inventory.Add(new Item(false, "낡은검", 5, 0, "낡은 검이다."));
                        //Program.character.inventory.Add(new Item(false, "스파르타의 창", 7, 0, "스파르타의 전사들이 사용했다는 전설의 창입니다."));
                        //Program.character.inventory.Add(new Item(false, "무쇠갑옷", 0, 5, "무쇠로 만들어져 튼튼한 갑옷입니다."));
                        Program.village.ListAdd(new Item(false, "수련자 갑옷", 0, 5, "수련에 도움을 주는 갑옷입니다.", 1000, false));
                        Program.village.ListAdd(new Item(false, "무쇠갑옷", 0, 9, "무쇠로 만들어져 튼튼한 갑옷입니다.", 2000, false));
                        Program.village.ListAdd(new Item(false, "스파르타의 갑옷", 0, 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500, false));
                        Program.village.ListAdd(new Item(false, "낡은 검", 2, 0, "쉽게 볼 수 있는 낡은 검 입니다. ", 600, false));
                        Program.village.ListAdd(new Item(false, "청동 도끼", 5, 0, "어디선가 사용됐던거 같은 도끼입니다.", 1500, false));
                        Program.village.ListAdd(new Item(false, "스파르타의 창", 7, 0, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 3000, false));
                        Program.village.ListAdd(new Item(false, "비싼 검", 16, 0, "돈 값을 하는 검이다.", 9999, false));
                        Program.village.ListAdd(new Item(false, "행운의 검", 14, 0, "이 검을 사용하면 운이 좋아질 수도....", 7777, false));

                        Program.village.VillageMenu();
                        break;
                    case 2:
                        Console.WriteLine("취소되었습니다");
                        Thread.Sleep(500);
                        InputChad();
                        break;
                }
                
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(500);
                InputChad();
            }

        }
    }

}

