create database StudentsResults;
use StudentsResults;


create table Students
(
	StudentsID int primary key auto_increment not null,
    Name nvarchar(50) not null,
    IsMale int not null,
    Date date,
    TeamID int not null
);

create table Teams
(
	TeamID int primary key auto_increment not null,
    Name nvarchar(50) not null
);

create table Exams
(
	ExamID int primary key auto_increment not null,
    Name nvarchar(50) not null,
    IsExam int not null
);

create table Schedules
(
	ScheduleID int primary key auto_increment not null,
    SessionNumber int not null,
    TeamID int not null,
    ExamID int not null, 
    DateExam date
);

create table Results
(
	ResultsID int primary key auto_increment not null,
    StudentsID int not null,
    ScheduleID int not null,
    Mark int not null
);


alter table Students add foreign key (TeamID)
	references Teams (TeamID) on delete cascade;
    
alter table Schedules add foreign key (TeamID)
	references Teams (TeamID) on delete cascade;

alter table Schedules add foreign key (ExamID)
	references Exams (ExamID) on delete cascade;

alter table Results add foreign key (StudentsID)
	references Students (StudentsID) on delete cascade;
  
alter table Results add foreign key (ScheduleID)
	references Schedules (ScheduleID) on delete cascade;

insert into Exams(Name, IsExam)
values  ("OOP", 1 ),
		("NN", 1 ),
		("java", 0 ),
        ("DV", 1 ),
		("WEB", 0 );
        
insert into Teams(Name)
values  ("ITI"),
		("ITP");
         
      
insert into Students(Name, IsMale, Date, TeamID)
values  ("Igor", 1, '1998-05-6', 1),
		("Vania", 1, '1999-11-23', 1),
		("Kirill", 1, '1999-02-23', 2),
		("Aleksey", 1, '2000-01-13', 2),
		("Nastia", 0, '2000-10-1', 1);
        

insert into Schedules(SessionNumber, TeamID, ExamID, DateExam)
values  (5, 1, 1, '2020-01-14'),
		(5, 1, 2, '2020-01-10'),
		(5, 1, 3, '2019-12-25'),
		(5, 2, 3, '2019-12-25'),
		(5, 2, 1, '2020-01-08'),
		(5, 1, 4, '2020-01-06'),
		(3, 1, 5, '2018-12-20'), 
		(3, 2, 5, '2018-12-22'),
		(5, 2, 2, '2019-12-24'),
		(5, 2, 4, '2020-01-09');

insert into Results (StudentsID, ScheduleID, Mark)
values (1, 7, 5), (2, 7, 4), (3, 8, 6), (4, 8, 8);

insert into Results (StudentsID, ScheduleID, Mark)
values (1, 1, 9),
	   (1, 2, 8),
	   (1, 3, 10),
	   (1, 6, 9),
	   (2, 1, 9),
	   (2, 2, 9),
	   (2, 3, 10),
	   (2, 6, 10),
       (5, 1, 8),
	   (5, 2, 9),
	   (5, 3, 10),
	   (5, 6, 9),
       (3, 4, 9),
	   (3, 5, 7),
	   (3, 9, 10),
	   (3, 10, 10),
	   (4, 4, 4),
	   (4, 5, 3),
	   (4, 9, 1),
	   (4, 10, 5);




-- added new changes to the condition of the seventh task

alter table Teams add Profession nvarchar(50) not null;

update Teams set Profession = 'game_dev' where TeamID = 1;
update Teams set Profession = 'design_and_production' where TeamID = 2;


create table Teachers
(
	TeacherID int primary key auto_increment not null,
    Name nvarchar(30) not null    
);

insert into Teachers (Name)
values ('Kurochka'), 
	   ('Avakian'),
       ('Sobolev'),
       ('Kondratuk'),
       ('Zaharenko');

alter table Schedules add TeacherID int not null;


update Schedules set TeacherID = 1 where ScheduleID = 1;
update Schedules set TeacherID = 2 where ScheduleID = 2;
update Schedules set TeacherID = 3 where ScheduleID = 3;
update Schedules set TeacherID = 4 where ScheduleID = 4;
update Schedules set TeacherID = 5 where ScheduleID = 5;
update Schedules set TeacherID = 1 where ScheduleID = 6;
update Schedules set TeacherID = 2 where ScheduleID = 7;
update Schedules set TeacherID = 3 where ScheduleID = 8;
update Schedules set TeacherID = 4 where ScheduleID = 9;
update Schedules set TeacherID = 5 where ScheduleID = 10;


alter table Schedules add foreign key (TeacherID)
	references Teachers (TeacherID) on delete cascade;



