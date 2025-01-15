namespace ApplicationCore.Dtos.Hotel
{
    public class SearchDto
    {
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
