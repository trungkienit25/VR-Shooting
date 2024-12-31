using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Rifle : Weapon
{
    [SerializeField] private float fireRate;
    private Projectile projectile;

    private WaitForSeconds wait;

    public GameObject muzzleEffect;
    public AudioClip RifleShot;

    protected override void Awake()
    {
        base.Awake();
        projectile = GetComponentInChildren<Projectile>();
    }

    private void Start()
    {
        wait = new WaitForSeconds(1 / fireRate);
        projectile.Init(this);
    }

    protected override void StartShooting(ActivateEventArgs args)
    {
        base.StartShooting(args);
        muzzleEffect.GetComponent<ParticleSystem>().Play();
        StartCoroutine(ShootingCO());
        SoundManager.instance.shootingSound.PlayOneShot(RifleShot);
    }

    private IEnumerator ShootingCO()
    {
        while (true)
        {
            Shoot();
            yield return wait;
        }
    }

    protected override void Shoot()
    {
        base.Shoot();
        projectile.Launch();
    }

    protected override void StopShooting(DeactivateEventArgs args)
    {
        base.StopShooting(args);
        StopAllCoroutines();
    }
}