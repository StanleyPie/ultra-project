using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveDeSpawn : MonoBehaviour
{
    public float limitDistance = 7f;
    public float distance;
    public Transform spawnObject;
    public SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        this.CheckDeSpawn();
        this.CanDeSpawn();
    }

    void CheckDeSpawn()
    {
        Color newColor = sprite.color;
        if (this.CanDeSpawn() || newColor.a <= 0.1f)
        {
            this.DeSpawn();
        }
    }

    public void DeSpawn()
    {
        WaveSpawner.Instance.DeSpawn(transform);
    }

    bool CanDeSpawn()
    {
        this.distance = Vector2.Distance(transform.position, this.spawnObject.position);
        return distance > limitDistance;
    }
}
