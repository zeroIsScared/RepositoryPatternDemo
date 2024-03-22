using RepositoryPattern.Domain;
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
            
            List<int> listOfExistingIds = new List<int>();  

            foreach (T item in _items)
            {
                listOfExistingIds.Add(item.Id);
                if (item.Id == id)
                {
                   itemSearched = item;
                    Console.WriteLine($"The item with id {id} is {itemSearched.Name}( from GetBYId method)");
                    return itemSearched;
                }
            }           
/*
            if (listOfExistingIds.Contains(id) == false)
            {
                return itemSearched;
                throw new ArgumentException($"The item with id {id} was not found");
            }*/
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
            if (_items.Contains(entity) == false) 
            {
                throw new DataException("Can't update an inexistent item.");
            }

            for (int j = 0; j < _items.Count; j++)
            {
                T item = _items[j];
                if (item.Id == entity.Id)
                {
                  var position = _items.IndexOf(item);
                    _items[position] = entity;
                    Console.WriteLine($"The item {_items[position].Name}");
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
                else
                {
                    throw new DataException("Item you want to delete was not found!");

                }
            }
        }
    }
}
