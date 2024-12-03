namespace GamePractice
{
    public class PlayerCharacter
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int n_XP { get; set; } //XP Needed to level to the next level
        public int cur_XP { get; set; } //Current XP gained
        public Dictionary<string, int> Stats { get; set; }

        public PlayerCharacter(string name, int level)
        {
            Name = name;
            Level = level;
            Stats = new Dictionary<string, int>()
            {
                {"Strenght", 10 },
                {"Agility", 10 },
                {"Intelligence", 10 }
            };
            Health = CalculateMaxHealth();
            Mana = CalculateMaxMana();
            n_XP = CalculateXPToLevel();
            cur_XP = 0;


        }

        public int CalculateMaxHealth()
        {
            return 100 + (Stats["Strenght"] * 5);
        }

        public int CalculateMaxMana()
        {
            return 50 + (Stats["Intelligence"] * 3);
        }

        public int CalculateXPToLevel()
        {
            if(Level == 1)
                return 100;
            else            
                return 100 * ((Level / 5) + 1);
        }

        public void LevelUp()
        {
            Level++;
            cur_XP = 0;
            n_XP = CalculateXPToLevel();
            foreach (var key in Stats.Keys.ToList())
            {
                Stats[key] += 2;
            }
            Health = CalculateMaxHealth();
            Mana = CalculateMaxMana();
            Console.WriteLine($"{Name} leveled up! Now at level {Level}.");
        }

        public void ModifyStat(string stat, int value)
        {
            if (Stats.ContainsKey(stat))
                Stats[stat] += value;
            else
                Stats[stat] = value;
            
        }

        //Method to handle xp gain and to level up
        public void GainXP(int xp)
        {
            Console.WriteLine($"{Name} gained {xp} XP!");
            cur_XP += xp;

            while (cur_XP >= n_XP)
            {
                cur_XP -= n_XP;
                LevelUp();
            }
        }
    }


}
