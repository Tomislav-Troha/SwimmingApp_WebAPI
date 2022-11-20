CREATE OR REPLACE PROCEDURE Employee_Delete
(
	e_id int
)
LANGUAGE SQL
AS $$
	DELETE FROM "Employee" 
	WHERE id = e_id
$$;