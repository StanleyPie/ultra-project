using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AmpliSlide : MonoBehaviour
{
    public SineWave speed;
    public Slider slicer;
    public TextMeshProUGUI text;

    private void Start()
    {
        this.slicer = GetComponent<Slider>();
        this.text = GetComponentInChildren<TextMeshProUGUI>();

        this.slicer.value = 1f;
    }

    public void Change(float v)
    {
        float newv = /*(int)*/v;
        text.text = newv.ToString();
        speed.amplitude = newv;
    }
}
