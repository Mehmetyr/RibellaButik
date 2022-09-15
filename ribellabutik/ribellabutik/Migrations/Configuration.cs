namespace ribellabutik.Migrations
{
    using ribellabutik.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ribellabutik.Models.Db_model>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ribellabutik.Models.Db_model context)
        {
            context.ManagerTypes.AddOrUpdate(s => s.ID, new ManegerType() { ID = 1, Name = "Admin" });
            context.ManagerTypes.AddOrUpdate(s => s.ID, new ManegerType() { ID = 2, Name = "Moderatör" });
            context.Managers.AddOrUpdate(s => s.ID, new Manager() { ID = 1, Name = "Mehmet", Surname = "Yörü", Mail = "mhmtyru@gmail.com", Password = "12345", ManagerType_ID = 1, ProfileImage = "none.png", Status = true,CreationDate=Convert.ToDateTime("26/07/2022") });
        }
    }
}
