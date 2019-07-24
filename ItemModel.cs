namespace GongDragTest
{
    public class ItemModel : Observable
    {
        public ItemModel(string name)
        {
            _Name = name;
        }

        private string _Name;
        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }

        public override string ToString() => Name;
    }
}