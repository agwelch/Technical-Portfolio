using Microsoft.EntityFrameworkCore;


namespace ProgrammingFinal2024.Models;


public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
{
    using (var context = new ApplicationDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>() ))
{
    context.Database.Migrate();
if (context.Users.Any())
{
    return;
}
context.Users.AddRange(
    new User { UserID = 1, Name = "Me"},
        new User { UserID = 2, Name = "Jaydon"}
);
context.Projects.AddRange(
     new Project { ProjectID = 123, Title = "Pet Shop", Description = "Pet Shop is an online application staged in a pet store, customers enter and are able to check items out.", Creator = "John B" },
                    new Project { ProjectID = 124, Title = "Office Space", Description = "Office Space is an application staged in an office, you're an employee that has to make changes to documents and mark off tasks as complete.", Creator = "Hanna L" }
                );


 context.Messages.AddRange(
                    new Message { MessageID = 1, SenderID = 1, ReceiverID = 2, Content = "Hello, how are you?" },
                    new Message { MessageID = 2, SenderID = 2, ReceiverID = 1, Content = "I'm good, thanks!" }
                );
context.SaveChanges();
}
}


}
