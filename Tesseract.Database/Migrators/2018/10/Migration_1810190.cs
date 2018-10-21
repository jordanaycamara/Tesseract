using System;
using System.Collections.Generic;
using System.Text;
using FluentMigrator;


namespace Tesseract.Database.Migrators._2018._10
{
    [Migration(1810190, TransactionBehavior.None, "Creating the Company schema.")]
    public class Migration_1810190 : Migration
    {
        public override void Up()
        {
            Execute.Sql("EXEC ('CREATE SCHEMA Company')");
        }

        public override void Down()
        {
            Execute.Sql("EXEC ('DROP SCHEMA Company')");
        }
    }
}
