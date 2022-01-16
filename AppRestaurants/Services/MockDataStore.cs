using App2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App2.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Nom = "Tam Tam", Description="Fast Food" ,Localisation = "Gafsa Centre Ville ",NumTel="97654321"},
                new Item { Id = Guid.NewGuid().ToString(), Nom = "76", Description="Fast Food",Localisation = "Gafsa Centre Ville " ,NumTel="95954321"},
                new Item { Id = Guid.NewGuid().ToString(), Nom = "1017", Description="Cafétéria",Localisation = "Cité Chabab ",NumTel="97659821" },
                new Item { Id = Guid.NewGuid().ToString(), Nom = "Courtoise", Description="Fast Food",Localisation = "Gafsa Centre Ville ",NumTel="93854321"},
                new Item { Id = Guid.NewGuid().ToString(), Nom = "Vintage", Description="Salon de thé",Localisation = "Sidi Ahmed Zarroug ",NumTel="95054321"},
                new Item { Id = Guid.NewGuid().ToString(), Nom = "Twins", Description="Salon de thé",Localisation = "Sidi Ahmed Zarroug ",NumTel="97659321"},
                new Item { Id = Guid.NewGuid().ToString(), Nom = "Paradiso", Description="Salon de thé",Localisation = "Sidi Ahmed Zarroug",NumTel="93654300"},
                new Item { Id = Guid.NewGuid().ToString(), Nom = "Pasta Bella", Description="Fast Food",Localisation = "Sidi Ahmed Zarroug ",NumTel="97654388"},
                new Item { Id = Guid.NewGuid().ToString(), Nom = "Mix Max", Description="Fast Food",Localisation = "Cité Nour " ,NumTel="97659421"},
                new Item { Id = Guid.NewGuid().ToString(), Nom = "Espace Hanin", Description="Espace ouvert",Localisation = "Sidi Ahmed Zarroug",NumTel="95654320"},
                new Item { Id = Guid.NewGuid().ToString(), Nom = "Green Parc", Description="Espace ouvert",Localisation = "Sidi Ahmed Zarroug",NumTel="97654361"},
                new Item { Id = Guid.NewGuid().ToString(), Nom = "ZA", Description="Salon de thé",Localisation = "Sidi Ahmed Zarroug " ,NumTel="93654301"},
                new Item { Id = Guid.NewGuid().ToString(), Nom = "Hssine Bakir", Description="Espace ouvert",Localisation = "Gafsa Centre Ville ",NumTel="95649021"},
                new Item { Id = Guid.NewGuid().ToString(), Nom = "Paradiso", Description="Salon de thé",Localisation = "Sidi Ahmed Zarroug",NumTel="97654991" }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}