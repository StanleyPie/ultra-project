using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class xbutton : MonoBehaviour
{
    public GameObject prefab;
    public Button button;

    private void Start()
    {
        this.button = GetComponent<Button>();
    }

    public void OnPress()
    {
        bool isOn = this.prefab.activeSelf;
        this.prefab.SetActive(!isOn);
    }
}
