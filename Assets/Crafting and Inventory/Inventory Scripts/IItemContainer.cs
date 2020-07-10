//Interface for adding, removing, and containing items in inventories, chests, etc.
public interface IItemContainer 
{
    bool ContainsItem(Item item);
    bool RemoveItem(Item item);
    bool AddItem(Item item);
    bool IsFull();
}
