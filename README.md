# DatabaseSample
紀錄資料庫常用的組合與教學

## EFCoreSQLite
- 選擇EFCore+SQLite的原因是MSLocalDB當單機型資料庫使用太難用了
	- 容易卡安裝、卡散佈
- 不用framework單純因為微軟寫的[Getting Started with EF Core](https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli)
- 缺點是nuget最新版需要.NET 6，沒vs2022的就用vscode打指令吧，常用指令如下
```
# 建立console專案
dotnet new console -o EFCoreSQLite
# 進入專案
cd EFCoreSQLite
# 安裝Entity Framework Core SQLite
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
# 手動建立資料庫(請先打到model.cs)
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate
dotnet ef database update
# vscode開啟資料夾
code ../EFCoreSQLite

- 賣點是auto Migrate，檔案存在就更新、不存在就建立，只要一行```Database.Migrate();```
	- 詳情參考 [余小章-SQLite Code First 和 Migration](https://dotblogs.com.tw/yc421206/2020/02/10/sqlite_code_first_migration)
