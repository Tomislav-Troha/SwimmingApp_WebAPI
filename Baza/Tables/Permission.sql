CREATE TABLE "Permission" (
  "id" INT GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY,
  "perName" varchar,
  "perDesc" varchar,
  "UserRoleID" int
);

ALTER TABLE "Permission" ADD FOREIGN KEY ("UserRoleID") REFERENCES "UserRole" ("id");