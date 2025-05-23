namespace Mvcgame.Models
{
    public class game_character
    {
        public int ID { get; set; }

        public string nickname { get; set; }

        public int max_HP { get; set; }
        public int HP { get; set; }

        public int? armor_ID { get; set; }
        public Armors? Armors { get; set; }

        public int? weapon_ID { get; set; }
        public Weapons? Weapons { get; set; }

        public int? potions_ID { get; set; }
        public Potions? Potions { get; set; }
    }
}
