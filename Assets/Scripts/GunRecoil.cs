using UnityEngine;

public class GunRecoil : MonoBehaviour
{
    public Transform gunTransform;  // The transform of the gun object
    public float recoilAmount = 1.0f;  // The amount of recoil
    public float recoilSpeed = 10.0f;  // The speed of the recoil effect
    public float returnSpeed = 5.0f;  // The speed at which the gun returns to its original position

    private Vector3 originalPosition;  // The original position of the gun
    private Vector3 recoilPosition;  // The target position during recoil
    private bool isRecoiling = false;  // Whether the gun is currently recoiling
    private float recoilTimer = 0.0f;  // Timer to manage the recoil effect

    void Start()
    {
        if (gunTransform == null)
        {
            gunTransform = transform;
        }
        originalPosition = gunTransform.localPosition;
    }

    void Update()
    {
        if (isRecoiling)
        {
            recoilTimer += Time.deltaTime * recoilSpeed;
            gunTransform.localPosition = Vector3.Lerp(gunTransform.localPosition, recoilPosition, Time.deltaTime * recoilSpeed);

            if (recoilTimer >= 1.0f)
            {
                isRecoiling = false;
                recoilTimer = 0.0f;
            }
        }
        else
        {
            gunTransform.localPosition = Vector3.Lerp(gunTransform.localPosition, originalPosition, Time.deltaTime * returnSpeed);
        }
    }

    public void Shoot()
    {
        if (!isRecoiling)
        {
            recoilPosition = originalPosition + Vector3.up * recoilAmount;
            isRecoiling = true;
            recoilTimer = 0.0f;
        }
    }
}
