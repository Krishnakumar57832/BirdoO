using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenemang : MonoBehaviour
{
    public void onbuttonenter()
    {
        Invoke("onClick", 1f);
    }
    public void onClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

}
