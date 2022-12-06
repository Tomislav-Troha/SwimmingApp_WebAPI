CREATE OR REPLACE FUNCTION Training_Select(_id int)
RETURNS TABLE (id int, code varchar, name varchar)
AS
$$
	SELECT id, code, name
	FROM   "Training"
	WHERE (id = _id OR _id IS NULL );
$$
lANGUAGE SQL;


