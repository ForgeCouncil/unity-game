//Defines "items" as game objects with names, sprites, etc.
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string ItemName;
    public Sprite Icon;
}

