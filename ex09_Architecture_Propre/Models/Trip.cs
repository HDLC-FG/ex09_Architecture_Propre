namespace ApplicationCore.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }
        public IList<Flight> Flights { get; set; } = new List<Flight>();
        public IList<Hotel> Hotels { get; set; } = new List<Hotel>();
    }
}
