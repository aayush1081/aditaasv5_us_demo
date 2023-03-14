Scaffold-DbContext 'Server=tcp:aditaas-ind-nonprod-dbserver.database.windows.net,1433;Initial Catalog=aditaas_demo_qa;Persist Security Info=False;User ID=aditaas_product_multidev;Password=ADS@Dem0MuDb@22;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;' Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force -Context aditaas_v5Context -NoPluralize

dotnet ef dbcontext scaffold "Host=10.102.4.172;Port=5432;Username=postgres;Password=allied@123;Database=aditaas_v5_dev;" Npgsql.EntityFrameworkCore.PostgreSQL -o Models -f

Scaffold-DbContext "server=localhost;port=3306;user=root;password=mypass;database=sakila" MySql.Data.EntityFrameworkCore -OutputDir Sakila -Tables actor,film,film_actor,language -f   
npm update -

Redis Download link: https://github.com/tporadowski/redis/releases/tag/v5.0.14

ng build --aot
node --max_old_space_size=8192 node_modules/@angular/cli/bin/ng build --configuration production
Set-ExecutionPolicy RemoteSigned

OnModelCreatingView(modelBuilder);

    
git config --global http.sslVerify false
​git config --global http.postBuffer 524288000


Install-Package GrapeCity.Documents.Html -Version 4.0.0.616
Install-Package GrapeCity.Documents.Html.Windows.X64 -Version 4.0.0.616


*** Insert Identity Column with Value ***
INSERT INTO color (color_id, color_name)
OVERRIDING SYSTEM VALUE 
VALUES(2, 'Green');





** PostgreSQL Database Backup and Restore **

C:\Program Files (x86)\PostgreSQL\10\bin>
Source:- (Backup)
>> cd C:\Program Files (x86)\PostgreSQL\10\bin>
>> pg_dump -U postgres -h localhost -p 5433 -F c -b -v -f "D:\PGBackup\aditaas_v5_dev.dmp" aditaas_v5_dev
 
Target:-(Restore)
>> Create a Database 
>> pg_restore -U postgres -d aditaas_v5 -h localhost -p 5433 -v -O"D:\PGBackup\aditaas_v5_dev.dmp"
 
vacuumdb -U postgres -h localhost -p 5433 -d aditaas_v5 -f -z -v


**********

ALTER SEQUENCE tbl_cnf_sla_sla_id_seq RESTART WITH 105;

**********
Fix all sequences in one go
https://wiki.postgresql.org/wiki/Fixing_Sequences
**********

Redis:
https://github.com/microsoftarchive/redis/releases



!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
Sonar qube:-

dotnet sonarscanner begin /k:"V5-Rest-API" /d:sonar.host.url="http://aditaasv4demo.allieddigital.net:9000"  /d:sonar.login="b87020308ec2f8baf44d78ea6df2a5b8e0dcaf33"

dotnet build

dotnet sonarscanner end /d:sonar.login="b87020308ec2f8baf44d78ea6df2a5b8e0dcaf33"
!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!