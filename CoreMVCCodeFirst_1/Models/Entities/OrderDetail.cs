namespace CoreMVCCodeFirst_1.Models.Entities
{
    public class OrderDetail :BaseEntity
    {
        public int ProductID { get; set; }
        public int OrderID { get; set; }

        // Relatioanl Properties
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
