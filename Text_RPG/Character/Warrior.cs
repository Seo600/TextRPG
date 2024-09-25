namespace TextRPG
{
    class Warrior : Character
    {
        public Warrior(Character character)
        {
            Name = character.Name;
            Atk = 10;
            Def = 5;
            Hp = 100;
        }

        public override void Stat()
        {
            base.Stat();
        }
    }

}

