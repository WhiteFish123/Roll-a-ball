using UnityEngine;

public class RoteController : MonoBehaviour
{
    public float rotateSpeed = 100f;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.RotateAround(transform.position,Vector3.up,rotateSpeed * Time.deltaTime);
    }
}
