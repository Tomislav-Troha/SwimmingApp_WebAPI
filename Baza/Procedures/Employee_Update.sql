CREATE OR REPLACE PROCEDURE Employee_Update
(
	e_id int,
	e_password varchar,
	e_name varchar,
	e_adress varchar, 
	e_mobile varchar,
	e_email varchar
)
LANGUAGE SQL
AS $$
	UPDATE "Employee" SET password = e_password, name = e_name, adress = e_adress, mobile = e_mobile, email = e_email
	WHERE id = e_id
$$;