create table TestTable (
TestTabelID serial,
TestName varchar(200)
);

insert into TestTable(TestName) values ('TestIme');

select * from TestTable