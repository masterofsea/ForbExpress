using System;
using System.Collections.Generic;
using System.Linq;
using ForbExpress.Models;

namespace ForbExpress.DAL.Repositories.CorrespondenceRepository
{
    public class TestCorrespondenceRepository : ICorrespondenceRepository
    {
        private List<Correspondence> Correspondence { get; }
        private string[] Names { get; } = {"Борис", "Андрей", "Стас", "Игорь", "Егор", "Никита", "Людмила", "Арсений", "Салават"};
        private string[] Cities { get; } = {"Туристская", "Фомичева", "Ленина", "Первомайская"};

        public TestCorrespondenceRepository()
        {
            var rnd = new Random();
            Correspondence = new List<Correspondence>();

            for (var i = 1; i <= 1000; ++i)
            {
                Correspondence.Add(new Correspondence()
                {
                    Id = i,
                    Status = (LetterStatus)(i % 2),
                    ReceiverName = Names[rnd.Next(0, Names.Length)],
                    SenderName = Names[rnd.Next(0, Names.Length)],
                    ReceivingAddress = $"Город Москва, улица {Cities[rnd.Next(0, Cities.Length)]}, дом {rnd.Next(1, 32)}"
                });
            }
        }
        public IEnumerable<Correspondence> GetAllCorrespondence()
        {
            return Correspondence;
        }

        public Correspondence GetCorrespondenceById(int id)
        {
            return Correspondence.First(i => i.Id == id);
        }

        public IEnumerable<Correspondence> GetCorrespondenceSlice(int skip, int take)
        {
            return Correspondence.Skip(skip).Take(take);
        }

        public int GetCorrespondenceCount()
        {
            return Correspondence.Count;
        }
    }
}