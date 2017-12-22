using System.Collections.Generic;
using UnityEngine;

/*
 * WeaponManager
 * A weapons manager that can store multiple weapons and switch between them.
 */

public class WeaponManager : MonoBehaviour
{
    public GameObject originalWeapon;
    public int numberOfWeapons;

    private Weapon _equipedWeapon;
    private List<GameObject> _weapons;
    private Transform _weaponPosition;

    private void Start()
    {
        _weapons = new List<GameObject>();
        if (originalWeapon != null)
        {
            _weapons.Add(originalWeapon);
            ChangeWeapon(0);
        }

      
        if (GetComponent<PlayerController>() != null)
        {
            Transform camera = FindHierarchy.FindChildWithComponent<Camera>(transform);

            if (camera != null)
            {
                _weaponPosition = FindHierarchy.FindChildWithTag(camera, "WeaponPosition");
            }
        }
        else
        {
            _weaponPosition = FindHierarchy.FindChildWithTag(transform, "WeaponPosition");
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

    public void AddNewWeapon(GameObject weapon)
    {
        if (_weapons.Count < numberOfWeapons)
        {
            _weapons.Add(weapon);
        }
    }

    // Switch between two weapons
    public void ChangeWeapon(int weaponIndex)
    {
        for (int i = 0; i < _weaponPosition.childCount; i++)
        {
            Destroy(_weaponPosition.GetChild(i));
        }

        GameObject weapon;
        if (_weaponPosition != null)
            weapon = Instantiate(_weapons[weaponIndex], _weaponPosition);
        else
        {
            weapon = Instantiate(_weapons[weaponIndex], transform);
        }
        _equipedWeapon = weapon.GetComponent<Weapon>();

    }
}
