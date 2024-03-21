using RepositoryPattern.Domain;
using RepositoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Data
{

    internal class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private List<T> _items = new List<T>();

        public T GetById(int id)
        {
            T itemSearched = null;

            foreach (T item in _items)
            {
                if (item.Id == id)
                {
                    itemSearched = item;
                    Console.WriteLine($"the item with id {id} is {itemSearched.Name}");
                    return itemSearched;
                }
            }
            return itemSearched = null;
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

        public int Update(T entity)
        {
            T itemUpdated = null;

            foreach (T item in _items)
            {
                if (item.Id == entity.Id)
                {
                    itemUpdated= entity;
                }
            }

            return itemUpdated.Id;
        }


        public void Delete(int id)
        {
            foreach (T item in _items)
            {
                if (item.Id == id)
                {
                    _items.Remove(item);
                    break;
                } else
                {
                    Console.WriteLine("Item you want to delete was not found!");
                }
            }
        }
    }
}
