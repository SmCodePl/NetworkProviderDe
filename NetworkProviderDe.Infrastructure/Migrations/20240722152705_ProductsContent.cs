using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetworkProviderDe.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductsContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[ProductType]([ProductTypeName],[CreatedAt],[UpdatedAt]) VALUES  ('Short Range' , getdate(),Getdate())");
            migrationBuilder.Sql("INSERT INTO [dbo].[ProductType]([ProductTypeName],[CreatedAt],[UpdatedAt]) VALUES  ('Backbone' , getdate(),Getdate())");
            migrationBuilder.Sql("INSERT INTO [dbo].[ProductType]([ProductTypeName],[CreatedAt],[UpdatedAt]) VALUES  ('Regio' , getdate(),Getdate())");
            migrationBuilder.Sql("INSERT INTO [dbo].[ProductType]([ProductTypeName],[CreatedAt],[UpdatedAt]) VALUES  ('Country' , getdate(),Getdate())");
            migrationBuilder.Sql(@"
                            Declare @productTypeId int = (select t.ProductTypeId from ProductType t  where t.ProductTypeName ='Short Range')
                            INSERT INTO [dbo].[Product](
                            [ProductName]
                            ,[ProductDescription]
                            ,[TdcOtc]
                            ,[ProductPrice]
                            ,[Speed]
                            ,[Mrc]
                            ,[IsUnlimited]
                            ,[IsDiscounted]
                            ,[IsPromoted]
                            ,[Active]
                            ,[ProductTypeId]
                            ,[CreatedAt]
                            ,[UpdatedAt]
                            )
                            VALUES
                            (
                            'Internet 100M'
                            ,'Internet 100M upload 100M download 100M'
                            ,2800
                            ,20
                            ,100
                            ,345
                            ,1
                            ,0
                            ,0
                            ,1
                            ,@productTypeId
                            ,getDate()
                            ,getdate())

                            INSERT INTO [dbo].[Product]([ProductName],[ProductDescription],[TdcOtc],[ProductPrice],[Speed],[Mrc],[IsUnlimited],[IsDiscounted],[IsPromoted],[Active],[ProductTypeId],[CreatedAt],[UpdatedAt])
                            VALUES('Internet 200M','Internet 200M download 200M upload 200M',2800,30,200,390,1,0,0,1,@productTypeId,getDate(),getdate())

                            INSERT INTO [dbo].[Product](
                            [ProductName]
                            ,[ProductDescription]
                            ,[TdcOtc]
                            ,[ProductPrice]
                            ,[Speed]
                            ,[Mrc]
                            ,[IsUnlimited]
                            ,[IsDiscounted]
                            ,[IsPromoted]
                            ,[Active]
                            ,[ProductTypeId]
                            ,[CreatedAt]
                            ,[UpdatedAt]
                            )
                            VALUES
                            (
                            'Internet 400M'
                            ,'Internet 400M download 400M upload 200M'
                            ,2800
                            ,40
                            ,400
                            ,450
                            ,1
                            ,0
                            ,0
                            ,1
                            ,@productTypeId
                            ,getDate()
                            ,getdate())


                            INSERT INTO [dbo].[Product](
                            [ProductName]
                            ,[ProductDescription]
                            ,[TdcOtc]
                            ,[ProductPrice]
                            ,[Speed]
                            ,[Mrc]
                            ,[IsUnlimited]
                            ,[IsDiscounted]
                            ,[IsPromoted]
                            ,[Active]
                            ,[ProductTypeId]
                            ,[CreatedAt]
                            ,[UpdatedAt]
                            )
                            VALUES
                            (
                            'Internet 600M'
                            ,'Internet 600M download 600M upload 300M'
                            ,2800
                            ,45
                            ,585
                            ,600
                            ,1
                            ,1
                            ,0
                            ,1
                            ,@productTypeId
                            ,getDate()
                            ,getdate())


                            INSERT INTO [dbo].[Product](
                            [ProductName]
                            ,[ProductDescription]
                            ,[TdcOtc]
                            ,[ProductPrice]
                            ,[Speed]
                            ,[Mrc]
                            ,[IsUnlimited]
                            ,[IsDiscounted]
                            ,[IsPromoted]
                            ,[Active]
                            ,[ProductTypeId]
                            ,[CreatedAt]
                            ,[UpdatedAt]
                            )
                            VALUES
                            (
                            'Internet 1g'
                            ,'Internet 1G download 1g upload 600M'
                            ,2900
                            ,45
                            ,1000
                            ,585
                            ,1
                            ,1
                            ,0
                            ,1
                            ,@productTypeId
                            ,getDate()
                            ,getdate())

                
            ");
            migrationBuilder.Sql(@"

                            Declare @productTypeId int = (select t.ProductTypeId from ProductType t  where t.ProductTypeName ='Backbone')

                            INSERT INTO [dbo].[Product](
                            [ProductName]
                            ,[ProductDescription]
                            ,[TdcOtc]
                            ,[ProductPrice]
                            ,[Speed]
                            ,[Mrc]
                            ,[IsUnlimited]
                            ,[IsDiscounted]
                            ,[IsPromoted]
                            ,[Active]
                            ,[ProductTypeId]
                            ,[CreatedAt]
                            ,[UpdatedAt]
                            )
                            VALUES
                            (
                            'Internet 100M'
                            ,'Internet 100M upload 100M download 100M'
                            ,2800
                            ,20
                            ,100
                            ,428 -- 
                            ,1
                            ,0
                            ,0
                            ,1
                            ,@productTypeId
                            ,getDate()
                            ,getdate())

                            INSERT INTO [dbo].[Product]([ProductName],[ProductDescription],[TdcOtc],[ProductPrice],[Speed],[Mrc],[IsUnlimited],[IsDiscounted],[IsPromoted],[Active],[ProductTypeId],[CreatedAt],[UpdatedAt])
                            VALUES(
                            'Internet 200M',
                            'Internet 200M download 200M upload 200M'
                            ,2800
                            ,30
                            ,200
                            ,474 --
                            ,1
                            ,0
                            ,0
                            ,1
                            ,@productTypeId
                            ,getDate()
                            ,getdate()
                            )

                            INSERT INTO [dbo].[Product](
                            [ProductName]
                            ,[ProductDescription]
                            ,[TdcOtc]
                            ,[ProductPrice]
                            ,[Speed]
                            ,[Mrc]
                            ,[IsUnlimited]
                            ,[IsDiscounted]
                            ,[IsPromoted]
                            ,[Active]
                            ,[ProductTypeId]
                            ,[CreatedAt]
                            ,[UpdatedAt]
                            )
                            VALUES
                            (
                            'Internet 400M'
                            ,'Internet 400M download 400M upload 200M'
                            ,2800
                            ,40
                            ,400
                            ,548 --
                            ,1
                            ,0
                            ,0
                            ,1
                            ,@productTypeId
                            ,getDate()
                            ,getdate())


                            INSERT INTO [dbo].[Product](
                            [ProductName]
                            ,[ProductDescription]
                            ,[TdcOtc]
                            ,[ProductPrice]
                            ,[Speed]
                            ,[Mrc]
                            ,[IsUnlimited]
                            ,[IsDiscounted]
                            ,[IsPromoted]
                            ,[Active]
                            ,[ProductTypeId]
                            ,[CreatedAt]
                            ,[UpdatedAt]
                            )
                            VALUES
                            (
                            'Internet 600M'
                            ,'Internet 600M download 600M upload 300M'
                            ,2800
                            ,45
                            ,585
                            ,600
                            ,1
                            ,1
                            ,0
                            ,1
                            ,@productTypeId
                            ,getDate()
                            ,getdate())


                            INSERT INTO [dbo].[Product](
                            [ProductName]
                            ,[ProductDescription]
                            ,[TdcOtc]
                            ,[ProductPrice]
                            ,[Speed]
                            ,[Mrc]
                            ,[IsUnlimited]
                            ,[IsDiscounted]
                            ,[IsPromoted]
                            ,[Active]
                            ,[ProductTypeId]
                            ,[CreatedAt]
                            ,[UpdatedAt]
                            )
                            VALUES
                            (
                            'Internet 1g'
                            ,'Internet 1G download 1g upload 600M'
                            ,2900
                            ,45
                            ,1000
                            ,660
                            ,1
                            ,1
                            ,0
                            ,1
                            ,@productTypeId
                            ,getDate()
                            ,getdate())
                ");

            migrationBuilder.Sql(@"
                Declare @productTypeId int = (select t.ProductTypeId from ProductType t  where t.ProductTypeName ='Regio')
                INSERT INTO [dbo].[Product](
                [ProductName]
                ,[ProductDescription]
                ,[TdcOtc]
                ,[ProductPrice]
                ,[Speed]
                ,[Mrc]
                ,[IsUnlimited]
                ,[IsDiscounted]
                ,[IsPromoted]
                ,[Active]
                ,[ProductTypeId]
                ,[CreatedAt]
                ,[UpdatedAt]
                )
                VALUES
                (
                'Internet 100M'
                ,'Internet 100M upload 100M download 100M'
                ,2800
                ,20
                ,100
                ,585 -- 
                ,1
                ,0
                ,0
                ,1
                ,@productTypeId
                ,getDate()
                ,getdate())

                INSERT INTO [dbo].[Product]([ProductName],[ProductDescription],[TdcOtc],[ProductPrice],[Speed],[Mrc],[IsUnlimited],[IsDiscounted],[IsPromoted],[Active],[ProductTypeId],[CreatedAt],[UpdatedAt])
                VALUES(
                'Internet 200M',
                'Internet 200M download 200M upload 200M'
                ,2800
                ,30
                ,200
                ,624 --
                ,1
                ,0
                ,0
                ,1
                ,@productTypeId
                ,getDate()
                ,getdate()
                )

                INSERT INTO [dbo].[Product](
                [ProductName]
                ,[ProductDescription]
                ,[TdcOtc]
                ,[ProductPrice]
                ,[Speed]
                ,[Mrc]
                ,[IsUnlimited]
                ,[IsDiscounted]
                ,[IsPromoted]
                ,[Active]
                ,[ProductTypeId]
                ,[CreatedAt]
                ,[UpdatedAt]
                )
                VALUES
                (
                'Internet 400M'
                ,'Internet 400M download 400M upload 200M'
                ,2800
                ,40
                ,400
                ,690 --
                ,1
                ,0
                ,0
                ,1
                ,@productTypeId
                ,getDate()
                ,getdate())


                INSERT INTO [dbo].[Product](
                [ProductName]
                ,[ProductDescription]
                ,[TdcOtc]
                ,[ProductPrice]
                ,[Speed]
                ,[Mrc]
                ,[IsUnlimited]
                ,[IsDiscounted]
                ,[IsPromoted]
                ,[Active]
                ,[ProductTypeId]
                ,[CreatedAt]
                ,[UpdatedAt]
                )
                VALUES
                (
                'Internet 600M'
                ,'Internet 600M download 600M upload 300M'
                ,2800
                ,45
                ,585
                ,735
                ,1
                ,1
                ,0
                ,1
                ,@productTypeId
                ,getDate()
                ,getdate())


                INSERT INTO [dbo].[Product](
                [ProductName]
                ,[ProductDescription]
                ,[TdcOtc]
                ,[ProductPrice]
                ,[Speed]
                ,[Mrc]
                ,[IsUnlimited]
                ,[IsDiscounted]
                ,[IsPromoted]
                ,[Active]
                ,[ProductTypeId]
                ,[CreatedAt]
                ,[UpdatedAt]
                )
                VALUES
                (
                'Internet 1g'
                ,'Internet 1G download 1g upload 600M'
                ,2900
                ,45
                ,1000
                ,803
                ,1
                ,1
                ,0
                ,1
                ,@productTypeId
                ,getDate()
                ,getdate())
                ");

            migrationBuilder.Sql(@"
            
                        Declare @productTypeId int = (select t.ProductTypeId from ProductType t  where t.ProductTypeName ='Country')

                        INSERT INTO [dbo].[Product](
                        [ProductName]
                        ,[ProductDescription]
                        ,[TdcOtc]
                        ,[ProductPrice]
                        ,[Speed]
                        ,[Mrc]
                        ,[IsUnlimited]
                        ,[IsDiscounted]
                        ,[IsPromoted]
                        ,[Active]
                        ,[ProductTypeId]
                        ,[CreatedAt]
                        ,[UpdatedAt]
                        )
                        VALUES
                        (
                        'Internet 100M'
                        ,'Internet 100M upload 100M download 100M'
                        ,2800
                        ,20
                        ,100
                        ,675 -- 
                        ,1
                        ,0
                        ,0
                        ,1
                        ,@productTypeId
                        ,getDate()
                        ,getdate())

                        INSERT INTO [dbo].[Product]([ProductName],[ProductDescription],[TdcOtc],[ProductPrice],[Speed],[Mrc],[IsUnlimited],[IsDiscounted],[IsPromoted],[Active],[ProductTypeId],[CreatedAt],[UpdatedAt])
                        VALUES(
                        'Internet 200M',
                        'Internet 200M download 200M upload 200M'
                        ,2800
                        ,30
                        ,200
                        ,720 --
                        ,1
                        ,0
                        ,0
                        ,1
                        ,@productTypeId
                        ,getDate()
                        ,getdate()
                        )

                        INSERT INTO [dbo].[Product](
                        [ProductName]
                        ,[ProductDescription]
                        ,[TdcOtc]
                        ,[ProductPrice]
                        ,[Speed]
                        ,[Mrc]
                        ,[IsUnlimited]
                        ,[IsDiscounted]
                        ,[IsPromoted]
                        ,[Active]
                        ,[ProductTypeId]
                        ,[CreatedAt]
                        ,[UpdatedAt]
                        )
                        VALUES
                        (
                        'Internet 400M'
                        ,'Internet 400M download 400M upload 200M'
                        ,2800
                        ,40
                        ,400
                        ,780 --
                        ,1
                        ,0
                        ,0
                        ,1
                        ,@productTypeId
                        ,getDate()
                        ,getdate())


                        INSERT INTO [dbo].[Product](
                        [ProductName]
                        ,[ProductDescription]
                        ,[TdcOtc]
                        ,[ProductPrice]
                        ,[Speed]
                        ,[Mrc]
                        ,[IsUnlimited]
                        ,[IsDiscounted]
                        ,[IsPromoted]
                        ,[Active]
                        ,[ProductTypeId]
                        ,[CreatedAt]
                        ,[UpdatedAt]
                        )
                        VALUES
                        (
                        'Internet 600M'
                        ,'Internet 600M download 600M upload 300M'
                        ,2800
                        ,45
                        ,585
                        ,825 --
                        ,1
                        ,1
                        ,0
                        ,1
                        ,@productTypeId
                        ,getDate()
                        ,getdate())


                        INSERT INTO [dbo].[Product](
                        [ProductName]
                        ,[ProductDescription]
                        ,[TdcOtc]
                        ,[ProductPrice]
                        ,[Speed]
                        ,[Mrc]
                        ,[IsUnlimited]
                        ,[IsDiscounted]
                        ,[IsPromoted]
                        ,[Active]
                        ,[ProductTypeId]
                        ,[CreatedAt]
                        ,[UpdatedAt]
                        )
                        VALUES
                        (
                        'Internet 1g'
                        ,'Internet 1G download 1g upload 600M'
                        ,2900
                        ,45
                        ,1000
                        ,885
                        ,1
                        ,1
                        ,0
                        ,1
                        ,@productTypeId
                        ,getDate()
                        ,getdate())
             ");
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from dbo.Product");
        }
    }
}
