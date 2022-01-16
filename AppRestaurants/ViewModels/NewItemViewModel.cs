using App2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App2.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string nom;
        private string description;
        private string localisation;
        private string numTel;
        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(nom)
                && !String.IsNullOrWhiteSpace(description);
        }

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
            set => SetProperty(ref localisation, value);
        }
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Nom = Nom,
                Description = Description,
                Localisation = Localisation,
                NumTel = NumTel
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
