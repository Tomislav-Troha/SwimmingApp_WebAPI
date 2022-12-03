CREATE OR REPLACE PROCEDURE Member_Delete
(
	e_id int
)
LANGUAGE SQL
AS $$
	DELETE FROM "Member" 
	WHERE id = e_id
$$;
