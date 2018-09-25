namespace theater.Models {
  public class Ticket {
    public string Time { get; private set; }
    // public int RoomNumber { get; private set; }
    public Movie Movie { get; private set; }
    public decimal Price { get; private set; }
    public Ticket(string time, Movie movie, decimal price) {
      Time = time;
      Movie = movie;
      Price = price;
    }
  }
}