using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectAndRetract : MonoBehaviour
{
    public float refle = 0.2f;
    public float retra = 0.3f;
    public Collider2D colli;
    public Rigidbody2D body;
    public bool useEffect = true;
    public bool canretract = false;

    private void Start()
    {
        colli = GetComponent<Collider2D>();
        body = GetComponent<Rigidbody2D>();
        body.constraints = RigidbodyConstraints2D.FreezePosition;
        body.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Wave") return;

        SpriteRenderer sprite = collision.transform.GetComponent<SpriteRenderer>();
        Color newColor = sprite.color;
        float newValue = newColor.a;

        float angle = collision.transform.eulerAngles.z;

        WaveDeSpawn deSpawn = collision.transform.GetComponent<WaveDeSpawn>();
        deSpawn.DeSpawn();

        if (!this.useEffect) return;

        float rotateAngle = angle + 180;
        Quaternion reflect = Quaternion.Euler(0, 0, rotateAngle);
        Quaternion retract = Quaternion.Euler(0, 0, angle);

        Vector3 hitPoint = collision.contacts[0].point;

        ProcessWave(hitPoint, reflect, newValue, refle);

        if (!canretract) return;
        ProcessWave(hitPoint, retract, newValue, retra);
    }

    private void ProcessWave(Vector3 hitPos, Quaternion rot, float startValue, float minusValue)
    {
        Transform prefab = WaveSpawner.Instance.Spawn("SoundWave", hitPos, rot);

        SpriteRenderer sprite = prefab.GetComponent<SpriteRenderer>();
        Color prefabColour = sprite.color;
        prefabColour.a = startValue - minusValue;
        sprite.color = prefabColour;

        WaveDeSpawn deSpawn = prefab.GetComponent<WaveDeSpawn>();
        deSpawn.spawnObject = this.transform;

        prefab.gameObject.SetActive(true);
    }
}
