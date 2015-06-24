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