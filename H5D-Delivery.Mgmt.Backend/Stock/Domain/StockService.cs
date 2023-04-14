namespace H5D_Delivery.Mgmt.Backend.Stock.Domain
{
    public class StockService
    {
        private readonly IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public IEnumerable<StockItem>? GetAll()
        {
            return _stockRepository.GetAll();
        }

        public StockItem? Get(Guid id)
        {
            return _stockRepository.Get(id);
        }

        public void Update(StockItem stockItem)
        {
            _stockRepository.Update(stockItem);
        }

        public void Delete(Guid id)
        {
            _stockRepository.Delete(id);
        }

        public void Create(StockItem stockItem)
        {
            _stockRepository.Create(stockItem);
        }
    }
}
