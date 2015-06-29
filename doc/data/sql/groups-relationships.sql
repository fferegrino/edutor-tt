select U.UserId, U.Curp, U.Name, G.GroupId, G.Name
from Teachings T 
	inner join Users U
		on T.SchoolUserId = U.UserId
	inner join Groups G
		on G.GroupId= T.GroupId
order by T.SchoolUserId


select S.StudentId, S.Name, S.Token, G.GroupId, G.Name
from Enrollments T 
	inner join Students S
		on T.StudentId = S.StudentId
	inner join Groups G
		on G.GroupId= T.GroupId
order by T.StudentId

select T.UserId, T.Name, S.StudentId,S.Name,S.Token
from Users T
	inner join Students S
		ON T.UserId = S.TutorId

select T.UserId, T.Name, 'S:'+T.Curp + ':' + CAST(T.UserId AS VARCHAR)
from Users T
where T.Position = 'P'