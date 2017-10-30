using System.Collections;
using UnityEngine;

/*
 * RayCastShoot
 * A shoot type that use a raycast
 */


[RequireComponent(typeof(LineRenderer), typeof(Weapon))]
public class RayCastShoot : WeaponShoot
{ 
    public float shotDuration;  // The duration of the laser
    public float range;         // The range of the raycast

    private LineRenderer _laserLine;        // The laser spawned from the gun end
    private WaitForSeconds _shotDuration;   
    private RaycastHit _hit;                // The object hit by the raycast
    private Weapon _weapon;
    private Camera _fpsCam;                 // Used if the shooter is the player

    void Start()
    {
        _shotDuration = new WaitForSeconds(shotDuration);
        _laserLine = GetComponent<LineRenderer>();
        _weapon = GetComponent<Weapon>();

        _fpsCam = transform.parent.GetComponentInParent<Camera>();
    }

    public override void Shoot()
    {
        StartCoroutine(ShotEffect());

        Vector3 rayOrigin = getRaycastOrigin();
        
        _laserLine.SetPosition(0, _weapon.GetGunEnd().position);
        if (Physics.Raycast(rayOrigin, transform.forward, out _hit, range))
        {
            _laserLine.SetPosition(1, _hit.point);
        }
        else
        {
            _laserLine.SetPosition(1, rayOrigin + (_fpsCam.transform.forward * range));
        }
    }


    private Vector3 getRaycastOrigin()
    {
        Vector3 rayOrigin = transform.position;
        if (_fpsCam != null)
        {
            rayOrigin = _fpsCam.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));
        }
        return rayOrigin;
    }

    private IEnumerator ShotEffect()
    {
        _laserLine.enabled = true;
        yield return _shotDuration;
        _laserLine.enabled = false;
    }
}
