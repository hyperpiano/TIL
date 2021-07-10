using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Play() {
        SceneManager.LoadScene("Main");
    }

    public void Quit() {
        Application.Quit();
    }
    
}
