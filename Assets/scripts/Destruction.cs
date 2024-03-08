using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Debug.Log("COiiiin");
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Box"))
        {
            Debug.Log("BOOOOOX");
            // Détruire la boîte après 1 seconde
            StartCoroutine(DestroyBox(collision.gameObject));
        }
    }

    IEnumerator DestroyBox(GameObject box)
    {
        // Attendre 1 seconde
        yield return new WaitForSeconds(1f);
        // Détruire la boîte après le délai
        Destroy(box);
    }
}
