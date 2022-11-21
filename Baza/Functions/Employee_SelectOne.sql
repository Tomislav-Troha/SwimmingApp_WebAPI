CREATE OR REPLACE FUNCTION Employee_SelectOne(_id int)
RETURNS TABLE (id int, password varchar, name varchar, adress varchar, mobile varchar, email varchar)
AS
$$
	SELECT id, password, name, adress, mobile, email
	FROM   "Employee"
	WHERE (id = _id OR _id IS NULL );
$$
lANGUAGE SQL;


