using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolTankController : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed = 5f;
    public float rotationSpeed = 2f;
    public float stoppingDistance = 1f; // Distancia a la que el tanque se detiene en un punto de patrulla
    public float detectionRange = 20f; // Rango de detección del jugador

    public GameObject[] leftWheels;
    public GameObject[] rightWheels;
    public float wheelRotationSpeed = 200f;

    public Transform player;
    public Transform projectileSpawnPoint; // Punto de spawn para los proyectiles
    public GameObject projectilePrefab; // Prefab del proyectil
    public float projectileSpeed = 20f; // Velocidad del proyectil
    public float fireRate = 1f; // Frecuencia de disparo
    private float nextFireTime;

    private int currentPatrolIndex;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentPatrolIndex = 0;
        nextFireTime = Time.time;
    }

    void FixedUpdate()
    {
        if (PlayerInRange())
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
        RotateWheels();
    }

    void Update()
    {
        if (PlayerInRange() && Time.time > nextFireTime)
        {
            ShootProjectile();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    bool PlayerInRange()
    {
        if (player == null) return false;
        return Vector3.Distance(transform.position, player.position) <= detectionRange;
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        // Obtener el punto de patrulla actual
        Transform targetPoint = patrolPoints[currentPatrolIndex];

        // Dirección hacia el punto de patrulla
        Vector3 direction = (targetPoint.position - transform.position).normalized;

        // Rotar hacia el punto de patrulla
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

        // Moverse hacia el punto de patrulla si está fuera del rango de parada
        if (Vector3.Distance(transform.position, targetPoint.position) > stoppingDistance)
        {
            Vector3 moveDirection = transform.forward * moveSpeed * Time.deltaTime;
            rb.MovePosition(rb.position + moveDirection);
        }
        else
        {
            // Avanzar al siguiente punto de patrulla
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
    }

    void ChasePlayer()
    {
        if (player == null) return;

        // Dirección hacia el jugador
        Vector3 direction = (player.position - transform.position).normalized;

        // Rotar hacia el jugador
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

        // Moverse hacia el jugador si está fuera del rango de parada
        if (Vector3.Distance(transform.position, player.position) > stoppingDistance)
        {
            Vector3 moveDirection = transform.forward * moveSpeed * Time.deltaTime;
            rb.MovePosition(rb.position + moveDirection);
        }
    }

    void RotateWheels()
    {
        float moveInput = PlayerInRange() || Vector3.Distance(transform.position, patrolPoints[currentPatrolIndex].position) > stoppingDistance ? 1 : 0;
        float wheelRotation = moveInput * wheelRotationSpeed * Time.deltaTime;

        // Mueve las ruedas izquierdas
        foreach (GameObject wheel in leftWheels)
        {
            if (wheel != null)
            {
                wheel.transform.Rotate(wheelRotation, 0.0f, 0.0f);
            }
        }

        // Mueve las ruedas derechas
        foreach (GameObject wheel in rightWheels)
        {
            if (wheel != null)
            {
                wheel.transform.Rotate(wheelRotation, 0.0f, 0.0f);
            }
        }
    }

    void ShootProjectile()
    {
        if (projectileSpawnPoint == null || projectilePrefab == null) return;

        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = projectileSpawnPoint.forward * projectileSpeed;

            // Ignorar colisiones entre el proyectil y el tanque enemigo que lo dispara
            Physics.IgnoreCollision(projectile.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }
}



