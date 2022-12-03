CREATE OR REPLACE FUNCTION Member_Select(_id int)
RETURNS TABLE (id int, name varchar, surname varchar, member_from timestamp with time zone)
AS
$$
	SELECT id, name, surname, member_from
	FROM   "Member"
	WHERE (id = _id OR _id IS NULL );
$$
lANGUAGE SQL;


