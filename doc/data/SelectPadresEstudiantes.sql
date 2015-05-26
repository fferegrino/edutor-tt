SELECT 'curp padre|curp hijo|nombre hijo|relacion|direccion|telefono'
UNION
SELECT T.Curp + '|' + S.Curp + '|' +  S.Name + '|' + S.TutorRelationship + '|' + T.[Address] + '|' + T.Phone
FROM Users T
	INNER JOIN Students S
	ON T.UserId = S.TutorId