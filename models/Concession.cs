namespace theater.Models {
  public class Concession {
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public Concession(string name, decimal price) {
      Name = name;
      Price = price;
    }
  }
}