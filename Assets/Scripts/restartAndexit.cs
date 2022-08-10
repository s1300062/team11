using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class restartAndexit: MonoBehaviour
{
    //public bool retry = false;

    [SerializeField] private GameObject pauseUI;
	[SerializeField] private AudioSource _audioSource;
    private int num = 2;
    public void Retry()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

     public void exit()
     {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
     }

     public void saikai()
     {
        _audioSource.Play();
        pauseUI.SetActive(false);
        Time.timeScale = 1f;

     }

     public void nextSece()
     {
         num.ToString();
         string sceneName = "Game" + num;
         SceneManager.LoadScene(sceneName);
         num++;
     }
}