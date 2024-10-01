using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : Spawner
{
    private static WaveSpawner instance;
    public static WaveSpawner Instance { get => instance; }

    public float speed = 1f;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.Log("only 1 WaveSpawner");
        WaveSpawner.instance = this;
    }
}
