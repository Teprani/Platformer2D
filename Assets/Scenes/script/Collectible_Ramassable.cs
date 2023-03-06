using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible_Ramassable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("BEH");
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            collision.gameObject.GetComponentInChildren<Health>().pv += 10;
            Destroy(gameObject);
            Debug.Log("BEHHHHHHHHHHHH");
        }
    }
}
