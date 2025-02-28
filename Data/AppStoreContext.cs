using System;
using Mycrosoft.EntityFrameworkCore;

namespace WebApplication2.Data;

public class AppStoreContext(DbContextOptions<AppStoreContext> options) : DbContext(options)
{
    public DbSet<App> Apps => Set<App>();

    public DbSet<Genre> Genres => Set<Genre>();
}
