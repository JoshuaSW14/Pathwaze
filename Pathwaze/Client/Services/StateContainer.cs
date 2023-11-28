namespace Pathwaze.Client.Services;

public class StateContainer
{
    public Guid GroceryStoreId { get; private set; }

    public event Action OnChange;

    public void SetGroceryStoreId(Guid groceryStoreId)
    {
        GroceryStoreId = groceryStoreId;
        NotifyStateChanged();
    }

    public void SetGroceryIdFromClaims(IEnumerable<Claim> claims)
    {
        var groceryIdClaim = claims.FirstOrDefault(c => c.Type == "groceryStoreId"); // use the actual claim type
        if (groceryIdClaim != null && Guid.TryParse(groceryIdClaim.Value, out Guid gsId))
            SetGroceryStoreId(gsId);
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
