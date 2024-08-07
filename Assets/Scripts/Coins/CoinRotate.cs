using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    public float rotationSpeed = 90.0f; // Velocidad de rotación en grados por segundo

    // Update is called once per frame
    void Update()
    {
        // Rotar alrededor del eje Z
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime, Space.Self);
    }
}



