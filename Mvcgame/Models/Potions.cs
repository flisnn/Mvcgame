namespace Mvcgame.Models
{
    public class Potions
    {
        public int ID { get; set; }
        public int protection { get; set; }
        public int damage { get; set; }
        public int heal { get; set; }
        public ICollection<game_character> game_Characters { get; set; } = new List<game_character>();
    }
}
