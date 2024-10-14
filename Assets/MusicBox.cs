using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{

    [Header( "Balance" )]
    [Tooltip( "Volume gain per particle" )]
    public float volumeIncrement = 0.02f;
    [Tooltip( "Volume lost per second" )]
    public float volumeDecay = 0.01f;
    [Tooltip( "Time beforde decrementing volume" )]
    public float decayInterval = 1f;

    [Header("Setup")]
    [SerializeField] AudioSource m_audioSource;
    [SerializeField] Color m_onColor;
    [SerializeField] Color m_offColor;

    private float m_chrono = 0f;

    // Start is called before the first frame update
    void Start()
    {
        m_audioSource.volume = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        m_chrono += Time.deltaTime;

        if( m_chrono >= decayInterval )
        {
            //Je diminue le volume
            m_audioSource.volume -= volumeDecay * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D( Collider2D collision )
    {
        m_audioSource.volume += volumeIncrement;
        m_chrono = 0f;
    }
}
