CREATE OR REPLACE PROCEDURE Member_Update
(
	e_id int,
	e_name varchar,
	e_surname varchar,
	e_member_from  timestamp with time zone
)
LANGUAGE SQL
AS $$
	UPDATE "Member" SET name = e_name, surname= e_surname, member_from = e_member_from
	WHERE id = e_id
$$;
