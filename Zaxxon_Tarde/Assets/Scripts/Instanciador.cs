using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour
{

    [SerializeField] GameObject obstacle;

    // Start is called before the first frame update
    void Start()
    {
        print(transform.position.z);
        for(int n = 0; n < 10; n++)
        {
            float randomX = Random.Range(20f, 20f);
            Vector3 instPos = new Vector3(randomX, 0f, transform.position.z);
            Instantiate(obstacle,);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
