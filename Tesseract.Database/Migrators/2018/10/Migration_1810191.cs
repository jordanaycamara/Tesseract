using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tesseract.Database.Migrators._2018._10
{
    [Migration(1810191, TransactionBehavior.None, "Creating the Finances schema.")]
    public class Migration_1810191 : Migration
    {
        public override void Up()
        {
            Execute.Sql("EXEC ('CREATE SCHEMA Finances')");
        }

        public override void Down()
        {
            Execute.Sql("EXEC ('DROP SCHEMA Finances')");
        }
    }
}
