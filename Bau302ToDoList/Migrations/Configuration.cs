namespace Bau302ToDoList.Migrations
{
    using Bau302ToDoList.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Threading.Tasks;

    internal sealed class Configuration : DbMigrationsConfiguration<Bau302ToDoList.Models.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Bau302ToDoList.Models.AppDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.Add(new Models.Category() { Name = "Deneme", CreateDate = DateTime.Now, CreatedBy = "username", UpdateDate = DateTime.Now, UpdatedBy = "username" });
                var store = new UserStore<ApplicationUser>(context);
                var manager = new ApplicationUserManager(store);
                var user = new ApplicationUser() { Email = "canrockatansky@gmail.com", UserName = "canrockatansky@gmail.com" };
                Task<Microsoft.AspNet.Identity.IdentityResult> task = Task.Run(() => manager.CreateAsync(user, "@Can2546"));
                var result = task.Result;
                context.SaveChanges(); 
            }
        }
    }
}
