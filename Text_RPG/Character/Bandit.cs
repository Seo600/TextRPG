namespace TextRPG
{
    class Bandit : Character
    {
        public Bandit(Character character)
        {
            Name = character.Name;
            Atk = 12;
            Def = 3;
            Hp = 70;
        }

        public override void Stat()
        {
            base.Stat();
        }
    }

}

