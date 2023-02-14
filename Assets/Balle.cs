using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balle : MonoBehaviour
{
    [SerializeField] private int BulletSpeed = 10 ;
    [SerializeField] private int Dommage = 10;
    public Rigidbody2D rb;
    [SerializeField] private float lifeTime;
    [SerializeField] private GameObject balle;

    // Start is called before the first frame update
    void Start()
    {

        rb.gravityScale = 0;
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
        rb.velocity =transform.right * BulletSpeed; 
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ennemy"))
        {
            collision.gameObject.GetComponent<Ennemy>().pv -= Dommage;
            DestroyProjectile();
            Debug.Log("beh");
        }
        
    }
}
