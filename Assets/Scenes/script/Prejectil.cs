using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prejectil : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField]private Transform SpawnPoint;
    [SerializeField] private Transform SpawnPointBloc;
    [SerializeField] private GameObject balle;
    [SerializeField] private GameObject bloc;
    [SerializeField] private float offset;
    public int NombreBloc = 0;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnBloc();
        }
    }
    void Shoot()
    {
        
        Instantiate(balle,SpawnPoint.position,SpawnPoint.rotation);
        
    }
    void SpawnBloc()
    {
        if (NombreBloc == 0)
        {
            Instantiate(bloc, SpawnPointBloc.position, SpawnPointBloc.rotation);
            NombreBloc++;
        }
        //if (NombreBloc > 0)
        //{
        //    Destroy(bloc);
        //    Instantiate(bloc, SpawnPointBloc.position, SpawnPointBloc.rotation);
        //    NombreBloc--;
        //}


    }


}
