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

        // Buttonクリック時、OnClickメソッドを呼び出す
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        // 「GameScene」シーンに遷移する
        SceneManager.LoadScene("SampleScene");
    }
}