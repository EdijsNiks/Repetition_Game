using UnityEngine;

public class EnterCar : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;

    [SerializeField] private KeyCode openDoorKey = KeyCode.E;

    private const string interactableTag = "Car";

    [SerializeField] private GameObject player;

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
          
            if (hit.collider.CompareTag(interactableTag))
            {
                if (Input.GetKeyDown(openDoorKey))
                {
                    player.transform.position = new Vector3(411f,1.52f, 144f);;
                }
            }

    }
}
}
