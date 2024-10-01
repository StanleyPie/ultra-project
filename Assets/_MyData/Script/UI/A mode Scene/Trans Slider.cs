using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TransSlider : MonoBehaviour
{
    public SpawningWave spawning;
    public Slider slicer;
    public TextMeshProUGUI text;

    private void Start()
    {
        this.slicer = GetComponent<Slider>();
        this.text = GetComponentInChildren<TextMeshProUGUI>();

        this.slicer.value = slicer.minValue;
    }

    public void Change(float v)
    {
        text.text = v.ToString();
        spawning.limitTime = v;
    }
}
