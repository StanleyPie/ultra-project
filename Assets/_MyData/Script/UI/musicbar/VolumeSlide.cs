using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlide : MonoBehaviour
{
    public Slider slicer;

    private void Start()
    {
        this.slicer = GetComponent<Slider>();

        this.slicer.value = 0.5f;
        Volume.instance.value = this.slicer.value;
    }

    public void Change(float v)
    {
        Volume.instance.value = v;
    }
}
