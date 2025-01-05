namespace AuroPay.Models
{
    public class Source
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public override string ToString()
        {
            return Name ?? "Unknown Source"; 
        }
    }
}
