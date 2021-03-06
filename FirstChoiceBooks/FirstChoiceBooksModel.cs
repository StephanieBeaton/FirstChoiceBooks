namespace FirstChoiceBooks
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class FirstChoiceBooksModel : DbContext
    {
        // Your context has been configured to use a 'FirstChoiceBooksModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FirstChoiceBooks.FirstChoiceBooksModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'FirstChoiceBooksModel' 
        // connection string in the application configuration file.
        public FirstChoiceBooksModel()
            : base("name=FirstChoiceBooksModel2")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<LineItem> LineItems { get; set; }

        public virtual DbSet<Payment> Payments { get; set; }

        public virtual DbSet<PaymentOrderAmount> PaymentOrderAmounts { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}