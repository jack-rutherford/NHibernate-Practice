using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations
{
    [Migration(8)]
    public class M8_ModifyProductToUseCategoryTable : Migration
    {
        public override void Down()
        {
            Alter.Table("Product")
            .InSchema(Names.Schema)
            .AddColumn("Category")
            .AsString()
            .NotNullable()
            .WithDefaultValue("General");

            Execute.Sql("update RetailStore.Product set Category = (select Name from RetailStore.Category where Id = Category_Id)");

            Delete.ForeignKey("Product_to_Category").OnTable("Product").InSchema(Names.Schema);

            Delete.Column("Category_Id").FromTable("Product").InSchema(Names.Schema);
        }

        public override void Up()
        {
            Alter.Table("Product")
                .InSchema(Names.Schema)
                .AddColumn("Category_Id").AsInt64().Nullable();

            Execute.Sql("update RetailStore.Product set Category_Id = (select Id from RetailStore.Category where Name = Category)");

            Create.ForeignKey("Product_to_Category")
                .FromTable("Product")
                .InSchema(Names.Schema)
                .ForeignColumn("Category_Id")
                .ToTable("Category")
                .InSchema(Names.Schema)
                .PrimaryColumn("Id")
                .OnUpdate(System.Data.Rule.Cascade)
                .OnDelete(System.Data.Rule.SetNull);

            Delete.Column("Category")
                .FromTable("Product")
                .InSchema(Names.Schema);
                
        }
    }
}
