namespace CoreMVCCodeFirst_1.Models.Entities
{
    public class AppUser : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }

        //Relational Properties
        public virtual AppUserProfile Profile { get; set; }
        public virtual List<Order> Order { get; set; }
    }
}
