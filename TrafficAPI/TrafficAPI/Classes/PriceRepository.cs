namespace TrafficAPI.Classes
{
    public class PriceRepository
    {
        public PriceRepository(int redPrice, int price)
        {
            this.RedPrice = redPrice;
            this.VPrice = price;
        }

        private int RedPrice { get; set; }

        private int VPrice { get; set; }

        public int GetPrice(int nrTickets, string cat)
        {
            var priceCat = cat == "SLH" ? this.VPrice : this.RedPrice;

            return priceCat * nrTickets;
        }
    }
}