using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioChanger : MonoBehaviour
{
    public AudioSource musicChanger;
    public AudioClip newClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!musicChanger.isPlaying)
        {
            musicChanger.clip = newClip;
            musicChanger.loop = true;
            musicChanger.Play();
        }
    }
}
