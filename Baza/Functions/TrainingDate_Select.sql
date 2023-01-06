CREATE OR REPLACE FUNCTION TrainingDate_Select(_userID int)
RETURNS TABLE 
(
	id int,
	dates timestamp with time zone,
	"time" timestamp with time zone,
	ID_member int,
	name varchar,
	surname varchar,
	member_from timestamp with time zone,
	ID_training int,
	code varchar,
	trainingType varchar,
	userId int
)
AS
$$
	SELECT td."id", "dates", "time", "m"."id", "m"."name", "m"."surname", "m"."member_from",
		   "t"."id", "t"."code", "t"."trainingtype", "u"."id"
	FROM   "TrainingDate" as "td"
	INNER JOIN "Member" as "m" ON "m"."id" = "td"."memberID"
	INNER JOIN "Training" as "t" ON "t"."id" = "td"."trainingID"
	INNER JOIN "User" as "u" ON "u"."id" = "td"."userID"
	WHERE u."id" = _userID;
$$
lANGUAGE SQL;

