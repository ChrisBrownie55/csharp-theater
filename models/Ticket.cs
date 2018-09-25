using System;
using theater.Interfaces;

namespace theater.Models {
  public class Ticket : IPurchasable {
    public string Time { get; private set; }
    // public int RoomNumber { get; private set; }
    public Movie Movie { get; private set; }
    public decimal Price { get; set; }
    public string Type { get; set; } = "Ticket";
    public void PrintName() {
      Console.WriteLine($"Purchase of {Movie.Title} for ${Price}");
    }

    public Ticket(string time, Movie movie, decimal price) {
      Time = time;
      Movie = movie;
      Price = price;
    }
  }
}