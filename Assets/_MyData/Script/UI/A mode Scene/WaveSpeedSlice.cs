using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpeedSlice : MonoBehaviour
{
    public Slider slicer;
    public TextMeshProUGUI text;

    private void Start()
    {
        this.slicer = GetComponent<Slider>();
        this.text = GetComponentInChildren<TextMeshProUGUI>();

        this.slicer.value = 0.3f;
    }

    public void Change(float v)
    {
        text.text = v.ToString();
        WaveSpawner.Instance.speed = v;
    }
}
