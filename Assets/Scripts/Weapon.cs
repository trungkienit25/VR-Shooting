using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(XRGrabInteractable))]
public class Weapon : MonoBehaviour
{
    [SerializeField] protected float shootingForce;
    [SerializeField] protected Transform bulletSpawn;
    [SerializeField] private float recoilForce;
    [SerializeField] public float damage;

    private Rigidbody rigidBody;
    private XRGrabInteractable interactableWeapon;

    protected virtual void Awake()
    {
        interactableWeapon = GetComponent<XRGrabInteractable>();
        rigidBody = GetComponent<Rigidbody>();
        SetupInteractableWeaponEvents();
    }

    private void SetupInteractableWeaponEvents()
    {
        // Updated events with the new API names and signatures
        interactableWeapon.selectEntered.AddListener(PickUpWeapon);
        interactableWeapon.selectExited.AddListener(DropWeapon);
        interactableWeapon.activated.AddListener(StartShooting);
        interactableWeapon.deactivated.AddListener(StopShooting);
    }

    private void PickUpWeapon(SelectEnterEventArgs args)
    {
        // Use the interactorObject for accessing the interactor's properties
        args.interactorObject.transform.GetComponent<MeshHidder>()?.Hide();
    }

    private void DropWeapon(SelectExitEventArgs args)
    {
        args.interactorObject.transform.GetComponent<MeshHidder>()?.Show();
    }

    protected virtual void StartShooting(ActivateEventArgs args)
    {
        Debug.Log("Weapon StartShooting() called.");
    }

    protected virtual void StopShooting(DeactivateEventArgs args)
    {
        Debug.Log("Weapon StopShooting() called.");
    }

    protected virtual void Shoot()
    {
        ApplyRecoil();
    }

    private void ApplyRecoil()
    {
        rigidBody.AddRelativeForce(Vector3.back * recoilForce, ForceMode.Impulse);
    }

    public float GetShootingForce()
    {
        return shootingForce;
    }

    public float GetDamage()
    {
        return damage;
    }
}