using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMove : MonoBehaviour
{
    public Vector3 direction = Vector3.right;
    public float speed = 5f;
    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void Update()
    {
        transform.Translate(this.direction * WaveSpawner.Instance.speed * Time.deltaTime);
    }
}
