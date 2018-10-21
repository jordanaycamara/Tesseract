using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tesseract.Database.Migrators._2018._10
{
    [Migration(1810200, "Creating tables.")]
    public class Migration_1810200 : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("Tesseract.Database.Migrators._2018._10.DatabaseSetup.sql");
        }

        public override void Down()
        {
            Execute.EmbeddedScript("Tesseract.Database.Migrators._2018._10.DatabaseTeardown.sql");
        }
    }
}
