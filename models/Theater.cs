using System;
using System.Collections.Generic;

namespace theater.Models {
  public class Theater {
    public string Name { get; private set; }
    private List<Room> Rooms = new List<Room>();
    private List<Concession> Concessions = new List<Concession>();

    public void AddRoom(Movie movie, int maxSeats) {
      Rooms.Add(new Room(movie, maxSeats));
    }
    public void AddShowTime(int roomNumber, string showtime) {
      if (roomNumber < 0 || roomNumber > Rooms.Count - 1) { return; }
      Rooms[roomNumber].AddShowtime(showtime);
    }
    public void PrintMovies() {
      Console.WriteLine("Movies:\n");
      for (int i = 0; i < Rooms.Count; ++i) {
        Console.WriteLine($"{i + 1}. {Rooms[i].Movie.Title}");
        Rooms[i].PrintShowtimes();
        Console.Write('\n');
      }
    }

    public void MovieMenu() {
      bool open = true;
      while (open) {
        Console.WriteLine("Please enter the index of the movie you wish to select (q to go back).");
        Console.Write("> ");
        string input = Console.ReadLine();
        if (input == "q") {
          Console.WriteLine("Heading back to main menu.");
          return;
        }

        if (Int32.TryParse(input, out int index)) {
          --index;
          if (index < 0 || index >= Rooms.Count) {
            Console.WriteLine("Index out of range");
            return;
          }
          Room room = Rooms[index];

          bool open2 = true;
          while (open2) {
            Console.WriteLine($"Would you like to (b)uy a ticket or (v)iew showtimes for {room.Movie.Title} (q to go back).");
            Console.Write("> ");
            string input2 = Console.ReadLine();
            if (input2 == "b") {
              Console.WriteLine("What showtime?");
              Console.Write("> ");
              string showtime = Console.ReadLine();
              Console.WriteLine("How many tickets?");
              Console.Write("> ");
              if (Int32.TryParse(Console.ReadLine(), out int ticketAmount)) {
                List<Ticket> tickets = room.BuyTicket(showtime, ticketAmount);
                if (tickets == null) {
                  Console.WriteLine("Unable to buy those tickets.");
                  continue;
                }
                Console.WriteLine("Here are your tickets:");
                tickets.ForEach(ticket => ticket.PrintName());
              } else {
                Console.WriteLine("That's not a number.");
              }
            } else if (input2 == "v") {
              room.PrintShowtimes();
            } else if (input2 == "q") {
              Console.WriteLine("Going back.");
              break;
            } else {
              Console.WriteLine("invalid option");
            }
          }
        } else {
          Console.WriteLine("That's not a number.");
          return;
        }
      }
    }

    public void Initialize() {
      Concessions.Add(new Concession("Popcorn", 12.54m));
      Concessions.Add(new Concession("Snacks", 5.00m));
      Concessions.Add(new Concession("Drink", 8.00m));
    }
    public Theater(string name) {
      Name = name;
    }
  }
}