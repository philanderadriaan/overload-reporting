--SERVER INFORMATION

create table #t
([index] varchar(2000),
[name] varchar(2000),
[internal_value] int,
[character_value] varchar(2000)) ;
insert into #t
exec xp_msver;
--select * from #t drop table #t

       SELECT ComputerName = CAST(SERVERPROPERTY('MachineName') AS varchar(100)) 
                      ,InstanceName = CAST(SERVERPROPERTY('ServerName') AS varchar(100)) 
                      ,SQLVersion = CAST(SERVERPROPERTY('ProductVersion') AS varchar(100)) 
                      ,SQLEdition = CAST(SERVERPROPERTY('Edition') AS varchar(100)) 
                      ,SQLLevel = CAST(SERVERPROPERTY('ProductLevel') AS varchar(100))  
                      ,IsClustered = CAST(SERVERPROPERTY('IsClustered') AS varchar(100))    
                      ,IsFullTextInstalled = CAST(SERVERPROPERTY('IsFullTextInstalled') AS varchar(100)) 
                      ,SecurityMode = CASE CAST(SERVERPROPERTY('IsIntegratedSecurityOnly') AS int) 
                                                  WHEN 0 THEN 'WINDOWS/SQL' 
                                                  WHEN 1 THEN 'WINDOWS ONLY'
                                                  ELSE 'UNKNOWN' 
                                                 END 
                      ,CPUCount          = (select internal_value from #t where name = 'ProcessorCount')
                      ,PhysicalMemory_GB = CAST(ROUND((select internal_value from #t where name = 'PhysicalMemory') / 1000 ,2) AS DECIMAL(10,2))
                     ,LastRestartDate = (SELECT crdate FROM sysdatabases WHERE name = 'tempdb')
 
 drop table #t
 
--SERVER CONFIGURATION INFORMATION
       EXEC SP_CONFIGURE 'show advanced option', '1'
       RECONFIGURE
       EXEC SP_CONFIGURE
 
 
--DATABASE INFORMATION
       EXEC SP_HELPDB
 
       SELECT d.dbid
             ,d.name as DatabaseName
                --,m.type_desc
                ,m.name
                ,m.filename
                ,m.size
         FROM sysaltfiles M
         JOIN sysdatabases d
           on d.dbid = m.dbid