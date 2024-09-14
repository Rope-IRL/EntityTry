using EntityPlLinq.models;
using EntityTry.Helpers;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System.Security.Cryptography;

public static class Program
{
    public static void Main()
    {
        using (Db7813Context db = new Db7813Context())
        {
            ////comments
            Console.WriteLine("All flats");
            Actions.SelectAllFlatsInfoFromOne(db);
            Console.WriteLine("\n");

            Console.WriteLine("All flats with filter");
            Actions.SelectAllFlatsInfoWithFilterFromOne(db);
            Console.WriteLine("\n");

            Console.WriteLine("All landlords with filter by average cost");
            Actions.SelectAllLandLordsContractsInfoByCostMany(db);
            Console.WriteLine("\n");

            Console.WriteLine("Selecting from 2 tables");
            Actions.SelectTwoFieldsFromTwoTables(db);
            Console.WriteLine("\n");

            Console.WriteLine("Selecting from 2 tables with filter");
            Actions.SelectTwoFieldsWithFilterFromTwoTables(db);
            Console.WriteLine("\n");

            Console.WriteLine("Insert into flat in one");
            Actions.InsertIntoFlatOne(db);
            Console.WriteLine("\n");

            Console.WriteLine("Insert into flat contracts in many");
            Actions.InsertIntoFlatContractstMany(db);
            Console.WriteLine("\n");

            var s = from fc in db.FlatsContracts
                    where fc.Lid == 2 && fc.Llid == 3
                    select new
                    {
                        fc.Lid,
                        fc.Llid,
                        fc.StartDate,
                        fc.EndDate,
                    };
            foreach (var fc in s)
            {
                Console.WriteLine(fc.ToString());
            }

            Console.WriteLine("Delete from flats and flats contract id = 8");
            Int32 id = 8;
            Actions.DeleteFromFlats(db, id);
            Console.WriteLine("\n");
            var l = from d in db.FlatsContracts
                    where d.Fid == 8
                    select new
                    {
                        d.Id,
                        d.StartDate,
                        d.EndDate,
                        d.Fid
                    };
            foreach (var item in l)
            {
                Console.WriteLine(item.ToString());
            }


            Console.WriteLine("Update value by statement");
            Actions.UpdateByStatement(db);
            Console.WriteLine("\n");
        }
          
    }
}