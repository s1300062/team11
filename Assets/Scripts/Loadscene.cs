using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
	private static int _score;

	//�@�X�^�[�g�{�^��������������s����
	public void StartGame()
	{
		SceneManager.LoadScene("SampleScene");
	}
	private static void getScore()
	{
		_score = Judge.score;
	}

	public void Changescene1() {
		if (_score >= 259200)
		{

			SceneManager.LoadScene("SampleScene");
		}
		else SceneManager.LoadScene("SampleScene");

	}
	public void Changescene2()
	{

		if (_score >= 204600)
		{

			SceneManager.LoadScene("SampleScene");
		}
		else SceneManager.LoadScene("SampleScene");

	}
	public void Changescene3()
	{
		if (_score >= 181200)
		{

			SceneManager.LoadScene("SampleScene");
		}
		else SceneManager.LoadScene("SampleScene");

	}
}