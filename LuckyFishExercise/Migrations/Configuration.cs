namespace LuckyFishExercise.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using LuckyFishExercise.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<LuckyFishExercise.Models.gameDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(LuckyFishExercise.Models.gameDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context._Signs.AddOrUpdate(sign => sign._SignName,
                new Sign { _SignName = "A", _SignJoker = false },
                new Sign { _SignName = "B", _SignJoker = false },
                new Sign { _SignName = "C", _SignJoker = false },
                new Sign { _SignName = "D", _SignJoker = false },
                new Sign { _SignName = "E", _SignJoker = false },
                new Sign { _SignName = "F", _SignJoker = false },
                new Sign { _SignName = "G", _SignJoker = false },
                new Sign { _SignName = "H", _SignJoker = false },
                new Sign { _SignName = "I", _SignJoker = false },
                new Sign { _SignName = "J", _SignJoker = false },
                new Sign { _SignName = "K", _SignJoker = false },
                new Sign { _SignName = "L", _SignJoker = false },
                new Sign { _SignName = "M", _SignJoker = false },
                new Sign { _SignName = "N", _SignJoker = false },
                new Sign { _SignName = "O", _SignJoker = false },
                new Sign { _SignName = "P", _SignJoker = false },
                new Sign { _SignName = "Q", _SignJoker = false },
                new Sign { _SignName = "R", _SignJoker = false },
                new Sign { _SignName = "S", _SignJoker = false },
                new Sign { _SignName = "T", _SignJoker = false },
                new Sign { _SignName = "U", _SignJoker = false },
                new Sign { _SignName = "V", _SignJoker = false },
                new Sign { _SignName = "W", _SignJoker = false },
                new Sign { _SignName = "X", _SignJoker = false },
                new Sign { _SignName = "Y", _SignJoker = false },
                new Sign { _SignName = "Z", _SignJoker = false }
                );
            context._Configuration.AddOrUpdate(conf => conf._confID,
                new Conf {_bet=3,_numScratchcards=1,_numSelectedSigns=3,_numSignOnScratchcards=4,_numSignOnWheel=12,
                    _repeat =true,_withJoker=false
                });

        }
    }
}
