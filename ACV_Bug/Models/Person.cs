namespace ACV_Bug.Models
{
    public class Person : Observable
    {
        private bool _isAdult;

        public string Name { get; set; }
        public bool IsAdult { get => _isAdult; set => Set(ref _isAdult , value); }
    }
}
