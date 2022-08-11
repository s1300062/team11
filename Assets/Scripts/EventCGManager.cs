using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

public class EventCGManager : MonoBehaviour
{
    Image _eventImg;
    // Start is called before the first frame update
    void Start()
    {
        Addressables.LoadAssetAsync<Sprite>("Assets/Images/EventCG/Otouto.png").Completed += sprite =>
        {
            _eventImg = GetComponent<Image>();
            _eventImg.type = Image.Type.Simple;
            _eventImg.sprite = Instantiate(sprite.Result);
        };
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
