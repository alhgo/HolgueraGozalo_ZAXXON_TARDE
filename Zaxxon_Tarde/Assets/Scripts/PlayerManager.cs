using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    Vector3 navePos = Vector3.zero;
    Vector3 despl = new Vector3(0f, 1f, 0f);

    //Velocidad de desplazamientio
    [SerializeField] float desplSpeed;


    // Start is called before the first frame update
    void Start()
    {
        desplSpeed = 1f;

        transform.position = navePos;
    }

    private void FixedUpdate()
    {
        navePos += despl;
        transform.position = navePos * desplSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {

        

    }
}
