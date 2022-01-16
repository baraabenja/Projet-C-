using App2.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string nom;
        private string description;
        private string localisation;
        private string numTel;
        public string Id { get; set; }

        public string Nom
        {
            get => nom;
            set => SetProperty(ref nom, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        public string Localisation
        {
            get => localisation;
            set => SetProperty(ref localisation, value);
        }
        public string NumTel
        {
            get => numTel;
            set => SetProperty(ref numTel, value);
        }
        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Nom = item.Nom;
                Description = item.Description;
                Localisation = item.Localisation;
                NumTel = item.NumTel;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
