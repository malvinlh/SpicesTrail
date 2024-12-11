using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    public GameObject macheteSprite, pistolSprite;
    public GameObject macheteHitbox, pistolHitbox;
    private PlayerAimWeapon aimWeapon;

    private void Awake()
    {
        aimWeapon = GetComponent<PlayerAimWeapon>();
    }

    public void SwitchWeapon(string weaponName)
    {
        macheteSprite.SetActive(weaponName == "Machete");
        pistolSprite.SetActive(weaponName == "FlintlockPistol");

        macheteHitbox.SetActive(weaponName == "Machete");
        pistolHitbox.SetActive(weaponName == "FlintlockPistol");

        switch (weaponName)
        {
            case "Machete":
                aimWeapon.EquipMachete();
                break;
            case "FlintlockPistol":
                aimWeapon.EquipPistol();
                break;
            default:
                break;
        }
    }
}