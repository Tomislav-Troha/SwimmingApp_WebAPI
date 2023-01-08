CREATE OR REPLACE PROCEDURE Training_Insert
(
	e_code varchar,
	e_trainingType varchar
)
LANGUAGE SQL
AS $$
	INSERT INTO "Training"(code, trainingType) VALUES
	(e_code,
	 e_trainingType
	)
$$;