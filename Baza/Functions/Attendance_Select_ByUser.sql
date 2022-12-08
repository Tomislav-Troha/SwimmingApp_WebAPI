CREATE OR REPLACE FUNCTION Attendance_Select_ByUser(_userID int)
RETURNS TABLE (ID_attendance int, attDesc varchar, type varchar, ID_member int, name varchar, surname varchar,
			   member_from timestamp with time zone, ID_training int, code varchar, trainingType varchar, userId int)
AS
$$
	SELECT "at"."id", "at"."attDesc", "at"."type", "m"."id", "m"."name", "m"."surname", "m"."member_from",
		   "t"."id", "t"."code", "t"."trainingtype", "u"."id"
	FROM "Attendance" as "at"
	INNER JOIN "Member" as "m" ON "m"."id" = "at"."memberID"
	INNER JOIN "Training" as "t" ON "t"."id" = "at"."trainingID"
	INNER JOIN "User" as "u" ON "u"."id" = "at"."userID"
	WHERE "u"."id" = _userID;
$$
lANGUAGE SQL;
