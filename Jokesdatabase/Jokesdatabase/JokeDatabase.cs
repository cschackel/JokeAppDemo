using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jokesdatabase
{
    public class JokeDatabase
    {

        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public JokeDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Joke).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Joke)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        public Task<List<Joke>> GetItemsAsync()
        {
            return Database.Table<Joke>().ToListAsync();
        }
        /*
        public Task<List<Joke>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<Joke>("SELECT * FROM [Joke] WHERE [Done] = 0");
        }
        */
        public Task<Joke> GetItemAsync(int id)
        {
            return Database.Table<Joke>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Joke item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Joke item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
