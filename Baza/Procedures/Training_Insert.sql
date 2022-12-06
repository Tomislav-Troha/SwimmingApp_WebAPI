CREATE OR REPLACE PROCEDURE Training_Insert
(
	e_code varchar,
	e_name varchar
)
LANGUAGE SQL
AS $$
	INSERT INTO "Training"(code, name) VALUES
	(e_code,
	 e_name
	)
$$;
