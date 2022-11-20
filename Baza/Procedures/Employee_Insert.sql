CREATE OR REPLACE PROCEDURE Employee_Insert
(
	e_password varchar,
	e_name varchar,
	e_adress varchar, 
	e_mobile varchar,
	e_email varchar
)
LANGUAGE SQL
AS $$
	INSERT INTO "Employee" (password, name, adress, mobile, email) VALUES
	(e_password,
	 e_name, 
	 e_adress,
	 e_mobile, 
	 e_email
	)
$$;