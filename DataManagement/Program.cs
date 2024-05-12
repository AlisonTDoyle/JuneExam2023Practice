using JuneExam2023.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create database model
            MovieData db = new MovieData();

            using (db)
            {
                Movie m1 = new Movie() { MovieID = 1, Title = "The Banshees of Inisherin", Cast = "Colin Farrell, Brendan Gleeson, Kerry Condon, Barry Keoghan", ImageName = "\\Images\\banshees.jpg", Description = "Set on a remote island off the west coast of Ireland, THE BANSHEES OF INISHERIN follows lifelong friends Padraic (Colin Farrell) and Colm (Brendan Gleeson), who find themselves at an impasse when Colm unexpectedly puts an end to their friendship. A stunned Padraic, aided by his sister Siobhan (Kerry Condon) and troubled young islander Dominic (Barry Keoghan), endeavours to repair the relationship, refusing to take no for an answer. But Padraic's repeated efforts only strengthen his former friend's resolve and when Colm delivers a desperate ultimatum, events swiftly escalate, with shocking consequences." };

                Movie m2 = new Movie() { MovieID = 2, Title = "Aftersun", ImageName = "\\Images\\aftersun.jpg", Cast = "Paul Mescal, Frankie Corio, Celia Rowlson-Hall, Sally Messham", Description = "At a fading vacation resort, 11-year-old Sophie treasures rare time together with her loving and idealistic father, Calum (Paul Mescal). As a world of adolescence creeps into view, beyond her eye Calum struggles under the weight of life outside of fatherhood. Twenty years later, Sophie's tender recollections of their last holiday become a powerful and heartrending portrait of their relationship, as she tries to reconcile the father she knew with the man she didn't, in Charlotte Wells' superb and searingly emotional debut film." };

                Movie m3 = new Movie() { MovieID = 3, Title = "The Quiet Girl", Cast = "Carrie Crowley, Andrew Bennett, Catherine Clinch", ImageName = "\\Images\\quietgirl.jpg", Description = "Rural Ireland 1981. A quiet, neglected girl is sent away from her dysfunctional family to live with foster parents for the summer. She blossoms in their care, but in this house where there are meant to be no secrets, she discovers one." };

                // Add to database
                db.Movies.Add(m1);
                db.Movies.Add(m2);
                db.Movies.Add(m3);
                Console.WriteLine("Added booking to db");

                // Save changes
                db.SaveChanges();
                Console.WriteLine("Saved changes");

                // Check Data
                var query = from m in db.Movies
                            orderby m.Title
                            select m;

                foreach (var item in query)
                {
                    Console.WriteLine(item.Title);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
