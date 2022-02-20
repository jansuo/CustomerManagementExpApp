namespace CustomersBLL.Api.Models
{
    public record Customer
    {
        public string id { get; set; }
        public string company { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public object mobile { get; set; }
    }
}
