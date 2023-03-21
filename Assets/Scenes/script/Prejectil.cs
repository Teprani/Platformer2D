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

    public float TimeBetweenSpawns= 1f;  
    public float timeSinceSpawn = 0f;
    private int nextSpawn = 0;
    private bool doneSpawning = false;
    private float coolDown = 5; 


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

         if (doneSpawning == false)
        {
            timeSinceSpawn += Time.deltaTime;
            if (timeSinceSpawn >= TimeBetweenSpawns)
            {
                //nextSpawn++;
                timeSinceSpawn = 0f;
                //if (nextSpawn >= 2)
                //{
                    doneSpawning = true;
                //}
            }
        }
    }

    
    void Shoot()
    {
        
        Instantiate(balle,SpawnPoint.position,SpawnPoint.rotation);
        
    }
    void SpawnBloc()
    {
        if (NombreBloc < 2 && doneSpawning)
        {
            Instantiate(bloc, SpawnPointBloc.position, SpawnPointBloc.rotation);
            NombreBloc++;
            doneSpawning = false;
            Invoke ("nbrBloc",coolDown);
        }

        //if (NombreBloc > 0)
        //{
        //    Destroy(bloc);
        //    Instantiate(bloc, SpawnPointBloc.position, SpawnPointBloc.rotation);
        //    NombreBloc--;
        //}


    }
    void nbrBloc ()
    {
        NombreBloc--;

    }

}
