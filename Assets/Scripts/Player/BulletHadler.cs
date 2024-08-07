using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHadler : MonoBehaviour
{

    public float launchSpeed = 75.0f;
    public GameObject objectPrefab;
    public AudioSource shootSound;


    // Start is called before the first frame update
    void Start()
    {

        if (shootSound == null)
        {
            Debug.LogError("AudioSourse no asignado");
        }


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            SpawnObject();
        }

        void SpawnObject()
        {

            Vector3 spawnPosition = transform.position;
            Quaternion spawnRotation = Quaternion.identity;

            Vector3 localXDirection = transform.TransformDirection(Vector3.forward);
            Vector3 velocity = localXDirection * launchSpeed;

            //Instantiate Object
            GameObject newObject = Instantiate(objectPrefab, spawnPosition, spawnRotation);

            Rigidbody rb = newObject.GetComponent<Rigidbody>();
            rb.velocity = velocity;

            //Reproducir Sonido
            if (shootSound != null)
            {
                shootSound.Play();
            }


        }


    }
}






