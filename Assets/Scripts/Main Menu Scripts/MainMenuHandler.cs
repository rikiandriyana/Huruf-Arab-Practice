using System;
using System.Collections;
using System.Collections.Generic;
// using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public static MainMenuHandler Instance;
    public Sprite[] hijaiyahSprites, angkaArabSprites, harakatSprites, sambungHijaiyahSprites;
    public Transform itemsContent;
    public GameObject ItemPreafab_TextBased, ItemPrefab_SpriteBased;
    [HideInInspector] public string panelName;
    private void Awake() {
        Instance = this;
    }
    void Start()
    {
        
    }

    public void ShowTracingItems(string category) {
        foreach(Transform child in itemsContent) {
            Destroy(child.gameObject);
        } switch(category) {
            case "hijaiyah":
                for(int i = 0; i < hijaiyahSprites.Length; i++) {
                    SetItemImage(i, hijaiyahSprites);
                }
                break;
            case "angka arab":
                for(int i = 0; i < angkaArabSprites.Length; i++) {
                    SetItemImage(i, angkaArabSprites);
                }
                break;
            case "harakat":
                for(int i = 0; i < harakatSprites.Length; i++) {
                    SetItemImage(i, harakatSprites);
                }
                break;
            case "sambung hijaiyah":
                for(int i = 0; i < sambungHijaiyahSprites.Length; i++) {
                    SetItemImage(i, sambungHijaiyahSprites);
                }
                break;
        }
    }
    // private void SetItemText(int i, int num) {
    //     GameObject _item = Instantiate(ItemPreafab_TextBased, itemsContent);
    //     _item.GetComponentInChildren<TextMeshProUGUI>().text = Convert.ToChar(num).ToString();
    // }
    private void SetItemImage(int i, Sprite[] spritesItem) {
        GameObject _item = Instantiate(ItemPrefab_SpriteBased, itemsContent);
        _item.transform.GetChild(0).GetComponent<Image>().sprite = spritesItem[i];
    }

    public void QuitGame() {
        Application.Quit();
    }
}
