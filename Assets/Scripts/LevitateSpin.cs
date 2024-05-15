using UnityEngine;

public class LevitateSpin : MonoBehaviour
{
    [SerializeField] private float levitationHeight = 1.0f; // Height at which the object will levitate
    [SerializeField] private float spinSpeed = 360.0f; // Speed at which the object will spin (degrees per second)
    [SerializeField] private float interpolationSpeed = 5.0f; // Speed of the lerp interpolation

    private Vector3 targetPosition;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + Vector3.up * levitationHeight;
    }

    void Update()
    {
        // Rotate the object around its Y axis
        transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime);

        // Lerp the object's position between startPosition and targetPosition
        transform.position = Vector3.Lerp(transform.position, targetPosition, interpolationSpeed * Time.deltaTime);
    }
}