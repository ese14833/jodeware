using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace jodeware2.LocalDB
{
    public class HerstellerDB
    {
        readonly SQLiteAsyncConnection database;

        public HerstellerDB(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Hersteller>().Wait();
        }

        public Task<List<Hersteller>> GetHerstellersAsync()
        {
            return database.Table<Hersteller>().ToListAsync();
        }

        public Task<Hersteller> GetHerstellerAsync(int id)
        {
            return database.Table<Hersteller>().Where(i => i.HerID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveHerstellerAsync(Hersteller hersteller)
        {
            if (hersteller.HerID == 0)
            {
                return database.UpdateAsync(hersteller);
            }
            else
            {
                return database.InsertAsync(hersteller);
            }
        }
        public Task<int> DeleteHerstellerAsync(Hersteller hersteller)
        {
            return database.DeleteAsync(hersteller);
        }
    }
}