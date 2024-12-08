using System.Collections;
using CarDealer.CarDealer;
using CarDealer.Interfaces.CurrentAccountIntefrace;
using CarDealer.Interfaces.InventoryInterface;

namespace CarDealer.Interfaces
{
    public interface ICarDealer
    {
        void BuyCar(Cars car);
        void SellCar(Cars car);
        void ExchangeCars(ICarDealer dealerA, ICarDealer dealerB, Cars carFromA, Cars carFromB);
        string Name { get; }
        ICurrentAccount CurrentAccount { get; }
        ICarInventory CarInventory { get; }
        IEnumerable<Cars> GetAvailableCars();
        bool PurchaseCarFromDealer(ICarDealer sellingDealer, Cars car);
        void SearchCarAcrossDealers(List<ICarDealer> carDealers, string model);
        bool BuyCarFromAnotherDealer(List<ICarDealer> carDealers);

    }
}