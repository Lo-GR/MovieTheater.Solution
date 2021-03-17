namespace MovieTheater.Models
{
  public class CustomerMovie
  {
    public int CustomerMovieId {get; set;}
    public int CustomerId {get; set;}
    public int MovieId {get; set;}
    public virtual Movie Movie {get; set;}
    public virtual Customer Customer {get; set;}
  }
}