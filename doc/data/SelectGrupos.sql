SELECT 'Name|Subject|FromDate'
UNION
SELECT Name +'|'+[Subject] + '|' +  CONVERT(VARCHAR,FromDate,20)  FROM Groups