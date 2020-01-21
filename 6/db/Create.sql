-- create database StudentsResults;
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
    IsExam int
);

create table Schedules
(
	ScheduleID int primary key auto_increment not null,
    SessionNumber int not null,
    TeamID int not null,
    ExamID int not null, 
    DateExam date
);


alter table Students add foreign key (TeamID)
	references Teams (TeamID) on delete cascade;
    
alter table Schedules add foreign key (TeamID)
	references Teams (TeamID) on delete cascade;

alter table Schedules add foreign key (ExamID)
	references Exams (ExamID) on delete cascade;
    
    
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
		(3, 2, 5, '2018-12-22');
