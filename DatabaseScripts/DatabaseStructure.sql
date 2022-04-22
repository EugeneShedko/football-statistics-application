
drop database FootballStatistics

create database FootballStatistics

go

create table FootballStatistics.dbo.Teams
(
	Id int primary key identity(1,1),
	TeamName nvarchar(max),
	CountOfGame nvarchar(max),
	CountOfWins int not null,
	CountOfDraws int not null,
	CountOfLoses int not null,
	CountOfScoredGoals int not null,
	CountOfConsededGoals int not null,
	GoalsDifference int not null,
	Points int not null
)

go

create table FootballStatistics.dbo.Games
(
	Id int identity(1,1),
	DateOfMatch nvarchar(max),
	FirstTeamCountOfGoals nvarchar(max),
	SecondTeamCountOfGoals nvarchar(max),
	Tour nvarchar(max),
	TeamId1 int,
	TeamId2 int
	primary key (Id),
	foreign key(TeamId1) references FootballStatistics.dbo.Teams(Id),
	foreign key(TeamId2) references FootballStatistics.dbo.Teams(Id),
)

go

create table FootballStatistics.dbo.Tickets
(
	Id int identity(1,1),
	Town nvarchar(max),
	Stadium nvarchar(max),
	CountOfPlace int not null,
	GameId int not null
	primary key(Id),
	foreign key(Id) references FootballStatistics.dbo.Games(Id)
)

go

create table FootballStatistics.dbo.Users
(
	LoginId nvarchar(128),
	Password nvarchar(max),
	FamilyName nvarchar(max),
	Name nvarchar(max),
	Age nvarchar(max),
	DateOfBirthd nvarchar(max),
	Country nvarchar(max),
	Town nvarchar(max)
	primary key(LoginId)
)

go


create table FootballStatistics.dbo.BookedTickets
(
	Id int identity(1,1),
	UserId nvarchar(128),
	TicketId int,
	Place nvarchar(max),
	Status nvarchar(max),
	primary key(Id),
	foreign key(UserId) references FootballStatistics.dbo.Users(LoginId),
	foreign key(TicketId) references FootballStatistics.dbo.Tickets(Id)
)

go


create table FootballStatistics.dbo.Comments
(
	Id int identity(1,1),
	CommentDate nvarchar(max),
	CommentText nvarchar(max),
	UserId nvarchar(128),
	primary key(Id),
	foreign key(UserId) references FootballStatistics.dbo.Users(LoginId)
)

go

create table FootballStatistics.dbo.Players
(
	Id int identity(1,1),
	PlayerName nvarchar(max),
	TeamId int,
	primary key(Id),
	foreign key(TeamId) references FootballStatistics.dbo.Teams(Id)
)

go

create table FootballStatistics.dbo.Assists
(
	Id int,
	CountOfAssists nvarchar(max),
	primary key(Id),
	foreign key(Id) references FootballStatistics.dbo.Players(Id)
)

go

create table FootballStatistics.dbo.Goals
(
	Id int,
	CountOfGoals nvarchar(max),
	primary key(Id),
	foreign key(Id) references FootballStatistics.dbo.Players(Id)
)

go 


create table FootballStatistics.dbo.News
(
	Id int identity(1,1),
	Header nvarchar(max),
	NewsText nvarchar(max)
)