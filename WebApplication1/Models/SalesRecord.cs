namespace WebApplication1.Models {
    public class SalesRecord {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public double BaseSalary { get; set; }
        public Seller Seller { get; set; }

        public SalesRecord() { }

        public SalesRecord(int id, DateTime date, double amount, double baseSalary, Seller seller) {
            Id = id;
            Date = date;
            Amount = amount;
            BaseSalary = baseSalary;
            Seller = seller;
        }
    }
}
