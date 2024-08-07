using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletLevel1y2 : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Verifica si la colisión es con una caja
        if (collision.gameObject.CompareTag("Box"))
        {
            // Aquí puedes manejar lo que sucede cuando la bala colisiona con una caja
            Debug.Log("La bala impactó con una caja!");

            // Incrementar el contador de objetivos impactados
             ScoreManager.instance.IncrementScore();

            // Destruir la bala al colisionar
            Destroy(gameObject);
        }
        // Verifica si la colisión es con un tanque enemigo
        else if (collision.gameObject.CompareTag("EnemyTank"))
        {
            // Aquí puedes manejar lo que sucede cuando la bala colisiona con un tanque enemigo
            Debug.Log("La bala impactó con un tanque enemigo!");

            // Destruir el tanque enemigo
            Destroy(collision.gameObject);

            // Incrementar el contador de enemigos eliminados
            EnemyScoreManager.instance.IncrementEnemyScore();

            // Destruir la bala al colisionar
            Destroy(gameObject);
        }
    }
}
