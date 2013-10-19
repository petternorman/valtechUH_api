namespace TrafficAPI.Api.Repositories
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
            var priceCat = cat == "H" ? this.VPrice : this.RedPrice;

            return priceCat * nrTickets;
        }
    }
}