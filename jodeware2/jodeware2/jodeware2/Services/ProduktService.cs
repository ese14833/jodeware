using jodeware2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace jodeware2.Services
{
    public class ProduktService : IProduktService
    {
        private readonly IProduktRepository _repository;

        public ProduktService(IProduktRepository repository)
        {
            if(repository == null)
            {
                throw new ArgumentNullException("repository");
            }

            _repository = repository;
        }

        public bool DoesProduktExist(string id)
        {
            //if (id == null)
            //{
            //    throw new ArgumentNullException("id");
            //}

            return _repository.DoesProduktExist(id);
        }

        public Produkt Find(string id)
        {
            //if (id == null)
            //{
            //    throw new ArgumentNullException("id");
            //}

            return _repository.Find(id);
        }

        public IEnumerable<Produkt> GetData()
        {
            return _repository.All;
        }

        public void InsertData(Produkt produkt)
        {
            if (produkt == null)
            {
                throw new ArgumentNullException("produkt");
            }

            _repository.Insert(produkt);
        }

        public void UpdateData(Produkt produkt)
        {
            if (produkt == null)
            {
                throw new ArgumentNullException("produkt");
            }

            _repository.Update(produkt);
        }

        public void DeleteData(string id)
        {
            //if (id == null)
            //{
            //    throw new ArgumentNullException("produkt");
            //}

            _repository.Delete(id);
        }

    }
}
