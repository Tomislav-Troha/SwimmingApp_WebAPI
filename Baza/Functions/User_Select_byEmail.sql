CREATE OR REPLACE FUNCTION User_Select_byEmail(_email varchar)
RETURNS TABLE (username varchar)
AS
$$
	SELECT username
	FROM   "User"
	WHERE (email = _email);
$$
lANGUAGE SQL;
