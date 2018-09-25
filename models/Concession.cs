using System;
using theater.Interfaces;

namespace theater.Models {
  public class Concession : IPurchasable {
    public string Name { get; private set; }
    public decimal Price { get; set; }
    public string Type { get; set; } = "Concession";
    public void PrintName() {
      Console.WriteLine($"Purchase of {Name} for ${Price}");
    }
    public Concession(string name, decimal price) {
      Name = name;
      Price = price;
    }
  }
}