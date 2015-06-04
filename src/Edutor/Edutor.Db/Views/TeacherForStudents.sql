CREATE VIEW [dbo].[TeacherForStudents]
	AS SELECT * 
	FROM Users
		INNER JOIN ( 
			SELECT DISTINCT T.UserId AS [InnerTeacherId],StudentId
			FROM Users T
				INNER JOIN Teachings TE
					ON TE.SchoolUserId = T.UserId
				INNER JOIN Enrollments E
					ON TE.GroupId = E.GroupId
		) AS Users1
		ON Users.UserId = Users1.[InnerTeacherId]
