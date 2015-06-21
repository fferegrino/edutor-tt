delete from Groups where GroupId > 0

dbcc checkident('Groups',RESEED,0)

delete Students
dbcc checkident('Students',RESEED,0)

delete Users where UserId > 1
dbcc checkident('Users',RESEED,1)