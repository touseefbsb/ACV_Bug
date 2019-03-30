using ACV_Bug.Models;
using Microsoft.Toolkit.Uwp.UI;
using System.Collections.ObjectModel;

namespace ACV_Bug.ViewModels
{
    public class MainViewModel : Observable
    {
        private AdvancedCollectionView _selectedPeopleList;

        public ObservableCollection<Person> PeoplePrivate { get; private set; }
        public AdvancedCollectionView People { get; private set; }
        public AdvancedCollectionView Kids { get; private set; }
        public AdvancedCollectionView All { get; private set; }
        public AdvancedCollectionView SelectedPeopleList { get => _selectedPeopleList; set => Set(ref _selectedPeopleList, value); }

        public MainViewModel()
        {
            PeoplePrivate = new ObservableCollection<Person>();

            All = new AdvancedCollectionView(PeoplePrivate, true);

            People = new AdvancedCollectionView(PeoplePrivate, true)
            {
                Filter = x => ((Person)x).IsAdult == true
            };
            People.ObserveFilterProperty(nameof(Person.IsAdult));
            Kids = new AdvancedCollectionView(PeoplePrivate, true)
            {
                Filter = x => ((Person)x).IsAdult == false
            };
            Kids.ObserveFilterProperty(nameof(Person.IsAdult));
        }

        public void FillPeople()
        {
            for (int i = 0; i < 10; i++)
            {
                PeoplePrivate.Add(new Person { Name = $"Person{i}" });
            }
            for (int i = 0; i < 5; i++)
            {
                PeoplePrivate[i].IsAdult = true;
            }
        }
    }
}
