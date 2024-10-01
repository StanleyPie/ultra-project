using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflecttion : MonoBehaviour
{
    public float percentRemain = 70f;
    public Collider2D colli;
    public Rigidbody2D body;
    public bool canReflect = true;

    private void Start()
    {
        colli = GetComponent<Collider2D>();
        body = GetComponent<Rigidbody2D>();
        body.constraints = RigidbodyConstraints2D.FreezePosition;
        body.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("hit");
        if (collision.collider.tag != "Wave") return;
        float angle = collision.transform.eulerAngles.z;

        WaveDeSpawn deSpawn = collision.transform.GetComponent<WaveDeSpawn>();
        deSpawn.DeSpawn();

        if (!this.canReflect) return;
        angle += 180;
        Quaternion rotation = Quaternion.Euler(0,0, angle);

        Vector3 hitPoint = collision.contacts[0].point;

        ProcessWave(hitPoint, rotation);
    }

    private void ProcessWave(Vector3 hitPos, Quaternion reflectedRotation)
    {
        Transform prefab = WaveSpawner.Instance.Spawn("SoundWave", hitPos, reflectedRotation);

        SpriteRenderer sprite = prefab.GetComponent<SpriteRenderer>();
        Color newColor = sprite.color;
        newColor.a = newColor.a * (this.percentRemain/100); 
        sprite.color = newColor;

        WaveDeSpawn deSpawn = prefab.GetComponent<WaveDeSpawn>();
        deSpawn.spawnObject = this.transform;

        prefab.gameObject.SetActive(true);
    }
}
