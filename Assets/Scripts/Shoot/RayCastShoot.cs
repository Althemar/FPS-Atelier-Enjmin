using UnityEngine;

[RequireComponent(typeof(LineRenderer), typeof(Weapon))]
public class RayCastShoot : WeaponShoot
{ 
    private LineRenderer _laserLine;
    private WaitForSeconds _shotDuration;

    void Start()
    {
        _shotDuration = new WaitForSeconds(0.5f);
        _laserLine = GetComponent<LineRenderer>();
    }

    public override void Shoot()
    {
    }
}
