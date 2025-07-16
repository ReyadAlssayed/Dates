using Supabase;
using Dates.Models;
using Supabase.Postgrest.Models;

namespace Dates.Service
{
    public class DataService
    {
        private readonly Client _client;

        // ✅ نأخذ Supabase.Client من الـ Dependency Injection
        public DataService(Client client)
        {
            _client = client;
        }

        public async Task AddDateFruitEntryAsync(DateFruitEntry entry)
        {
            await _client.From<DateFruitEntry>().Insert(entry);
        }

        public async Task<List<DateFruitEntry>> GetAllDateFruitsAsync()
        {
            var result = await _client.From<DateFruitEntry>().Get();
            return result.Models;
        }

        public async Task<List<DateFruitEntry>> GetEntriesByUser(Guid userId)
        {
            var result = await _client
                .From<DateFruitEntry>()
                .Filter("user_id", Supabase.Postgrest.Constants.Operator.Equals, userId.ToString())
                .Get();

            return result.Models;
        }
        public async Task UpdateEntryAsync(DateFruitEntry entry)
        {
            await _client.From<DateFruitEntry>().Update(entry);
        }


    }
}
