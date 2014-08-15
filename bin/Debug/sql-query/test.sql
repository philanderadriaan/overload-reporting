select *
from classsizes.dbo.classoverloadrules
--where schoolyear <> 2011
--where penaltytype is not null
--and penaltygroup is not null
--and lowstudents is not null
--and highstudents is not null
--and amount is not null
--and usage is not null
where period = 8
and coursesubject = 11