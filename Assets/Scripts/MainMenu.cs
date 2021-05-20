using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame(){
        SceneManager.LoadScene("HarryScene2"); // Gyalpo, change this for the initial tutorial of the game, create a different scene
    }

    public void QuitToDesktop(){
        Application.Quit();
    }
}
