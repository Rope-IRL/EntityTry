using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using EntityPlLinq.models;
using System.Collections;
using System.Data.Common;
using System.Security.Cryptography;


namespace EntityTry.Helpers
{
    public static class Actions
    {
        public static void PrintData(IEnumerable items)
        {
            foreach (var item in items) {
                Console.WriteLine($"Item is {item.ToString()}");
            }
        }

        public static void SelectAllFlatsInfoFromOne(Db7813Context db)
        {
            var q = from f in db.Flats
                    select new
                    {
                        f.Header,
                        f.Description,
                        f.CostPerDay,
                        f.Ll.Email,
                    };
            PrintData(q.ToList());
        }
        public static void SelectAllFlatsInfoWithFilterFromOne(Db7813Context db)
        {
            var q = from f in db.Flats
                    where (f.Llid == 46)
                    select new
                    {
                        f.Header,
                        f.Description,
                        f.CostPerDay,
                        f.Ll.Email,
                    };
            PrintData(q.ToList());
        }

        public static void SelectAllLandLordsContractsInfoByCostMany(Db7813Context db)
        {
            var q = from f in db.HousesContracts
                    group f.Cost by f.Ll.Email into g
                    select new{
                        Key = g.Key,
                        Value = g.Sum()
                    };
            PrintData(q.ToList());
        }

        public static void SelectTwoFieldsFromTwoTables(Db7813Context db)
        {
            var q = from h in db.Houses
                    join hc in db.HousesContracts
                    on h.Pid equals hc.Pid
                    select new
                    {
                        h.Header,
                        h.Description,
                        hc.StartDate,
                        hc.EndDate
                    };
            PrintData(q.ToList());
        }

        public static void SelectTwoFieldsWithFilterFromTwoTables(Db7813Context db)
        {
            var q = from h in db.Houses
                    join hc in db.HousesContracts
                    on h.Pid equals hc.Pid
                    where hc.EndDate < new DateOnly(2024, 9, 20)
                    select new
                    {
                        h.Header,
                        h.Description,
                        hc.StartDate,
                        hc.EndDate
                    };
            PrintData(q.ToList());
        }

        public static void InsertIntoFlatOne(Db7813Context db)
        {
            Flat flat = new Flat()
            {
                Header = "New beautiful flat 2",
                Description = "New decsription",
                AvgMark = new Decimal(4.34),
                City = "London",
                Address = "Baker st. 8",
                NumberOfFloors = 2,
                NumberOfRooms = 5,
                WiFiAvailability = true,
                BathroomAvailability = true,
                CostPerDay = new Decimal(100.2),
                Llid = 3
            };

            db.Add(flat);
            db.SaveChanges();
        }

        public static void InsertIntoFlatContractstMany(Db7813Context db)
        {
            FlatsContract flatcontract = new FlatsContract()
            {
                Lid = 2,
                Llid = 3,
                StartDate = new DateOnly(2023, 2, 1),
                EndDate = new DateOnly(2023, 2, 10),
                Cost = new Decimal(54.8),
                Fid = 501
            };

            db.Add(flatcontract);
            db.SaveChanges();
        }

        public static void DeleteFromFlats(Db7813Context db, Int32 id)
        {
            var wrM = db.FlatsContracts.Where(c => c.Fid == id);
            var wrO = db.Flats.Where(c => c.Fid == id);
            db.FlatsContracts.RemoveRange(wrM);
            db.Flats.RemoveRange(wrO);
            db.SaveChanges();
        }

        public static void UpdateByStatement(Db7813Context db)
        {
            int id = 4;
            var wrO = db.Flats.Where(c => c.Fid == id).FirstOrDefault();
            if (wrO != null)
            {
                wrO.CostPerDay = wrO.CostPerDay + 20;
                db.SaveChanges();
            }
        }
    }
}
