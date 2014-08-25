select *
from adsync.dbo.staff2
where firstname like '%[^a-Z0-9]%'
or lastname like '%[^a-Z0-9]%'
order by cast(nameid as int)