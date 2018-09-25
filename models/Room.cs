using System;
using System.Collections.Generic;

namespace theater.Models {
  public class Room {
    public Movie Movie { get; private set; }
    private Dictionary<string, int> Showtimes = new Dictionary<string, int>();
    public int MaxSeats { get; private set; }

    public bool AddShowtime(string showtime) {
      return Showtimes.TryAdd(showtime, MaxSeats);
    }
    public void PrintShowtimes() {
      if (Showtimes.Keys.Count == 0) {
        Console.WriteLine("No showtimes");
        return;
      }

      foreach (KeyValuePair<string, int> showtime in Showtimes) {
        Console.WriteLine($" {showtime.Key} - Available seats: {showtime.Value}");
      }
    }
    public List<Ticket> BuyTicket(string showtime, int ticketAmount = 1) {
      if (Showtimes.ContainsKey(showtime) && Showtimes[showtime] >= ticketAmount) {
        List<Ticket> purchasedTickets = new List<Ticket>();
        for (int i = 0; i < ticketAmount; i++) {
          purchasedTickets.Add(new Ticket(showtime, Movie, 15));
        }
        Showtimes[showtime] -= ticketAmount;
        return purchasedTickets;
      }
      return null;
    }


    public Room(Movie movie, int maxSeats) {
      Movie = movie;
      MaxSeats = maxSeats;
    }
  }
}