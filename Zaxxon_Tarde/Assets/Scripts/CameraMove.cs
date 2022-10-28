using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    [SerializeField] Transform nave;

    [SerializeField] float offsetZ;
    [SerializeField] float offsetY;

    //Suavizado
    [SerializeField] public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        offsetY = 6.5f;
        offsetZ = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(nave);
        Vector3 targetPosition  = nave.position - new Vector3(0f, -offsetY, offsetZ);
        //transform.position = targetPosition ;

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

    }
}
