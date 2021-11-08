using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
#pragma warning disable 1591
namespace Jiex.EFcore
{
    public class EFCoreContext : DbContext
    {
        public EFCoreContext()
        {

        }
        protected Assembly Assembly = typeof(EFCoreContext).Assembly;
        public EFCoreContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql
                    (
                    "server=localhost;userid=root;pwd=123456;port=3306;database=demo;sslmode=none",
                    x => x.ServerVersion("8.0.26-mysql"));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entities = Assembly.ExportedTypes
                .Where
                (t => t.IsClass && !t.IsAbstract && typeof(IEntity).IsAssignableFrom(t));
            foreach (Type type in entities)
            {
                var method = modelBuilder.GetType().GetMethods()
                 .FirstOrDefault(c => c.IsGenericMethod);
                method = method.MakeGenericMethod(new Type[] { type });
                method.Invoke(modelBuilder, null);
            }

            base.OnModelCreating(modelBuilder);
            // 配置数据库
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly);
        }
    }
}
