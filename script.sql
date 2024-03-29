USE [Nimap_task]
GO
/****** Object:  Table [dbo].[Category_Table]    Script Date: 09-04-2023 06:39:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category_Table](
	[category_id] [int] IDENTITY(1,1) NOT NULL,
	[category_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Category_Table] PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Table]    Script Date: 09-04-2023 06:39:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Table](
	[product_id] [int] IDENTITY(1,1) NOT NULL,
	[product_name] [nvarchar](50) NULL,
	[category_id] [int] NULL,
 CONSTRAINT [PK_Product_Table] PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_category]    Script Date: 09-04-2023 06:39:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_category]
@Id int ,
@Name nvarchar(50),

@Flag nvarchar(1)
As
  Begin
     If(@Flag='I')
	   Begin 
	 insert into Category_Table values (@Name) 
	  end
   if(@Flag='U')
   Begin 
     Update Category_Table Set
     category_name=@Name
         Where category_id=@Id
   End
  
 End
GO
/****** Object:  StoredProcedure [dbo].[sp_category_report]    Script Date: 09-04-2023 06:39:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[sp_category_report]
 as
 begin 
 select * from Category_Table
 end
GO
/****** Object:  StoredProcedure [dbo].[sp_product]    Script Date: 09-04-2023 06:39:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_product]
@Id int ,
@Name nvarchar(50),
@CID int ,
@Flag nvarchar(1)
As
  Begin
     If(@Flag='I')
	   Begin 
	 insert into Product_Table(product_name,category_id) values (@Name,@CID) 
	  end
   if(@Flag='U')
   Begin 
     Update Product_Table Set
     product_name=@Name,category_id=@CID
         Where product_id=@Id
   End
  
 End
GO
/****** Object:  StoredProcedure [dbo].[sp_product_delete]    Script Date: 09-04-2023 06:39:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE Proc [dbo].[sp_product_delete]
@Id int 
As
begin
Delete From Product_Table 
Where product_id=@Id
End
GO
/****** Object:  StoredProcedure [dbo].[sp_product_edit]    Script Date: 09-04-2023 06:39:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_product_edit]
@id int
as
begin
SELECT 
	product_id,
      product_name,
	  category_id
     
  FROM Product_Table where product_id=@id
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_product_s]    Script Date: 09-04-2023 06:39:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE procedure [dbo].[sp_product_s]
 as
 begin 
  select product_id,product_name,category_id from [dbo].[Product_Table]
 end
GO
/****** Object:  StoredProcedure [dbo].[sp_repot]    Script Date: 09-04-2023 06:39:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_repot]
as
begin 
select p.product_id,p.product_name,p.category_id,c.category_name
from[dbo].[Product_Table] P
inner join [dbo].[Category_Table] C on 
p.category_id=c.category_id
end
GO
