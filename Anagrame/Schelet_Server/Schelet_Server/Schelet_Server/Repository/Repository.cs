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

        private AnagrameEntities10 context;
        private IDbSet<T> dbEntity;


        public Repository()
        {
            context = new AnagrameEntities10();
            dbEntity = context.Set<T>();
        }

        public T GetModelById(string v)
        {
            return dbEntity.Find(v);
        }

        public void DeleteModel(int modelId)
        {
            T model = dbEntity.Find(modelId);
            dbEntity.Remove(model);
        }

        public IEnumerable<T> GetModel()
        {
            return dbEntity.ToList();
        }

        public T GetModelById(int modelId)
        {
            return dbEntity.Find(modelId);
        }

        public void InsertModel(T model)
        {
            dbEntity.Add(model);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateModel(T model)
        {
            context.Entry(model).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
