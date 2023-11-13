using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations
{
    [Migration(2)]
    public class M2_Store : Migration
    {
        public override void Down()
        {
            Delete.Table("Store").InSchema(Names.Schema);
        }

        public override void Up()
        {
            Create.Table("Store")
                .InSchema(Names.Schema)
                .WithColumn("Id").AsInt64().Identity().PrimaryKey()
                .WithColumn("Name").AsString(255).Unique().NotNullable();
        }

    }
}
