using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenceTransfer : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Target(string x)
    {
        SceneManager.LoadScene(x);
    }

    public void QuitGame()
    {
        Application.Quit();
    }




}
