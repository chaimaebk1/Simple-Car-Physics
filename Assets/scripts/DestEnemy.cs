using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision collision)
{
    // Check if the collision is with a Player or Enemy tagged object
    if (collision.gameObject.CompareTag("Coin"))
    {
        // Destroy the collided object
        Debug.Log("COiiiin "  );
        Destroy(collision.gameObject);
    }
    else if( collision.gameObject.CompareTag("Box"))
    {
                Debug.Log("BOOOOOX "  );
         Destroy(collision.gameObject);
    }
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
