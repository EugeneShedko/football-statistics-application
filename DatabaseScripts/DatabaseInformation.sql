


insert into FootballStatistics.dbo.Teams(TeamName, CountOfGame, CountOfWins, CountOfDraws, CountOfLoses, CountOfScoredGoals, CountOfConsededGoals, GoalsDifference, Points)
values('????', 4 , 4 , 0 , 0 , 10 , 0 , 10 , 12 ),
	  ('?????', 4 , 2 , 2 , 0 , 5 , 2 , 3 , 8),
	  ('?????? ??', 4 , 2 , 2 , 0 , 4 , 2 , 2 , 8),
	  ('?????????-???', 3 , 2 , 1 , 0 , 7 , 3 , 4 , 7),
	  ('?????', 4 , 2 , 1 , 1 , 6 , 4 , 2 , 7),
	  ('??????', 3 , 2 , 0 , 1 , 5 , 5 , 0 , 6),
	  ('??????', 4 , 1 , 2 , 1 , 6 , 3 , 3 , 5),
	  ('?????', 4 , 1 , 2 , 1 , 5 , 6 , -1 , 5),
	  ('??????', 4 , 0 , 3 , 1 , 5 , 6 , -1 , 3),
	  ('?????? ?', 3 , 1 , 0 , 2 , 3 , 5 , -2 , 3),
	  ('???????-?????', 4 , 1 , 0 , 3 , 2 , 6 , -4 , 3),
	  ('???????', 3 , 0 , 2 , 1 , 2 , 4 , -2 , 2),
	  ('??????? ??', 4 , 0 , 2 , 2 , 2 , 4 , -2, 2),
	  ('?????? ??', 3 , 0 , 2 , 1 , 4 , 5 , -1, 2),
	  ('???????', 4 , 0 , 2 , 2 , 2 , 6 , -4 , 2),
	  ('????? ???????', 3 , 0 , 1 , 2 , 0 , 7 , -7 , 1)

go

insert into FootballStatistics.dbo.Games(DateOfMatch, FirstTeamCountOfGoals, SecondTeamCountOfGoals, Tour, TeamId1, TeamId2)
values('18.03.2022', 0 , 1 , '??? 1' ,5 , 3),
	  ('19.03.2022', 3 , 1 , '??? 1' , 4 , 12),
	  ('19.03.2022', 2 , 0 , '??? 1' , 2 , 11),
	  ('19.03.2022', 1 , 1 , '??? 1' , 14 , 7),
	  ('19.03.2022', 1 , 2 , '??? 1' , 9 , 8),
	  ('20.03.2022', 1 , 2 , '??? 1' , 13 , 6),
	  ('20.03.2022', 0 , 0 , '??? 1' , 15 , 16),
	  ('20.03.2022', 0 , 3 , '??? 1' , 10, 1),
	  ('02.04.2022', 0 , 0 , '??? 2' , 8 , 2 ),
	  ('02.04.2022', 1 , 1 , '??? 2' , 3 , 13),
	  ('02.04.2022', 0 , 3 , '??? 2' , 15, 1),
	  ('02.04.2022', 2 , 2 , '??? 2' , 14, 9),
	  ('03.04.2022', 1 , 1 , '??? 2' , 12 , 5),
	  ('03.04.2022', 3 , 1 , '??? 2' , 4 , 11),
	  ('03.04.2022', 0 , 2 , '??? 2' , 6 , 10),
	  ('03.04.2022', 4 , 0 , '??? 2' , 7 , 16),
	  ('09.04.2022', 1 , 1 , '??? 2' , 4 , 8),
	  ('09.04.2022', 1 , 2 , '??? 2' , 10, 3),
	  ('09.04.2022', 1 , 0 , '??? 2' , 5 , 11),
	  ('10.04.2022', 2 , 1 , '??? 3' , 2 , 14),
	  ('10.04.2022', 0 , 3 , '??? 3' , 16, 1),
	  ('10.04.2022', 1 , 1 , '??? 3' , 9 , 7),
	  ('11.04.2022', 0 , 0 , '??? 3' , 13 , 12),
	  ('11.04.2022', 2 , 3 , '??? 3' , 15 , 6),
	  ('15.04.2022', 2 , 4 , '??? 4' , 8 , 5),
	  ('16.04.2022', 1 , 1 , '??? 4' , 9 , 2),
	  ('16.04.2022', 1 , 0 , '??? 4' , 11 , 13),
	  ('16.04.2022', 0 , 1 , '??? 4' , 7 , 1),
	  ('16.04.2022', 0 , 0 , '??? 4' , 3 , 15),
	  ('17.04.2022', NULL , NULL , '??? 4' , 12 , 10),
	  ('17.04.2022', NULL , NULL , '??? 4' , 6 , 16),
	  ('17.04.2022', NULL , NULL , '??? 4' , 14 , 4),
	  ('21.04.2022', NULL , NULL , '??? 5' , 13 , 8),
	  ('22.04.2022', NULL , NULL , '??? 5' , 15 , 12),
	  ('22.04.2022', NULL , NULL , '??? 5' , 2 , 7),
	  ('22.04.2022', NULL , NULL , '??? 5' , 1 , 6),
	  ('23.04.2022', NULL , NULL , '??? 5' , 4 , 9),
	  ('23.04.2022', NULL , NULL , '??? 5' , 10 , 11),
	  ('23.04.2022', NULL , NULL , '??? 5' , 5 , 14),
	  ('23.04.2022', NULL , NULL , '??? 5' , 16 , 3)

go

insert into FootballStatistics.dbo.News(Header, NewsText)
values('???? ???????? ?? "???????-?????" ? 5-? ????', '???? 5-?? ???? ?????? ???? ????? ???? ? "???????" ????????? ?? "???????-?????". "?????-?????" ??????? ??????? ????, ??? ??? ? 
??????? ????????? ????????? ?????????? ??? ?????? ????????????? ?? ??????, ??? ?? ???????? ?? ??????? ???????????? ?????????? ?????. ??? ????????? ???? ???? ???????? ?? ????? ???????? 
????????, ?????????? ? ???????????? ??????? ??????? ? ???????? Football.by ????? ????????? ?????? ??? "????????" (1:0). ??????? ???????: "??????????, ????? ???????? ?? ?????". ???? 5-?? 
???? ???? ? "??????" ????????? 22 ??????. ?????? ? 20.00.'),
	  ('?????? ?????????: ????? ???????? ?? ?????????, ?? ? ????? ?????? ????? ??????????', '??????? ?????? ?????????? "??????" ?????? ????????? ???????????????? ???????? ????????? ?? "??????????-???" (1:2) ? ?????????????? ????? 4-?? ???? ?????? ????.
 
 
? ?? ????????????, ??? ????? ??????? ????????. ? ????????, ??? ? ??????????. ????????????, ????? ??? ???????? ????, ? ?? ???? ????? ???????????. ????? ???????? ?? ????????? ??? ????????, ?? ? ????? ?????? ????? ??????????. ? ???? ??????? ??????? ??????. ????????? ? ????? ????????, ???? ?????? ? ???????? ??????? ? ??????? ??????? ? ?????????? ????????.

? ?? ??????? ??? ?? ???? ???????, ????? ????? ??????? ??????????? ????????????. ?????? ????????. ? ??? ????????
? ?????????? ?????? ?????, ???? ??? ??????????????? ??????, ??? ???????? ??, ???. ????? ??????. ???? ?????? ??-??????????? ???? ? ?????.'),
	  ('????? ????????: "?? ?????? ????? ?????? ????????? ??????????? ?????????"', '??????? ?????? "??????????-???" ????? ???????? ??? ????????? ????????? ?? ????????????? ?????-??????????? ????? ???????? ?????? ??? ????????? "??????" (2:1).
 
 
? ???? ????? ????????? ?? ??? ?????: ?????? ?????? ? ??????????? ?????? ??? ??????? ????????. ????????, ? ????????? ????? ??????????????? ?????????????, ?? ??? ??????????. ?? ?????? ????? ?? ?????? ????????? ??????????? ?????????, ??????? ?????? ?? ??????????, ?????? ? ?????? ???? ?? ??????. ? ????? ?? ????? ?????? ??????????? ????????? ? ?????-?? ????????? ????? ??????? ??????????? ? ????????.'),
	  ('?????? ????. ?????? ????, "??????" ? "??????????-???"', '????????? 4-?? ???? ?????????? ???????? ? ?????? ???? ? ??????????? ?????????? ????? ???????. ? ??????? ???????? "??????" ? ?????? ??? ????, "??????" ??????? ?????????? ?? ????????, ? ? ?????? "?????????-???" ???? ??????? ??????????????? ????.
 
 
???????? ?????? ? ??????, ??????? ????? ? ??????????. ????? 4-?? ???? ?????? ????

?????? (?????) - ?????????-??? (?????) - 1:2
????: 0:1 - ??????????? (54, ? ???????? ?? ??? ?????? ?????????????), 1:1 - ????????? (66, ??? - ????????), 1:2 - ???????? (87, ??? - ????????????).
17.04.2022. 20:30 ?????, ??? "?????????".')

go


insert into FootballStatistics.dbo.Players(PlayerName, TeamId)
values
('????? ???????????', 4),
('????? ?????', 7),
('???? ????????????',5),
('????? ????????',4),
('????????? ??????',6),
('??????? ???????????',1),
('??????? ????????',10),
('?????? ???????',7),
('??????? ??????',6),
('???? ?????',6),
('????? ?????',13),
('?????? ?????????', 14),
('????????? ??????',1),
('?????? ??????????',9),
('???? ??????',10),
('????? ?????',3),
('????????? ???????',5),
('??????? ???????????',8),
('???? ????????',4),
('?????? ????????',14),
('???? ???????',8),
('????????? ?????????',1),
('?????? ?????????',5),
('????? ????????',2),
('????? ?????????',5),
('????? ??????',7),
('?????? ??????',14),
('?????? ??????',11),
('??????? ?????',1),
('????????? ?????',14)

go

insert into FootballStatistics.dbo.Goals(Id, CountOfGoals)
values
( 1 , 5),
(2,3),
(3,3),
(4,2),
(5,3),
(6,2),
(7,1),
(8,1),
(11,2),
(12,2),
(13,2),
(14,2),
(15,2),
(16,1),
(17,1),
(18,1),
(19,1),
(20,1),
(21,1),
(22,1),
(23,1),
(24,1),
(29,1),
(30,1)

go

insert into FootballStatistics.dbo.Assists(Id, CountOfAssists)
values
( 1 , 2),
(2,1),
(3,1),
(4,4),
(6,1),
(7,2),
(8,2),
(9,3),
(10,3),
(16,1),
(17,1),
(18,1),
(19,1),
(20,1),
(21,1),
(22,1),
(23,1),
(24,1),
(25,2),
(26,2),
(27,2),
(28,2)

go 

insert into FootballStatistics.dbo.Tickets(Town, Stadium, CountOfPlace, GameId)
values 
('???????' , '??? ?????????', 1000 , 30),
('??????' , '???????????' , 1489, 31),
('?????' , '?????????' ,2479, 32)

go

insert into FootballStatistics.dbo.Users(LoginId, Password, FamilyName, Name, DateOfBirthd, Country, Town)
values('Admin', '1111', NULL, NULL, NULL, NULL, NULL)
