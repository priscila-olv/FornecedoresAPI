namespace FornecedoresAPI.Pagination
{
    public class FornecedoresParameters
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        public int _pageSize = 5;
        public int PageSize
        {
            get 
            { 
                return _pageSize; 
            }
            set 
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value; 
            }
        }
    }
}
