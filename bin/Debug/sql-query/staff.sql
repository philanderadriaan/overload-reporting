select coalesce(nullif([long-name],''), [short-name]) as name
from classoverload.dbo.staff