using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupTalk : MonoBehaviour
{
    public GameObject popUpBox;
    public TMP_Text popUpText;
    public string text;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PopUp()
    {
        popUpBox.SetActive(true);
        popUpText.text = text;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Get in here");
            PopUp();
        }
    }
}
