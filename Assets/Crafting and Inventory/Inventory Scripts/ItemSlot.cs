//Defines Items Slots with place holder sprites.
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] Image Image;
    private Item _item;
    public Item Item  
    {
        get { return _item; }
        set {
            _item = value;

            if (_item == null)
            {
                Image.enabled = false;
            }
            else
            {
                Image.sprite = _item.Icon;
                Image.enabled = true;
            }
        }
    }

    //Might need to change "private" to "protected override", then "virtual override" in the ItemSlot script.
    //https://youtu.be/4JewzU_phTM?t=190
    private void OnValidate()
    {
        if (Image == null)
            Image = GetComponent<Image>();
    }
}
