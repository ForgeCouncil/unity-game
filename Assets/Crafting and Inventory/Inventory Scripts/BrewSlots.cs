//Script that defines slots in the crafting menu for items that will be brewed together.
public class BrewSlots : ItemSlot
{
   public ItemType ItemType;

    //Might need to change "private" to "protected override", then "virtual override" in the ItemSlot script.
    //https://youtu.be/4JewzU_phTM?t=190
   private void OnValidate()
   {
       // base.OnValidate();
       gameObject.name = ItemType.ToString() + " Slot";
   }
}
