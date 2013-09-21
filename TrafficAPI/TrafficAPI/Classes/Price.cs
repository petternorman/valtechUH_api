namespace TrafficAPI.Classes
{
    public class Price
    {
        public Price(int redPrice, int price)
        {
            this.RedPrice = redPrice;
            this.VPrice = price;
        }

        private int RedPrice { get; set; }

        private int VPrice { get; set; }

        public int GetPrice(int nrTickets, bool red)
        {
           return red ? this.RedPrice * nrTickets + this.RedPrice : this.VPrice * nrTickets + this.VPrice;
        }
    }
}