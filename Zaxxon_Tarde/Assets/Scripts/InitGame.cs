using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGame : MonoBehaviour
{

    [SerializeField] GameObject navePrefab;

    [SerializeField] Transform navePos;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(navePrefab, navePos.position, navePos.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
