
namespace HW7;

public interface IBoxService
{
    void CreateOrLoadCurrentBox();
    void AddProductToBox(int productId, int quantity);
    void FinalizePurchase();
    void ShowPreviousPurchases();
}
