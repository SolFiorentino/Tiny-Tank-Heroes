using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour
{

    Transform _Tank;
    float dist;
    public float howClose;
    public Transform head, barrel;
    public GameObject _projectile;
    public float fireRate, nextFire;


    // Start is called before the first frame update
    void Start()
    {

        _Tank = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        
        dist = Vector3.Distance(_Tank.position, transform.position);

        if(dist <= howClose)
        {

            head.LookAt(_Tank);


            if(Time.time >= nextFire)
            {

               nextFire = Time.time + 1f/fireRate;
               shoot();
            }
            
        }


    }

    void shoot()
    {

       GameObject clone =  Instantiate(_projectile, barrel.position, head.rotation);

        clone.GetComponent<Rigidbody>().AddForce(head.forward * 1500);
        
        Destroy(clone, 10);
    }


}
