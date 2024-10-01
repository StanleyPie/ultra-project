using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningWave : MonoBehaviour
{
    public Transform point2;
    public Transform alert;

    public float limitTime = 1f;
    public float timer;
    private Vector3 offset;
    private float zDistanceToCamera;

    private void OnMouseDown()
    {
        if (this.timer < limitTime) return;
        this.SpawnWave();
    }

    //void OnMouseDown()
    //{
    //    zDistanceToCamera = Vector3.Distance(transform.position, Camera.main.transform.position);

    //    Vector3 mousePosition = Input.mousePosition;
    //    mousePosition.z = zDistanceToCamera;
    //    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
    //    offset = transform.position - worldPosition;
    //}

    //void OnMouseDrag()
    //{
    //    Vector3 mousePosition = Input.mousePosition;
    //    mousePosition.z = zDistanceToCamera;
    //    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

    //    transform.position = worldPosition + offset;
    //}

    private void Start()
    {
        this.timer = limitTime;
    }


    private void Update()
    {
        this.timer = Mathf.Min(this.timer += Time.deltaTime, this.limitTime);
        this.OpenAlert();
    }

    void OpenAlert()
    {
        this.alert.gameObject.SetActive(this.timer >= limitTime);
    }

    public void SpawnWave()
    {
        Quaternion rot = transform.rotation;
        this.Spawn(point2.position, rot);
        this.timer = 0f;
    }



    void Spawn(Vector2 spawnPos, Quaternion spawnRotation)
    {
        Transform prefab = WaveSpawner.Instance.Spawn("SoundWave", spawnPos, /*rot * */spawnRotation);

        WaveDeSpawn deSpawn = prefab.GetComponent<WaveDeSpawn>();
        deSpawn.spawnObject = this.transform;

        SpriteRenderer sprite = prefab.GetComponent<SpriteRenderer>();
        Color newColor = sprite.color;
        newColor.a = 1;
        sprite.color = newColor;

        prefab?.gameObject.SetActive(true);
    }
}
