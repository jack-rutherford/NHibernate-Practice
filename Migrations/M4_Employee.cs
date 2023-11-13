using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations
{
    [Migration(4)]
    public class M4_Employee : Migration
    {
        public override void Down()
        {
            Delete.ForeignKey("EmployeeToStore")
                .OnTable("Employee")
                .InSchema(Names.Schema);

            Delete.Table("Employee")
                .InSchema(Names.Schema);
        }

        public override void Up()
        {
            Create.Table("Employee")
                .InSchema(Names.Schema)
                .WithColumn("Id").AsInt64().Identity().PrimaryKey()
                .WithColumn("FirstName").AsString(255).NotNullable()
                .WithColumn("LastName").AsString(255).NotNullable()
                .WithColumn("Store_Id").AsInt64().Nullable();
            Create.ForeignKey("EmployeeToStore")
              .FromTable("Employee")
              .InSchema(Names.Schema)
              .ForeignColumn("Store_Id")
              .ToTable("Store")
              .InSchema(Names.Schema)
              .PrimaryColumn("Id")
              .OnDelete(System.Data.Rule.SetNull)
              .OnUpdate(System.Data.Rule.Cascade);

        }
    }
}
