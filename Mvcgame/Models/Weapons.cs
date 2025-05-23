namespace Mvcgame.Models
{
    public class Weapons
    {
        public int ID { get; set; }
        public int damage { get; set; }
        public int durability { get; set; }//прочность
        public int max_durability { get; set; }//максимальная прочность
        public ICollection<game_character> game_Characters { get; set; } = new List<game_character>();
    }
}
