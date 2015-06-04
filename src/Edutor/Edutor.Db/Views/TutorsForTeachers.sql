CREATE VIEW [dbo].[TutorsForTeachers]
	AS SELECT F.TeacherId,F.TutorId,F.GroupId,F.GroupName,Tutors.*
	FROM Users Tutors
		INNER JOIN
			(	SELECT DISTINCT U.UserId as TutorId, G.GroupId, G.Name AS GroupName, T.SchoolUserId AS TeacherId
				FROM Users U
					INNER JOIN Students S
						ON S.TutorId = U.UserId
					INNER JOIN Enrollments E
						ON E.StudentId = S.StudentId
					INNER JOIN Groups G
						ON E.GroupId = G.GroupId
					INNER JOIN Teachings T
						ON T.GroupId = G.GroupId
					
			) F
			ON F.TutorId = Tutors.UserId
