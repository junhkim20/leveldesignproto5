using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; 

    public float smoothSpeed = 0.125f; 
    public Vector3 offset; 
    [SerializeField] private Space offsetPositionSpace = Space.Self;
    [SerializeField] private bool lookAt = true;
    // public Vector3 minValue, maxValue; 

    void FixedUpdate(){
        // Vector3 desiredPosition = target.position + offset; 
        // Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // transform.position = smoothPosition; 

        // compute position
        if(offsetPositionSpace == Space.Self)
        {
            transform.position = target.TransformPoint(-offset);
        }
        else
        {
            transform.position = target.position + offset;
        }

        // compute rotation
        if(lookAt)
        {
            transform.LookAt(target);
        }
        else
        {
            transform.rotation = target.rotation;
        }
    }
}
