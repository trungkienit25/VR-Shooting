using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Pistol : Weapon
{
    [SerializeField] private Projectile bulletPrefab;


    public GameObject muzzleEffect;
    public AudioClip PistolShot;

    protected override void StartShooting(ActivateEventArgs args)
    {
        //base.StartShooting(args);
        muzzleEffect.GetComponent<ParticleSystem>().Play();
        Shoot();
        SoundManager.instance.shootingSound.PlayOneShot(PistolShot);
    }

    protected override void Shoot()
    {   
        base.Shoot();
        Projectile projectileInstance = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        projectileInstance.Init(this);
        projectileInstance.Launch();
    }

    protected override void StopShooting(DeactivateEventArgs args)
    {
        base.StopShooting(args);
    }
}