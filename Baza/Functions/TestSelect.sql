CREATE FUNCTION Test_Select()
RETURNS TABLE (testName varchar)
AS
$$
	SELECT testname
	FROM   TestTable;
$$
lANGUAGE SQL;
