using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public GameObject restartMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0f){
            Destroy(gameObject);
        }
        
    }

    public void PlayGame ()
    {
        
        Destroy(gameObject);
        SceneManager.LoadScene("Game");

    }

    public void QuitGame ()
    {
        Application.Quit();
    }

}
