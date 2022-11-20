CREATE OR REPLACE FUNCTION Employee_Select()
RETURNS TABLE (id int, password varchar, name varchar, adress varchar, mobile varchar, email varchar)
AS
$$
	SELECT id, password, name, adress, mobile, email
	FROM   "Employee";
$$
lANGUAGE SQL;


