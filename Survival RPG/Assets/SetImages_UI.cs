using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetImages_UI : MonoBehaviour
{
    public Sprite[] art;
    public Image[] imageAsset;

    private void Start()
    {
        if(art.Length != imageAsset.Length){
            Debug.LogError("Art/ImageAsset do not match");
            return;
        }
        for(int i = 0; i < art.Length; i++){
            imageAsset[i].sprite = art[i];
        }
    }
}
