using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdooMovement: MonoBehaviour 
{
    private Vector3 _initialposition;
    private bool _birdwaslaunched;
    [SerializeField]private float _launchpower = 500;
    private float _timesittingaround;
    private void Awake()
    {
        _initialposition= transform.position;
    }

    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialposition);
       
        if (_birdwaslaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _timesittingaround += Time.deltaTime;
        }

        if (transform.position.y > 10 || 
            transform.position.y < -10 ||
            transform.position.x > 15 ||
            transform.position.x < -15 ||
            _timesittingaround > 2)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;

    }
    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;

        Vector2 directionToInitialPosition = _initialposition - transform.position; 
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchpower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdwaslaunched = true;
        GetComponent<LineRenderer>().enabled = false;
    }
    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }
}
