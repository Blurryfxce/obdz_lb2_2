using Microsoft.EntityFrameworkCore;
using obdz_lb2_2.Models;

namespace obdz_lb2_2;

public class App
{
    public static void DisplayAllData()
    {
        var context = new ApplicationDbContext();
        
        Console.WriteLine("Theaters:");
        foreach (var theater in context.Theaters)
        {
            Console.WriteLine($"{theater.TheaterId} - {theater.Name}");
        }

        Console.WriteLine("Screens:");
        foreach (var screen in context.Screens)
        {
            Console.WriteLine($"{screen.ScreenId} - {screen.Name} (Theater ID: {screen.TheaterId}, Capacity: {screen.Capacity})");
        }

        Console.WriteLine("Movies:");
        foreach (var movie in context.Movies)
        {
            Console.WriteLine($"{movie.MovieId} - {movie.Title} (Duration: {movie.Duration}, Genre: {movie.Genre})");
        }

        Console.WriteLine("Showtimes:");
        foreach (var showtime in context.Showtimes)
        {
            Console.WriteLine($"{showtime.ShowtimeId} - Movie ID: {showtime.MovieId}, Screen ID: {showtime.ScreenId}, Start: {showtime.StartTime}, End: {showtime.EndTime}");
        }

        Console.WriteLine("Viewers:");
        foreach (var viewer in context.Viewers)
        {
            Console.WriteLine($"{viewer.ViewerId} - {viewer.Name} (Email: {viewer.Email}, Phone: {viewer.PhoneNumber})");
        }

        Console.WriteLine("Tickets:");
        foreach (var ticket in context.Tickets)
        {
            Console.WriteLine($"{ticket.TicketId} - Viewer ID: {ticket.ViewerId}, Showtime ID: {ticket.ShowtimeId}");
        }
    }
    
    public static void AddSampleData()
    {
        var context = new ApplicationDbContext();
        
        var theater = new Theater
        {
            Name = "SomeSortOf Theater",
            Address = "123 Bebring Str",
            Phone = "234234234234"
        };

        context.Theaters.Add(theater);

        var screen = new Screen
        {
            Name = "Main Screen",
            Capacity = 200,
            Theater = theater
        };

        context.Screens.Add(screen);

        var movie = new Movie
        {
            Title = "The Boys",
            Duration = new TimeSpan(2, 0, 0),
            Genre = "Action",
            Description = "American superhero web series"
        };

        context.Movies.Add(movie);

        var showtime = new Showtime
        {
            Screen = screen,
            Movie = movie,
            StartTime = DateTime.Now,
            EndTime = DateTime.Now.AddHours(2)
        };

        context.Showtimes.Add(showtime);

        var viewer = new Viewer
        {
            Name = "Johnny Silverhand",
            Email = "jsilver@example.com",
            PhoneNumber = "32242342424"
        };

        context.Viewers.Add(viewer);

        var ticket = new Ticket
        {
            Viewer = viewer,
            Showtime = showtime
        };

        context.Tickets.Add(ticket);

        context.SaveChanges();
    }
}