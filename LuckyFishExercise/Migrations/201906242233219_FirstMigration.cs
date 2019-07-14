namespace LuckyFishExercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Confs",
                c => new
                    {
                        _confID = c.Int(nullable: false, identity: true),
                        _bet = c.Int(nullable: false),
                        _numScratchcards = c.Int(nullable: false),
                        _numSignOnWheel = c.Int(nullable: false),
                        _numSignOnScratchcards = c.Int(nullable: false),
                        _repeat = c.Boolean(nullable: false),
                        _numSelectedSigns = c.Int(nullable: false),
                        _withJoker = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t._confID);
            
            CreateTable(
                "dbo.Signs",
                c => new
                    {
                        _SignID = c.Int(nullable: false, identity: true),
                        _SignName = c.String(),
                        _SignJoker = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t._SignID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Signs");
            DropTable("dbo.Confs");
        }
    }
}
