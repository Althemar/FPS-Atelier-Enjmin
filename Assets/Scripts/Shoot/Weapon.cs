using UnityEngine;

/*
 * Weapon
 */

public class Weapon : MonoBehaviour
{

    public enum AttackType
    {
        shootOnce,
        automatic
    }

    public AttackType attackType;
    public float fireRate;              // Number of shots per second
    public Transform gunEnd;            // The end of the gun, used to spawn projectile or raycast
    
    
    private float _timerShoot;          
    private WeaponShoot _shootingType;
    private bool _triggerReleased;      

    void Start()
    {
        _timerShoot = 0;
        _triggerReleased = true;
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
        return ( _timerShoot > 1.0f / fireRate ) && _triggerReleased ;
    }

    public void Shoot()
    {
        _timerShoot = 0;
        _shootingType.Shoot();
        if (attackType == AttackType.shootOnce)
        {
            _triggerReleased = false;
        }
    }

    public Transform GetGunEnd()
    {
        return gunEnd;
    }

    public AttackType GetAttackType()
    {
        return attackType;
    }

    public void TriggerReleased()
    {
        _triggerReleased = true;
    }
}
