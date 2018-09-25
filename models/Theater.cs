using System.Collections.Generic;

namespace theater.Models {
  public class Theater {
    public string Name { get; private set; }
    private List<Movie> Movies = new List<Movie>();
    private List<Concession> Concessions = new List<Concession>();
    public Theater(string name) {
      Name = name;
    }
  }
}