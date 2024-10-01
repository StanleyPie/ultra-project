using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;
    [SerializeField] protected Transform holder;

    [SerializeField] protected int spawnCount = 0;
    public int SpawnCount => spawnCount;


    protected virtual void Awake()
    {
        this.LoadPrefabs();
        this.LoadPoolObjs();
        this.LoadCount();
    }

    protected virtual void Reset()
    {
        this.LoadPrefabs();
        this.LoadPoolObjs();
        this.LoadCount();
    }
    protected virtual void LoadCount()
    {
        this.spawnCount = 0;
    }
    protected virtual void LoadPoolObjs()
    {
        if (holder == null)
        {
            this.holder = transform.Find("Holder");
        }
        /*this.holder = transform.Find("Holder")*/
    }
    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;

        Transform prefab = transform.Find("Prefabs");
        foreach (Transform prefabs in prefab)
        {

            this.prefabs.Add(prefabs);
        }

        this.HidePrefabs();

        Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }
    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }
    public virtual Transform Spawn(string preFabName, Vector3 spawnPos, Quaternion rotation)
    {

        Transform prefab = this.GetPreFabByName(preFabName);
        //Debug.Log("string this prefab", gameObject);
        if (prefab == null)
        {
            Debug.LogWarning("Prefab not found " + preFabName);
            return null;
        }

        return this.Spawn(prefab, spawnPos, rotation);

    }
    public virtual Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform newPrefab = this.GetObjFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos, rotation);

        newPrefab.parent = this.holder;
        this.spawnCount++;
        return newPrefab;
    }
    protected virtual Transform GetObjFromPool(Transform prefab)
    {
        foreach (Transform poolobj in this.poolObjs)
        {
            if (prefab.name == poolobj.name)
            {
                this.poolObjs.Remove(poolobj);
                return poolobj;
            }
        }

        Transform newprefab = Instantiate(prefab);
        newprefab.name = prefab.name;
        return newprefab;
    }
    public virtual Transform GetPreFabByName(string preFabName)
    {
        foreach (Transform prefab in this.prefabs)
        {
            if (prefab.name == preFabName) return prefab;

        }
        return null;
    }
    public virtual void DeSpawn(Transform obj)
    {
        if (this.poolObjs.Contains(obj)) return;
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
        this.spawnCount--;
    }
    public virtual Transform RanDomObj()
    {
        int rand = Random.Range(0, this.prefabs.Count);
        //Debug.Log(rand);
        Transform obj = this.prefabs[rand];
        return obj;
    }

    public virtual Transform GetPecificPrefab(int numbetprefab)
    {
        return prefabs[numbetprefab];
    }
}
