using System.Collections;
using UnityEngine;

[RequireComponent(typeof(LineRenderer), typeof(Weapon))]
public class RayCastShoot : WeaponShoot
{ 
    public float shotDuration;

    private LineRenderer _laserLine;
    private WaitForSeconds _shotDuration;

    private RaycastHit hit;

    void Start()
    {
        _shotDuration = new WaitForSeconds(shotDuration);
        _laserLine = GetComponent<LineRenderer>();
    }

    public override void Shoot()
    {
        StartCoroutine(ShotEffect());
        Vector3 rayOrigin = transform.position;
        //_laserLine.SetPosition(0, gunEnd.position);
        _laserLine.SetPosition(0, transform.position);
        if (Physics.Raycast(rayOrigin, transform.forward, out hit, 500))
        {
            _laserLine.SetPosition(1, hit.point);
        }
        else
        {
            _laserLine.SetPosition(1, transform.forward * 500);
        }

    }

    private IEnumerator ShotEffect()
    {
        _laserLine.enabled = true;
        yield return _shotDuration;
        _laserLine.enabled = false;
    }
}
