using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations
{
    [Migration(5)]
    public class M5_StoreProduct : Migration
    {
        public override void Down()
        {
            Delete.ForeignKey("StoreProduct_To_Store")
                .OnTable("StoreProduct")
                .InSchema(Names.Schema);
            Delete.ForeignKey("StoreProduct_To_Product")
                .OnTable("StoreProduct")
                .InSchema(Names.Schema);

            Delete.Table("StoreProduct").InSchema(Names.Schema);
        }

        public override void Up()
        {
            Create.Table("StoreProduct")
                .InSchema(Names.Schema)
                .WithColumn("Store_Id").AsInt64().NotNullable().PrimaryKey()
                .WithColumn("product_Id").AsInt64().NotNullable().PrimaryKey();

            Create.ForeignKey("StoreProduct_To_Store")
                .FromTable("StoreProduct")
                .InSchema(Names.Schema)
                .ForeignColumn("Store_Id")
                .ToTable("Store")
                .InSchema(Names.Schema)
                .PrimaryColumn("Id")
                .OnDeleteOrUpdate(System.Data.Rule.Cascade);
            Create.ForeignKey("StoreProduct_To_Product")
                .FromTable("StoreProduct")
                .InSchema(Names.Schema)
                .ForeignColumn("Product_Id")
                .ToTable("Product")
                .InSchema(Names.Schema)
                .PrimaryColumn("Id")
                .OnDeleteOrUpdate(System.Data.Rule.Cascade);
        }
    }
}
