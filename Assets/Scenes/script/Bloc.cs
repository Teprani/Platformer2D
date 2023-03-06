using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloc : MonoBehaviour
{
    [SerializeField] private float lifeTime=5;
    [SerializeField] private GameObject Gun;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DestroyProjectile()
    {
        
        Destroy(gameObject);
        Gun.GetComponent<Prejectil>().NombreBloc = 0;

    }
}
