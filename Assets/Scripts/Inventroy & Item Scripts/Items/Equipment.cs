using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//https://www.youtube.com/watch?v=d9oLS5hy0zU&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7&index=8

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot;
    public SkinnedMeshRenderer mesh;
    public EquipmentMeshRegion[] coveredMeshRegions;
    
    public int armorModifier;
    public int damageModifier;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
    }
}

public enum EquipmentSlot {Head, Chest, Legs, Weapon, Shield, Feet}
public enum EquipmentMeshRegion {Legs, Arms, Torso};