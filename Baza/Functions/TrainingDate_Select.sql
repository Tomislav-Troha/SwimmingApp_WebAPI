CREATE OR REPLACE FUNCTION TrainingDate_Select(_userID int)
RETURNS TABLE 
(
	ID_TrainingDate int,
	dates timestamp with time zone,
	"timeFrom" timestamp with time zone,
	"timeTo" timestamp with time zone,
	ID_training int,
	code varchar,
	trainingType varchar,
	userId int,
	name varchar,
	surname varchar,
	email varchar,
	username varchar,
	addres varchar,
	RoleId int,
	roleName varchar,
	roleDesc varchar
)
AS
$$
	SELECT td."id", "dates", td."timefrom", td."timeto",
		   "t"."id", "t"."code", "t"."trainingtype", "u"."id", u."name", u."surname", u."email", u."username",
		   u."addres", ur."id", ur."roleName", ur."roleDesc"
	FROM   "TrainingDate" as "td"
	INNER JOIN "Training" as "t" ON "t"."id" = "td"."trainingID"
	INNER JOIN "User" as "u" ON "u"."id" = "td"."userID"
	INNER JOIN "UserRole" as "ur" ON "ur"."id" = u."userRoleID"
	WHERE u."id" = _userID;
$$
lANGUAGE SQL;