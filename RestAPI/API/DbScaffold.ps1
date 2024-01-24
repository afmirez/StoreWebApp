#Comando Para PM console: .\API\DBScaffold.ps1
Scaffold-DbContext "Name=StoreDB" Microsoft.EntityFrameworkCore.SqlServer -Context StoreDB -ContextDir Data -OutputDir Data\Models -Force -NoPluralize