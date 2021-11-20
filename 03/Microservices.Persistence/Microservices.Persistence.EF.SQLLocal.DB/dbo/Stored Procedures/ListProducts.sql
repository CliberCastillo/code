CREATE PROCEDURE ListProducts 	
AS
BEGIN
	SET NOCOUNT ON;
	select * from Products;
END