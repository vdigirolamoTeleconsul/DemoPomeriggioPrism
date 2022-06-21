using DemoPomeriggioPrism.Models;
using DemoPomeriggioPrism.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DemoPomeriggioPrism.ViewModels
{
    public class SecondPageViewModel : BindableBase, INavigationAware
    {
        private string titolo;
        private readonly IMonkeysService service;

        public string Titolo
        {
            get { return titolo; }
            set { SetProperty(ref titolo, value); }
        }

        private ObservableCollection<Monkey> monkeys;
        public ObservableCollection<Monkey> Monkeys 
        {
            get { return monkeys; }
            set { SetProperty(ref monkeys, value); }
        }


        private int count;
        public int Count
        {
            get { return count; }
            set { SetProperty(ref count, value); }
        }

        public SecondPageViewModel(IMonkeysService service)
        {
            Titolo = "Seconda pagina";
            this.service = service;
            Monkeys = new ObservableCollection<Monkey>();
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
           
        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("parametro1"))
            {
                Titolo = (string) parameters["parametro1"];
                var scimmie = await service.GetMonkeys();
                Monkeys.Clear();
                foreach (var scimmia in scimmie)
                {
                    Monkeys.Add(scimmia);
                }
                Count = Monkeys.Count;
            }
        }
    }
}
