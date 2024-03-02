namespace CoreMVCCodeFirst_1.Models.Entities
{
    public class Product :BaseEntity
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryID { get; set; }

        //Relational Properties
        public virtual Category Category { get; set; }
        public virtual List<OrderDetail> Details { get; set; }
    }
}
