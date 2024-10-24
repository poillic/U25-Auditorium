using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler
{
    public AudioSource overSound;

    public void OnPointerEnter( PointerEventData eventData )
    {
        foreach(GameObject go in eventData.hovered )
        {
            if( go.TryGetComponent<Button>(out Button btn) )
            {
                overSound.Play();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
