using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations
{
    [Migration(3)]
    public class M3_Product : Migration
    {
        public override void Down()
        {
            Delete.Table("Product").InSchema(Names.Schema);
        }

        public override void Up()
        {
            Create.Table("Product")
            .InSchema(Names.Schema)
            .WithColumn("Id").AsInt64().Identity().PrimaryKey()
            .WithColumn("Name").AsString(255).NotNullable().Unique()
            .WithColumn("Price").AsDecimal(7, 2);
        }

    }
}
