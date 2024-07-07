namespace obdz_lb2_2.Models;

public class Movie
{
    public int MovieId { get; set; }
    public string Title { get; set; }
    public TimeSpan Duration { get; set; }
    public string Genre { get; set; }
    public string Description { get; set; }
    public ICollection<Showtime> Showtimes { get; set; }
}