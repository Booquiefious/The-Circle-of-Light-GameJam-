using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour {

    public void QUIT()
    {
        Application.Quit();
    }

    public void RETURN()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

}
