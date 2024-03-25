using RepositoryPattern.Domain;
using RepositoryPattern.Exceptions;
using RepositoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Data
{

    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly List<T> _items = new List<T>();

        public T? GetById(int id)
        {
            T? itemSearched = null;        
                
                foreach (T item in _items)
                {                    
                    if (item.Id == id)
                    {
                        itemSearched = item;                      
                        return itemSearched;
                    }
                }

            return itemSearched;        
        }

        public IList<T> GetAll()
        {
            return _items;
        }

        public T Add(T entity)
        {
            _items.Add(entity);
            return entity;
        }

        public int? Update(T entity)
        {      
            for (int j = 0; j < _items.Count; j++)
            {
                T item = _items[j];
                if (item.Id == entity.Id)
                {
                  var position = _items.IndexOf(item);
                    _items[position] = entity;                   
                }
            }
            return entity.Id;
        }

        public void Delete(int id)
        {
            foreach (T item in _items)
            {
                if (item.Id == id)
                {
                    _items.Remove(item);
                    break;
                }                
            }
        }
    }
}
