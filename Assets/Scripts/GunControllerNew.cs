using UnityEngine;

public class GunControllerNew : MonoBehaviour
{
    public GunRecoil gunRecoil;  

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FireGun();
        }
    }

    void FireGun()
    {
        if (gunRecoil != null)
        {
            gunRecoil.Shoot();
        }
    }
}