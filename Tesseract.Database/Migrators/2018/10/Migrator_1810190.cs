using System;
using System.Collections.Generic;
using System.Text;
using FluentMigrator;


namespace Tesseract.Database.Migrators._2018._10
{
    public class Migrator_1810190 : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("DatabaseSetup.sql");
        }

        public override void Down()
        {
            Execute.Sql("DROP DATABASE tesseract; DROP LOGIN TesseractUser");
        }
    }
}
