using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace MovieApp
{
    class Program
    {
        static void Main()
        {
            ContextDAL ctx = new ContextDAL();
            ctx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=FlixOnTheNet;Integrated Security=True";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Delete Sequence");
            Console.ResetColor();
            var allMovieUsers = ctx.GetMovieUsers(0, 100);
            foreach (MovieUserDAL o in allMovieUsers)
            {
                ctx.DeleteMovieUser(o.MovieUserID);
            }
            var allUsers = ctx.GetUsers(0, 100);
            foreach (UserDAL o in allUsers)
            {
                ctx.DeleteUser(o.UserID);
            }
            var allMovies = ctx.GetMovies(0, 100);
            foreach (MovieDAL o in allMovies)
            {
                ctx.DeleteMovie(o.MovieID);
            }
            var allRoles = ctx.GetRoles(0, 100);
            foreach (RoleDAL o in allRoles)
            {
                ctx.DeleteRole(o.RoleID);
            }
            var allCategories = ctx.GetCategories(0, 100);
            foreach (CategoryDAL o in allCategories)
            {
                ctx.DeleteCategory(o.CategoryID);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ResetDatabase Sequence");
            Console.ResetColor();
            SqlCommand cmd = new SqlCommand("TEST_ResetDatabase");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            using(var x = ctx.ExecuteCommand(cmd)) { }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Create Sequence");
            Console.ResetColor();
            ctx.CreateRole ("Admin");
            ctx.CreateRole ("Owner");
            ctx.CreateRole ("Guest");

            ctx.CreateCategory ("Horror");
            ctx.CreateCategory ("War");
            ctx.CreateCategory ("Documentary");
            ctx.CreateCategory ("Western");
            ctx.CreateCategory ("Action");
            ctx.CreateCategory ("Comedy");
            ctx.CreateCategory ("Science Fiction");
            ctx.CreateCategory ("Animation");
            ctx.CreateCategory ("Crime");
            ctx.CreateCategory ("Romance");

            ctx.CreateUser ("rivermud","rivermud97@gmail.com","happyclass17",3);
            ctx.CreateUser ("olivestate","olivestate32@yahoo.com","angrysea52",3);
            ctx.CreateUser ("rockwellsprawl","rockwellsprawl13@yahoo.com","loudstart22",3);
            ctx.CreateUser ("lyneconsoling","777lyneconsoling@live.com","longsnake66",3);

            ctx.CreateUser ("spentoed","spentoed78@yahoo.com","jazzycircle33",2);
            ctx.CreateUser ("vainbasement","27vainbasement@gmail.com","lazypump15",2);
            ctx.CreateUser ("dashravine","7dashravine6@protonmail.com","hotgoose48",2);
            ctx.CreateUser ("pilotquail","pilotquail86@mail.com","brownbunny75",2);
            ctx.CreateUser ("arrivething","19arrivething@outlook.com","happycopper56",2);

            ctx.CreateUser ("wiredcloud","wiredcloud57@yahoo.com","wireadmin09",1);

            ctx.CreateMovie ("The Godfather",175,"R","The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.","URL PLACEHOLDER",9);
            ctx.CreateMovie ("Forrest Gump",142,"PG-13","Watch history unfold through the perspective of an Alabama man with an IQ of 75.","URL PLACEHOLDER",10);
            ctx.CreateMovie ("Unbreakable",106,"PG-13","A man learns something extraordinary about himself after a devastating accident.","URL PLACEHOLDER",7);
            ctx.CreateMovie ("The Lord of the Rings: The Fellowship of the Ring",178,"PG-13","A Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.","URL PLACEHOLDER",5);
            ctx.CreateMovie ("The Lego Movie 2: The Second Part",107,"PG","It has been five years since everything was awesome and the citizens are facing a huge new threat","URL PLACEHOLDER",8);
            ctx.CreateMovie ("Happy Death Day 2U",100,"PG-13","Tree Gelbman discovers that dying over and over was surprisingly easier than the dangers that lie ahead.","URL PLACEHOLDER",1);
            ctx.CreateMovie ("Captain Marvel",123,"PG-13","Carol Danvers becomes one of the universes most powerful heroes when Earth is caught in the middle of a galactic war between two alien races.","URL PLACEHOLDER",5);
            ctx.CreateMovie ("Us",116,"R","A familys serene beach vacation turns to chaos when their doppelgängers appear and begin to terrorize them.","URL PLACEHOLDER",1);
            ctx.CreateMovie ("Pet Sematary",101,"R","A couple soon discovers a mysterious burial ground hidden deep in the woods near their new home.","URL PLACEHOLDER",1);
            ctx.CreateMovie ("Avengers: Endgame",181,"PG-13","The Avengers assemble once more in order to undo the actions of Thanos and restore order to the universe.","URL PLACEHOLDER",5);
            ctx.CreateMovie ("Pokémon Detective Pikachu",104,"PG","In a world where people collect Pokémon to do battle, a boy comes across an intelligent talking Pikachu who seeks to be a detective.","URL PLACEHOLDER",6);
            ctx.CreateMovie ("John Wick: Chapter 3 - Parabellum",131,"R","Super-assassin John Wick is on the run after killing a member of the international assassins guild","URL PLACEHOLDER",5);
            ctx.CreateMovie ("Aladdin",128,"PG","A kind-hearted street urchin and a power-hungry Grand Vizier vie for a magic lamp that has the power to make their deepest wishes come true.","URL PLACEHOLDER",6);
            ctx.CreateMovie ("Toy Story 4",100,"G","A road trip alongside old and new friends reveals how big the world can be for a toy.","URL PLACEHOLDER",8);
            ctx.CreateMovie ("The Secret Life of Pets 2",86,"PG","Continuing the story of Max and his pet friends, following their secret lives after their owners leave them for work or school each day.","URL PLACEHOLDER",8);
            ctx.CreateMovie ("Rocketman",121,"R","A musical fantasy about the fantastical human story of Elton Johns breakthrough years.","URL PLACEHOLDER",3);
            ctx.CreateMovie ("Brightburn",90,"R","What if a child from another world crash-landed on Earth, but instead of becoming a hero to mankind, he proved to be something far more sinister?","URL PLACEHOLDER",1);
            ctx.CreateMovie ("The Hustle",93,"PG-13","Female scam artists, one low rent and the other high class, who team up to take down the men who have wronged them.","URL PLACEHOLDER",6);
            ctx.CreateMovie ("UglyDolls",87,"PG","An animated adventure in which the free-spirited UglyDolls confront what it means to be different.","URL PLACEHOLDER",8);
            ctx.CreateMovie ("Shazam!",132,"PG-13","A streetwise fourteen-year-old foster kid can turn into the grown-up superhero Shazam.","URL PLACEHOLDER",6);


            DateTime date = DateTime.Today;
            

            ctx.CreateMovieUser (1,5,date);
            ctx.CreateMovieUser (5,9,date);
            ctx.CreateMovieUser (6,6,date);
            ctx.CreateMovieUser (3,7,date);
            ctx.CreateMovieUser (10,8,date);

            Console.WriteLine("Enter UserID");
            string s = Console.ReadLine();
            int i = Convert.ToInt32(s);
            Console.WriteLine();
            Console.WriteLine(ctx.FindUserByID(i));

            Console.WriteLine();
            Console.WriteLine("Just Update User. Seperate values using a ',' ");
            string v = Console.ReadLine();
            try
            {
                string[] values = v.Split(',').ToArray();
                string Username = values[0];
                string Email = values[1];
                string Password = values[2];
                string RoleID = values[3];

                int x = Convert.ToInt32(RoleID);

                ctx.JustUpdateUser(i, Username, Email, Password, x);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("User sucessfully updated");
                Console.WriteLine(ctx.FindUserByID(i));
                Console.ResetColor();
            }
            catch
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please Follow Procedure");
                Console.ResetColor();
            }
            

        }
    }
}
