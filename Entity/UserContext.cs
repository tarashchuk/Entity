using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace Entity
{
    class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }

   /* DbContext: определяет контекст данных, используемый для взаимодействия с базой данных.

    DbModelBuilder: сопоставляет классы на языке C# с сущностями в базе данных.

DbSet/DbSet<TEntity>: представляет набор сущностей, хранящихся в базе данных
*/
}
