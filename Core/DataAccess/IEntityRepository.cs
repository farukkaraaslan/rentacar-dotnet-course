using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {
        //Crud opretaions for database 
        //Burada ınterface kullanmanın amacı farklı bir orm aracı kullanmak gerekirse bu ınterfacesi kullanarak repostorybase ousturabilecek 
        List<T> GetAll(Expression<Func<T,bool>> filter = null);
        T Get(Expression<Func<T, bool>>filter);

        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
