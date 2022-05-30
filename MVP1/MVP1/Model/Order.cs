namespace MVP1.Model
{
    public class Order
    {
        public long Id { get; set; }

        public string State { get; set; }

        public Table Table { get; set; }
    }
}
