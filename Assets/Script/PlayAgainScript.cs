using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void ButtonReset()
    {
        SceneManager.LoadScene(1);
    }

    public void Quitgame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Debug.Log("1");
    }
}
