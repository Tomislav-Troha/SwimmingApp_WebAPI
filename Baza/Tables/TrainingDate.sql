CREATE TABLE "TrainingDate" (
  "id" INT GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY,
  "dates" timestamp with time zone,
  "timeFrom" timestamp with time zone,
  "timeTo" timestamp with time zone,
  "trainingID" int,
  "userID" int
);

ALTER TABLE "TrainingDate" ADD FOREIGN KEY ("memberID") REFERENCES "Member" ("id");

ALTER TABLE "TrainingDate" ADD FOREIGN KEY ("trainingID") REFERENCES "Training" ("id");

ALTER TABLE "TrainingDate" ADD FOREIGN KEY ("userID") REFERENCES "User" ("id");
