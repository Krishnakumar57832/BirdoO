using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] private EnemyScript[] _enemies;
    private void OnEnable()
    {
        _enemies = FindObjectsOfType<EnemyScript>();
    }




    void Update()
    {
        foreach (EnemyScript enemy in _enemies)
        {
            if (enemy != null)
                return;
        }
        Invoke("loadScene", 2f);
    }
     void loadScene()
     {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
     }
}
