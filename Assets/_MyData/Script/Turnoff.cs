using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turnoff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.gameObject?.SetActive(false);
        }
    }
}
