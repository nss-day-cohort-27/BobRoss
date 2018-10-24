# Identity Scaffolding

The following command was used to generate custom Register, Login, and Logout views for the existing application.

```sh
dotnet aspnet-codegenerator identity -dc MusicFavorites.Data.ApplicationDbContext --files "Account.Register;Account.Login;Account.Logout"
```