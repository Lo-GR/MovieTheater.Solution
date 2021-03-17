using System.Collections.Generic;

namespace MovieTheater.Models
{
  public class Customer
  {
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string TicketNumber { get; set; }
    public virtual ICollection<CustomerMovie> JoinEntities { get; }
    public Customer()
    {
      JoinEntities = new HashSet<CustomerMovie>();
    }
    
    
  }    
}