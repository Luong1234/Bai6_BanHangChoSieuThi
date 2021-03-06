USE [TruongTHPT]
GO
/****** Object:  StoredProcedure [dbo].[ADDGiaoVien]    Script Date: 11/29/2015 09:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[ADDGiaoVien] (@HoTen nvarchar(50), @GT nchar(3),@NgaySinh date, @DiaChi nvarchar(50), @SDT varchar(20), @Luong bigint,@MaMon nchar(10))
AS 
BEGIN
	DECLARE @MaGV nchar(10)
	DECLARE @sott int
	DECLARE contro CURSOR FORWARD_ONLY FOR SELECT MaGV FROM tblGiaoVien
	SET @sott = 0
	
	OPEN contro
	FETCH NEXT FROM contro INTO @MaGV
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		IF((CAST(right(@MaGV, 8) AS int) - @sott) = 1)
		BEGIN
			SET @sott = CAST(right(@MaGV, 8) AS int)
		END
	ELSE BREAK
	FETCH NEXT FROM contro INTO @MaGV
END

DECLARE @cdai int
DECLARE @i int
SET @MaGV = CAST((@sott + 1) as nchar(8))
SET @cdai = LEN(@MaGV)
SET @i = 1
while ( @i <= 8 - @cdai)
BEGIN
	SET @MaGV = '0' + @MaGV
	SET @i = @i + 1
END
SET @MaGV = 'GV' + @MaGV

INSERT INTO tblGiaoVien values ( @MaGV,@HoTen,@GT,@NgaySinh,@DiaChi,@SDT,@Luong,@MaMon)
SELECT @MaGV
CLOSE contro
DEALLOCATE contro
END
