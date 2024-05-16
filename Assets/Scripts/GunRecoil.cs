using UnityEngine;

public class GunRecoil : MonoBehaviour
{
    public Transform gunTransform;  
    public float recoilAmount = 1.0f;  
    public float recoilSpeed = 10.0f; 
    public float returnSpeed = 5.0f;  

    private Vector3 originalPosition;  
    private Vector3 recoilPosition;  
    private bool isRecoiling = false;  
    private float recoilTimer = 0.0f; 

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
