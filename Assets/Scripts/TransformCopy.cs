using UnityEngine;

public class TransformCopy : MonoBehaviour
{
    [SerializeField] private Transform donor;
    [SerializeField] private Vector3 offsetRotation;
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private bool trackPosition;
    [SerializeField] private bool trackRotation;

    private void Update()
    {
        if (!donor) return;
        
        if (trackPosition)
        {
            var position = donor.position;
            Vector3 newPosition = new Vector3(position.x + positionOffset.x, position.y + positionOffset.y, position.z + positionOffset.z);
            transform.position = newPosition;
        }
        
        if (trackRotation){
            var rotation = donor.rotation;
            Vector3 newRotation = new Vector3(rotation.eulerAngles.z + offsetRotation.x,
                rotation.eulerAngles.y + offsetRotation.y, -rotation.eulerAngles.x + offsetRotation.z);
            transform.rotation = Quaternion.Euler(newRotation);
        }
    }
}
