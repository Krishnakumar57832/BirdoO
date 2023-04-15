using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject _cloudparticlePrefab;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bird bird = collision.collider.GetComponent<Bird>();  
        if (bird != null)
        {
            Instantiate(_cloudparticlePrefab,transform.position, Quaternion.identity);
            Destroy(gameObject);
            
        }
        EnemyScript enemyScript = collision.collider.GetComponent<EnemyScript>();
        if (enemyScript != null)
        {
            return;
        }
        if (collision.contacts[0].normal.y < -0.5)
        {
            Instantiate(_cloudparticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            
        }
    }
}
