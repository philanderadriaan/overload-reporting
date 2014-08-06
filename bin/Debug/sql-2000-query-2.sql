select ServerName = @@SERVERNAME
       ,DatabaseName = DB_NAME()
          ,c.Type
          ,c.ItemID
          ,c.Name
   from reportserver.dbo.catalog c 
 
select ServerName = @@SERVERNAME
       ,DatabaseName = DB_NAME()
      ,c.Name as ReportName
      ,LastRunTime = max(l.TimeEnd)
  ,FirstRunTime = min(l.TimeEnd)
  ,RunCount = count(*)
  from reportserver.dbo.ExecutionLog l
  join reportserver.dbo.catalog c
    on c.ItemID = l.ReportID
  group by c.Name