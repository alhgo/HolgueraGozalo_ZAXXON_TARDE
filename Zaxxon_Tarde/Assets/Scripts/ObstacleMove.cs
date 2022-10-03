using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    float speed;

    [SerializeField] PlayerManager playerManager;
    GameObject nave;

    // Start is called before the first frame update
    void Start()
    {
        nave = GameObject.Find("NavePrefab");
        playerManager = nave.GetComponent<PlayerManager>();

        
    }

    // Update is called once per frame
    void Update()
    {
        speed = playerManager.speed;
        transform.Translate(Vector3.back * Time.deltaTime * speed);

        Destruir();
        

    }

    void Destruir()
    {
        if (transform.position.z < -10f)
        {
            Destroy(gameObject);
        }
    }
}
