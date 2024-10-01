using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveImpact : MonoBehaviour
{
    public Collider2D colli;
    public Rigidbody2D body;
    public WaveDeSpawn waveDeSpawn;

    private void Start()
    {
        colli = GetComponent<Collider2D>();
        body = GetComponent<Rigidbody2D>();
        waveDeSpawn = GetComponent<WaveDeSpawn>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Deadline") return; 
        waveDeSpawn.DeSpawn();
    }
}
