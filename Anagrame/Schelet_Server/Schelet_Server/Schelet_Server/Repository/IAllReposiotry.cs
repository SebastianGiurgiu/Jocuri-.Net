using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schelet_Server.Repository
{
    public interface IAllReposiotry<T> where T : class
    {

        IEnumerable<T> GetModel();

        T GetModelById(int modelId);

        void InsertModel(T model);

        void DeleteModel(int modelId);

        void UpdateModel(T model);

        void Save();

    }
}
