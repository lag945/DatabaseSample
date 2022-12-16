# DatabaseSample
紀錄資料庫常用的組合與教學

## EFCoreSQLite
- 選擇EFCore+SQLite的原因是MSLocalDB當單機型資料庫使用太難用了
	- 容易卡安裝、卡散佈
- 選擇EF Core單純因為微軟寫的[Getting Started with EF Core](https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli)
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
```
- 賣點是code first & auto Migrate，檔案存在就更新、不存在就建立，只要一行```Database.Migrate();```
	- 詳情參考 [如何使用 EF Core DbContext 以 Microsoft.EntityFrameworkCore.Sqlite 為例](https://dotblogs.com.tw/yc421206/2021/04/16/how_to_use_ef_core_dbcontexgt_by_microsoft_entity_framework_core_sqlite_example)

## EFSQLite
- nuget 安裝System.Data.SQLite，試了一下功能不完整，建議要EF還是選用EFCore微軟的版本
- 放棄
## SQLite
- nuget 安裝System.Data.SQLite.Core就好，EF、Linq用不到
- 教學可以參考[微軟netcore版本](https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/?tabs=netcore-cli)的說明，用法大同小異，大小寫不同而已
- db可以手動建立，如使用[SQLiteStudio](https://sqlitestudio.pl/)，建立test.db後加入專案，並設定[複製到輸出目錄-有更新時才複製]
- 請保持使用[參數化查詢](https://learn.microsoft.com/zh-tw/dotnet/api/system.data.sqlclient.sqlcommand.parameters)