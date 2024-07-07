namespace obdz_lb2_2.Models;

public class Ticket
{
    public int TicketId { get; set; }
    public int ViewerId { get; set; }
    public int ShowtimeId { get; set; }
    public Viewer Viewer { get; set; }
    public Showtime Showtime { get; set; }
}