using System;
using System.Collections.Generic;
using System.Linq;
using ForbExpress.Models;

namespace ForbExpress.DAL.Repositories.PartnersRepository
{
    public class TestPartnersRepository : IPartnersRepository
    {
        private List<Partner> Partners { get; }
        private string[] Names { get; } = {"Борис", "Андрей", "Стас", "Игорь", "Егор", "Никита", "Людмила", "Арсений", "Салават"};

        public TestPartnersRepository()
        {
            var rnd = new Random();
            Partners = new List<Partner>();

            for (var i = 1; i < 500; ++i)
            {
                Partners.Add(new Partner
                    {
                        Id = i, 
                        Email = $"{rnd.Next()}@gmail.com",
                        Name = Names[rnd.Next(0, Names.Length)],
                        Phone = $"+7(9{rnd.Next(10, 100)}) {rnd.Next(100, 1000)} - {rnd.Next(10, 100)} - {rnd.Next(10, 100)}",
                    });
            }
        }
        public IEnumerable<Partner> GetAllPartners()
        {
            return Partners;
        }

        public Partner GetPartnerById(int id)
        {
            return Partners.Find(i => i.Id == id);
        }

        public IEnumerable<Partner> GetPartnersSlice(int skip, int take)
        {
            return Partners.Skip(skip).Take(take);
        }

        public int GetPartnersCount()
        {
            return Partners.Count;
        }
    }
}