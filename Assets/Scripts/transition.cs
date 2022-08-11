using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transition : MonoBehaviour
{
    private static int i;
    void Start()
    {
        geti();
        if (i == 3)
        {
            SceneManager.LoadScene("Ending-True");
        }

        else if(i==1 || i==2)
        {
            SceneManager.LoadScene("Ending-Normal");
        }

        else SceneManager.LoadScene("Ending-Bad");
    }


    private static void geti()
    {
        i = Judge._i;
    }
}
