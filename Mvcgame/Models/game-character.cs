using System.ComponentModel.DataAnnotations;

namespace Mvcgame.Models
{
    public class game_character
    {
        [Display (Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "Никнейм")]
        public string nickname { get; set; }

        [Display(Name = "HP")]
        public int max_HP { get; set; }
        public int HP { get; set; }

        [Display(Name = "Броня")]
        public int? ArmorsID { get; set; }
        public Armors? Armors { get; set; }

        [Display(Name = "Оружие")]
        public int? WeaponsID { get; set; }
        public Weapons? Weapons { get; set; }

        [Display(Name = "Зелье")]
        public int? PotionsID { get; set; }
        public Potions? Potions { get; set; }
    }
}
