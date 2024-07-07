namespace obdz_lb2_2.Models;

public class Screen
{
    public int ScreenId { get; set; }
    public int TheaterId { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }
    public Theater Theater { get; set; }
    public ICollection<Showtime> Showtimes { get; set; }
}