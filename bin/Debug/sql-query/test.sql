select *
from classsizes.dbo.classoverloadrules
where penaltytype is not null
--or penaltygroup is null
--or lowstudents is null
--or highstudents is null
--or amount is null
--or usage is null