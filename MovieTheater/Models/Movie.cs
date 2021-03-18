using System.Collections.Generic;
using System;

namespace MovieTheater.Models
{
  public class Movie
  {
    public int MovieId {get; set;}
    public string Name {get; set;}
    public int MinAge {get; set;}
    public string TimeSlot {get; set;}
    public virtual ICollection<CustomerMovie> JoinEntities {get;}
    
    public Movie()
    {
      JoinEntities = new HashSet<CustomerMovie>();
    }
  }
}