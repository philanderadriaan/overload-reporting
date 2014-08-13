--select coursedescription
--from classsizes2.dbo.classes
--group by coursedescription
--from classsizes2.dbo.classoverloadrules

select coursedescription
from classsizes.dbo.classes
group by coursedescription
order by coursedescription
--join classsizes.dbo.classoverloadrules as b
--on a.course = b.course

--SELECT *
--FROM INFORMATION_SCHEMA.COLUMNS 
--WHERE COLUMN_NAME LIKE '%course%'