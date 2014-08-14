select *
from classsizes.dbo.classoverloadrules
where penaltytype is not null
and penaltygroup is not null
and lowstudents is not null
and highstudents is not null
and amount is not null
and usage is not null
and period = 8