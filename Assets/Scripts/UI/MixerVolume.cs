using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerVolume : MonoBehaviour
{
    public AudioMixer myMixer;
    public string propertyName = "MasterVolume";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolume( float value )
    {
        float db = Mathf.Log10( value ) * 20f;
        myMixer.SetFloat( propertyName, db );
        Debug.Log( value );
    }
}
