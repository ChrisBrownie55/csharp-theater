using System;
using theater.Models;

namespace theater {
  class Program {
    static void Main(string[] args) {
      Console.Clear();

      Theater theater = new Theater("Edwards Theater");
      theater.Initialize();

      Movie titanic = new Movie("Titanic");
      theater.AddRoom(titanic, 50);
      theater.AddShowTime(0, "12:00PM");
      theater.AddShowTime(0, "02:00PM");
      theater.AddShowTime(0, "04:00PM");

      Movie starwars = new Movie("Star Wars");
      theater.AddRoom(starwars, 50);
      theater.AddShowTime(1, "09:00AM");
      theater.AddShowTime(1, "09:00PM");

      Movie deadpool = new Movie("Deadpool");
      theater.AddRoom(deadpool, 50);
      theater.AddShowTime(2, "03:00PM");

      Console.WriteLine($"Welcome to the {theater.Name} (h for help, q to leave).");

      bool open = true;
      while (open) {
        Console.Write("> ");
        switch (Console.ReadLine()) {
          case "h":
            Console.WriteLine(@"Help Menu
  h: help menu, which is this
  v: view list of movies
  m: select a movie to view showtimes and buy tickets
  q: quit/exit application
            ");
            break;
          case "v":
            theater.PrintMovies();
            break;
          case "m":
            theater.MovieMenu();
            break;
          case "q":
            open = false;
            break;
          default:
            Console.WriteLine("Invalid option.");
            break;
        }
      }
    }
  }
}
