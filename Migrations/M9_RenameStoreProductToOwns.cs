using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations
{
    [Migration(9)]
    public class M9_RenameStoreProductToOwns : Migration
    {
        public override void Down()
        {
            Rename.Table("Stocks")
                .InSchema(Names.Schema)
                .To("StoreProduct").InSchema(Names.Schema);
        }

        public override void Up()
        {
            Rename.Table("StoreProduct")
                .InSchema(Names.Schema)
                .To("Stocks").InSchema(Names.Schema);
        }
    }
}
