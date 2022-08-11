using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class SceneChange : UIBehaviour
{
    protected override void Start()
    {
        base.Start();

        // Button�N���b�N���AOnClick���\�b�h���Ăяo��
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        // �uGameScene�v�V�[���ɑJ�ڂ���
        SceneManager.LoadScene("Beginning-1");
    }
}