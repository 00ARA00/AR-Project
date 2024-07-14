namespace InventorySystem
{
    public enum ItemsCategories
    {
        Currancy = 0,
        PlayerEquipment = 1,
        CarEquipment = 2,
        Chest = 3
    }

    public enum ItemRanks
    {
        Normal = 0,
        Rare = 1,
        Epic = 2,
        Legendary = 3
    }

    public enum PlayerEquipmentCategories
    {
        Weapon = 0,
        Stick = 1,
        Hat = 2,
        Mask = 3,
        Pendant = 4,
        Cloth = 5,
        Shoes = 6
    }

    public enum CarEquipmentCategories
    {
        Bumper = 0,
        SideKit = 1,
        BackKit = 2,
        Weapon = 3,
        Back = 4 
    }

    public enum PlayerStatBonusesType
    {
        WeaponDamage = 0,
        Health = 1,
        Armor = 2,
        MovementSpeed = 3,
        ReloadSpeed = 4,
        AttackSpeed = 5,
        ThrowStrength = 6,
        ThrowKillRadius = 7
    }
}