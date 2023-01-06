CREATE OR REPLACE PROCEDURE TrainingDate_Update
(
	e_id int,
	e_dates timestamp with time zone,
	e_time timestamp with time zone,
	e_memberID int,
	e_trainingID int
)
LANGUAGE SQL
AS $$
	UPDATE "TrainingDate" SET dates = e_dates, time = e_time, "memberID" = e_memberID,
						      "trainingID" = e_trainingID
	WHERE id = e_id
$$;
