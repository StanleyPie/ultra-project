using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{
    public AudioSource source;
    [Range(0f, 1)] public float value;
    public static Volume instance;
    private void Start()
    {
        this.source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        this.source.volume = value;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
