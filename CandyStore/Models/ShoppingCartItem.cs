namespace CandyStore.Models;

public class ShoppingCartItem
{
    public int ShoppingCartItemID { get; set; }
    public string ShoppingCartID { get; set; } = default!;
    public int CandyID { get; set; }
    public Candy Candy { get; set; } = default!;
    public int Amount { get; set; }
}