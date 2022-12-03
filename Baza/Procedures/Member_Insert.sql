CREATE OR REPLACE PROCEDURE Member_Insert
(
	e_name varchar,
	e_surname varchar,
	e_member_from  timestamp with time zone
)
LANGUAGE SQL
AS $$
	INSERT INTO "Member"(name, surname, member_from) VALUES
	(e_name,
	 e_surname, 
	 e_member_from
	)
$$;
