using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
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
        if (Input.GetButtonDown("Fire1") && _equipedWeapon != null && _equipedWeapon.CanShoot() )
        {
            _equipedWeapon.Shoot();
        }
    }

    private void ChangeWeapon(int weaponIndex)
    {


        

        Transform hands;
        if (GetComponent<PlayerController>() != null) 
        {
            Transform camera;
            for (int i = 0; i < transform.childCount - 1; i++)
            {
                if (transform.GetChild(i).GetComponent<CameraController>() != null)
                {
                    camera = transform.GetChild(i);
                }
            }
        }
        else 
        {

        }


        
        GameObject weapon = Instantiate(_weapons[weaponIndex], hands);
        //weapon.transform.Rotate(new Vector3( cameraRotation, 0, 0));
        _equipedWeapon = weapon.GetComponent<Weapon>();
    }
}
