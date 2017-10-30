using UnityEngine;

/*
 * Weapon
 */

public class Weapon : MonoBehaviour
{
    
    public int damage;
    public float fireRate;
    public Transform gunEnd;
    

    private float _nextFire;
    private float _timerShoot;
    private WeaponShoot _shootingType;

    void Start()
    {
        _timerShoot = 0;
        WeaponShoot shootingType = GetComponent<WeaponShoot>();
        if (shootingType != null)
        {
            _shootingType = shootingType;
        }
    }
    
    void Update()
    {
        if (_timerShoot < 1.0f / fireRate)
        {
            _timerShoot += Time.deltaTime;
        }
    }

    public bool CanShoot()
    {
        return _timerShoot > 1.0f / fireRate;
    }

    public void Shoot()
    {
        _timerShoot = 0;
        _shootingType.Shoot();
    }

    public Transform getGunEnd()
    {
        return gunEnd;
    }
}
