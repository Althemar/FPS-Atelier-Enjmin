using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponOnFloor : Interactable {

    public GameObject weapon;

    public override void Interact(GameObject who)
    {
        WeaponManager weaponManager = who.GetComponent<WeaponManager>();
        if (weaponManager != null)
        {
            weaponManager.AddNewWeapon(weapon);
        }


    }

}
