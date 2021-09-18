using UnityEngine;

[CreateAssetMenu(menuName = "Hermit/Weapon")]
public class WeaponSO : ScriptableObject {

    [HideInInspector] public enum WeaponType {
        Axe,
        Hammer,
        Pickaxe
    }

    public WeaponType weaponType;
    public string weaponName;
    public float weaponRange;

    [Tooltip("Attacks per second")]
    public float weaponSpeed;
    public Vector2Int weaponDamageRange;
    public int currentDurability;
    public int maxDurability;
}