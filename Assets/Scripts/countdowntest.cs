using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdowntest : MonoBehaviour
{
    public Text CountText;
    float countdown = 4f;
    int count;
    int retime;

    [SerializeField] GameObject countdownUI;
    [SerializeField] private AudioSource _audioSource;

    void Start()
    {
        countdownUI.SetActive(true);
        //countdown = Time.realtimeSinceStartup; //test
       //_audioSource = this.GetComponent<AudioSource>(); //test たぶんいらん
    }

    void Update()
    {
        if (countdown >= 0)
        {
        
            _audioSource.Stop(); //test
            countdown -= Time.unscaledDeltaTime;//Time.deltaTime; //test
            count = (int)countdown;
            CountText.text = count.ToString();
            Time.timeScale = 0f; //test
        }
        if(countdown <= 0)
        {
            
            _audioSource.Play(); //test
            CountText.text = "";
            countdownUI.SetActive(false);
            Time.timeScale = 1f; //test

        }
        //if(re)
    }
}
