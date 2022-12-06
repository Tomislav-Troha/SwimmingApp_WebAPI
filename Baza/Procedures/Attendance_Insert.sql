CREATE OR REPLACE PROCEDURE Attendance_Insert
(
	e_attDesc varchar,
	e_type varchar,
	e_memberId int, 
	e_trainingId int,
	e_userId int
)
LANGUAGE SQL
AS $$
	INSERT INTO "Attendance" ("attDesc", "type", "memberID", "trainingID", "userID") 
	VALUES (e_attDesc, e_type, e_memberId, e_trainingId, e_userId)
$$;
