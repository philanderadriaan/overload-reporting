--select coursedescription
--from classsizes2.dbo.classes
--group by coursedescription
--from classsizes2.dbo.classoverloadrules

select *
from classsizes.dbo.classoverloadrules
--group by coursedescription
--order by coursedescription
--join classsizes.dbo.classoverloadrules as b
--on a.course = b.course

--SELECT *
--FROM INFORMATION_SCHEMA.COLUMNS 
--WHERE COLUMN_NAME LIKE '%course%'