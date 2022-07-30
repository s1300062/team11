using UnityEngine;
using System.Collections;
 
public class PauseScript2 : MonoBehaviour {
 
	//　ポーズした時に表示するUI
	[SerializeField] 
	private GameObject pauseUI;
	[SerializeField] private AudioSource _audioSource;

	void Start(){
		_audioSource = this.GetComponent<AudioSource>();
		pauseUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("q")) {
			//　ポーズUIのアクティブ、非アクティブを切り替え
			pauseUI.SetActive (!pauseUI.activeSelf);
 
			//　ポーズUIが表示されてる時は停止
			if(pauseUI.activeSelf) {
				_audioSource.Pause();
				Time.timeScale = 0f;
			//　ポーズUIが表示されてなければ通常通り進行
			} else {
				_audioSource.Play();
				Time.timeScale = 1f;
			}
		}
	}
}
 