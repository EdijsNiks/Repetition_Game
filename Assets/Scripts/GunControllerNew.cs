using UnityEngine;

public class GunControllerNew : MonoBehaviour
{
    public GunRecoil gunRecoil;  // Reference to the GunRecoil script on the gun

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FireGun();
        }
    }

    void FireGun()
    {
        // Add your shooting logic here (e.g., instantiate bullets, play sound, etc.)

        // Trigger the recoil effect
        if (gunRecoil != null)
        {
            gunRecoil.Shoot();
        }
    }
}