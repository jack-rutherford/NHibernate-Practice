using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations
{
    [Migration(6)]
    public class M6_AddCategoryToProduct : Migration
    {
        public override void Down()
        {
            Delete.Column("Category").FromTable("Product").InSchema(Names.Schema);

        }

        public override void Up()
        {
            Alter.Table("Product")
                .InSchema(Names.Schema)
                .AddColumn("Category")
                .AsString()
                .NotNullable()
                .WithDefaultValue("General");
        }
    }
}