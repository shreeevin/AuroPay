namespace AuroPay.Models
{
    public class Filter
    {
        public string? Code { get; set; }
        public string? Name { get; set; }

        public override string ToString()
        {
            return Name ?? "Unknown Currency"; 
        }
    }
}
