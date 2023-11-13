using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations
{
    [Migration(7)]
    public class M7_Category : Migration
    {
        public override void Down()
        {
            Delete.Table("Category").InSchema(Names.Schema);
        }

        public override void Up()
        {
            Create.Table("Category")
                .InSchema(Names.Schema)
                .WithColumn("Id").AsInt64().Identity().PrimaryKey()
                .WithColumn("Name").AsString().Unique().NotNullable()
                .WithColumn("IsDefault").AsBoolean().NotNullable().WithDefaultValue(0);

            var general = new { Name = "General", IsDefault = 1 };
            var sportingGoods = new { Name = "Sporting Goods" };

            Insert.IntoTable("Category")
                .InSchema(Names.Schema)
                .Row(general)
                .Row(sportingGoods);
        }
    }
}
