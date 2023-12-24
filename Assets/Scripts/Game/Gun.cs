using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera fpscam;
    public ParticleSystem shootEffect;
    public AudioSource shootSound;

    public void Shoot()
    {
        shootEffect.Play();
        shootSound.Play();

        RaycastHit hit;
        if(Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            NormalTarget normalTarget = hit.transform.GetComponent<NormalTarget>();
            BossTarget bossTarget = hit.transform.GetComponent<BossTarget>();
            if (normalTarget!=null)
            {
                normalTarget.TakeDamage(damage);
            }
            if (bossTarget != null)
            {
                bossTarget.TakeDamage(damage);
            }
        }
    }
}
