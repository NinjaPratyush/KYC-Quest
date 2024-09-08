using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Final()
    {
        SceneManager.LoadScene(2);
    }
    public void Restart()
    {
        SceneManager.LoadScene(2);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
