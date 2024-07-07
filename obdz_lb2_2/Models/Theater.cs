namespace obdz_lb2_2.Models;

public class Theater
{
    public int TheaterId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public ICollection<Screen> Screens { get; set; }
}
   