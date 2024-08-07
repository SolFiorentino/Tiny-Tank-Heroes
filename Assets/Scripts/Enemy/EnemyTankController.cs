using UnityEngine;

public class EnemyTankController : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    public float rotationSpeed = 2f;
    public float stoppingDistance = 10f; // Distancia a la que se detiene el tanque enemigo

    public GameObject[] leftWheels;
    public GameObject[] rightWheels;
    public float wheelRotationSpeed = 200f;

    public Transform projectileSpawnPoint; // Punto de spawn para los proyectiles
    public GameObject projectilePrefab; // Prefab del proyectil
    public float projectileSpeed = 20f; // Velocidad del proyectil
    public float fireRate = 1f; // Frecuencia de disparo
    private float nextFireTime;

    private Rigidbody rb;

    // Define los límites de la zona permitida
    public float minX = -40.83f;
    public float maxX = -35.17f;
    public float minZ = 378.39f;
    public float maxZ = 385.61f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nextFireTime = Time.time;
    }

    void FixedUpdate()
    {
        MoveTowardsPlayer();
        RotateWheels();
        KeepWithinBounds();
    }

    void Update()
    {
        if (Time.time > nextFireTime)
        {
            ShootProjectile();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void MoveTowardsPlayer()
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
        float moveInput = Vector3.Distance(transform.position, player.position) > stoppingDistance ? 1 : 0;
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

    void KeepWithinBounds()
    {
        // Restringir el tanque dentro de los límites definidos
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, minX, maxX);
        position.z = Mathf.Clamp(position.z, minZ, maxZ);
        transform.position = position;
    }
}








