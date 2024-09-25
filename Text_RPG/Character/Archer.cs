namespace TextRPG
{
    class Archer : Character
    {
        public Archer(Character character)
        {
            Name = character.Name;
            Atk = 15;
            Def = 2;
            Hp = 70;
        }
    }

}

