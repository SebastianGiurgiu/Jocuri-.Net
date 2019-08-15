using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace Schelet_Server.Repository
{
    public class Repository<T> : IAllReposiotry<T> where T : class
    {

       // private GhicesteCuvantEntities3 context;
       // private IDbSet<T> dbEntity;


        public Repository()
        {
          //  context = new GhicesteCuvantEntities3();
            
           // dbEntity = context.Set<T>();
            
        }
      //    using (var db2 = new UsersEntities())

        public T GetModelById(string v)
        {
            using (var context = new ExamenEntities())
            {
                var dbEntity = context.Set<T>();
                return dbEntity.Find(v);

            }
        }

        public void DeleteModel(int modelId)
        {
            using (var context = new ExamenEntities())
            {
                var dbEntity = context.Set<T>();
                T model = dbEntity.Find(modelId);
                dbEntity.Remove(model);
                context.SaveChanges();
            }
        }

        public IEnumerable<T> GetModel()
        {

            //     return dbEntity.ToList();

            using (var context = new ExamenEntities())
            {
                var dbEntity = context.Set<T>();
                return dbEntity.ToList();
            }

        }

        public T GetModelById(int modelId)
        {
            using (var context = new ExamenEntities())
            {
                var dbEntity = context.Set<T>();
                return dbEntity.Find(modelId);
            }
        }

        public void InsertModel(T model)
        {
            using (var context = new ExamenEntities())
            {
                var dbEntity = context.Set<T>();
                dbEntity.Add(model);
                context.SaveChanges();
            }
        }

        public void Save()
        {
            using (var context = new ExamenEntities())
            {
                var dbEntity = context.Set<T>();
                context.SaveChanges();
            }
        }

        public void UpdateModel(T model)
        {
            using (var context = new ExamenEntities())
            {
                var dbEntity = context.Set<T>();
                context.Entry(model).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
