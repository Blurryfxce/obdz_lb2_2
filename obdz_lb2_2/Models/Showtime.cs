namespace obdz_lb2_2.Models;

public class Showtime
{
    public int ShowtimeId { get; set; }
    public int ScreenId { get; set; }
    public int MovieId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Screen Screen { get; set; }
    public Movie Movie { get; set; }
    public ICollection<Ticket> Tickets { get; set; }
}