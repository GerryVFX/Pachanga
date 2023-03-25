using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShotGun : Gun
{
    [SerializeField] Transform shotAim;
    public override void Use()
    {
        Shoot();
    }

    void Shoot()
    {
        RaycastHit hit;

        if(Physics.Raycast(shotAim.position, shotAim.forward, out hit))
        {
            print(hit.collider.gameObject.name);
            hit.collider.gameObject.GetComponent<IDamage>()?.TakeDamage(((GunInfo)itemInfo).damage);
        }
    }
}
