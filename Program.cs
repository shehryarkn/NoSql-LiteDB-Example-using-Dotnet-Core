using System;
using System.Linq;
using LiteDB;

class Program
{
    static void Main(string[] args)
    {
        // Open database (or create if not exits)
        using(var db = new LiteDatabase(@"MyData.db"))
        {
            // Get user collection
            var users = db.GetCollection<User>("users");

            // Create your new user instance
            var user = new User
            { 
                Name = "Shehryar Khan", 
                Email = "shehryarkn@gmail.com"
            };

            // Insert new user document (Id will be auto-incremented)
            users.Insert(user);

            var result = users.Find(x => x.Email == "shehryarkn@gmail.com").FirstOrDefault();
            Console.WriteLine(result.Name);

            // Update a document inside a collection
            user.Name = "S Khan";
            users.Update(user);

            // Index document using a document property
            users.EnsureIndex(x => x.Name);
        }
    }
}
