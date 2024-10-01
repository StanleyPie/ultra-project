using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Slider slider;

    private void Start()
    {
        Volume.instance.value = 0.5f;
        if (SceneManager.GetActiveScene().name == "_HomeScene")
        {
            Debug.Log("fjkdshg");
            this.gameObject.SetActive(false);
            return;
        }

        else
        {
            this.gameObject.SetActive(true);
        }
    }

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "_HomeScene")
        {
            Debug.Log("fjkdshg");
            this.gameObject.SetActive(false);
            return;
        }

        else
        {
            this.gameObject.SetActive(true);
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
}
