namespace obdz_lb2_2.Models;

public class Viewer
{
    public int ViewerId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public ICollection<Ticket> Tickets { get; set; }
}