using UnityEngine;

public class TransformCopy : MonoBehaviour
{
    [SerializeField] private Transform donor;
    [SerializeField] private Vector3 offsetRotation;
    void Update()
    {
        if (donor != null)
        {
            transform.position = donor.position;
            var rotation = donor.rotation;
            
            Vector3 newRotation = new Vector3(rotation.eulerAngles.z + offsetRotation.x,
                rotation.eulerAngles.y + offsetRotation.y, -rotation.eulerAngles.x + offsetRotation.z);
            transform.rotation = Quaternion.Euler(newRotation);
        }
    }
}
