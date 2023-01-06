CREATE OR REPLACE PROCEDURE TrainingDate_Insert
(
	e_dates timestamp with time zone,
	e_time timestamp with time zone,
	e_memberID int,
	e_trainingID int,
	e_userID int
)
LANGUAGE SQL
AS $$
	INSERT INTO "TrainingDate"(dates, time, "memberID", "trainingID", "userID") VALUES
	(e_dates,
	 e_time, 
	 e_memberID,
	 e_trainingID,
	 e_userID
	)
$$;
