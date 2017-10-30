using System.Collections.Generic;
using UnityEngine;

/*
 * WeaponManager
 * A weapons manager that can store multiple weapons and switch between them.
 */

public class WeaponManager : MonoBehaviour
{
    public GameObject originalWeapon;

    private Weapon _equipedWeapon;
    private List<GameObject> _weapons; 

    private void Start()
    {
        _weapons = new List<GameObject>();
        if (originalWeapon != null)
        {
            _weapons.Add(originalWeapon);
            ChangeWeapon(0);
        }
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && _equipedWeapon != null && _equipedWeapon.CanShoot() )
        {
            _equipedWeapon.Shoot();
        }
        else if (Input.GetButtonUp("Fire1") && _equipedWeapon.GetAttackType() == Weapon.AttackType.shootOnce)
        {
            _equipedWeapon.TriggerReleased();
        } 
    }

    // Switch between two weapons
    private void ChangeWeapon(int weaponIndex)
    {
        // TODO Remove the current weapon

        GameObject weapon = Instantiate(_weapons[weaponIndex], transform);
        _equipedWeapon = weapon.GetComponent<Weapon>();

    }
}
