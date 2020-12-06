namespace PayslipMaker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeCode = c.String(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        MiddleName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 100),
                        FullName = c.String(),
                        Gender = c.String(),
                        ImageUrl = c.String(),
                        DOB = c.DateTime(nullable: false),
                        DateJoined = c.DateTime(nullable: false),
                        Designation = c.String(),
                        Phone = c.String(),
                        Email = c.String(nullable: false),
                        PancardNo = c.String(nullable: false, maxLength: 50),
                        PaymentMethod = c.Int(nullable: false),
                        UnionMember = c.Int(nullable: false),
                        Address = c.String(nullable: false, maxLength: 150),
                        City = c.String(),
                        Pincode = c.String(nullable: false, maxLength: 6),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymentRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        FullName = c.String(maxLength: 100),
                        PancardNo = c.String(nullable: false, maxLength: 50),
                        PayDate = c.DateTime(nullable: false),
                        PayMonth = c.String(),
                        TaxYearId = c.Int(nullable: false),
                        HourlyRate = c.Decimal(nullable: false, storeType: "money"),
                        HoursWorked = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ContractualHours = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OvertimeHours = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ContractualEarnings = c.Decimal(nullable: false, storeType: "money"),
                        OvertimeEarnings = c.Decimal(nullable: false, storeType: "money"),
                        Tax = c.Decimal(nullable: false, storeType: "money"),
                        UnionFee = c.Decimal(storeType: "money"),
                        TotalEarnings = c.Decimal(nullable: false, storeType: "money"),
                        TotalDeduction = c.Decimal(nullable: false, storeType: "money"),
                        NetPayment = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.TaxYears", t => t.TaxYearId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.TaxYearId);
            
            CreateTable(
                "dbo.TaxYears",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        YearOfTax = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PaymentRecords", "TaxYearId", "dbo.TaxYears");
            DropForeignKey("dbo.PaymentRecords", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PaymentRecords", new[] { "TaxYearId" });
            DropIndex("dbo.PaymentRecords", new[] { "EmployeeId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TaxYears");
            DropTable("dbo.PaymentRecords");
            DropTable("dbo.Employees");
        }
    }
}
