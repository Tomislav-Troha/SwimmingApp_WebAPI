CREATE OR REPLACE PROCEDURE Training_Update
(
	e_id int,
	e_code varchar,
	e_name varchar
)
LANGUAGE SQL
AS $$
	UPDATE "Training" SET code = e_code, name = e_name WHERE id = e_id
$$;
