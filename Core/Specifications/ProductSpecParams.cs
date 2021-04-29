namespace Core.Specifications
{
    public class ProductSpecParams
    {
        //maximum of 50 objects to appear
        private const int MaxPageSize = 50;

        //by default we will always return the first page
        public int PageIndex {get; set;} = 1; 

        private int _pageSize = 6;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public int? BrandId {get; set;}
        public int? TypeId {get; set;}
        public string Sort {get; set;}
        private string _search;
        public string Search 
        {
            get => _search;
            set => _search = value.ToLower();
        }
    }
}