CREATE OR REPLACE FUNCTION User_Select_LoginData(_email varchar)
RETURNS TABLE (email varchar, username varchar, password bytea, salt bytea)
AS
$$
	SELECT email, username, password, salt
	FROM "User"
	WHERE email = _email
$$
lANGUAGE SQL;


