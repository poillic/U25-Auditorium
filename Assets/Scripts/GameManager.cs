using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    // Combien y'a du musicBox
    // Compter le nombre de musicBox à 100% volume
    // Si le nombreTotalDeMusicBox == NombreDeBoxA100%

    public List<MusicBox> boxes = new();
    public float waitingTime = 2f;
    public UnityEvent OnVictory = new();

    private bool victory = false;
    private float chrono = 0f;
    private bool vicotryTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        //Automatiser la recherche des musicboxes
        GameObject[] musicBoxes = GameObject.FindGameObjectsWithTag( "MusicBox" );

        foreach ( GameObject  box in musicBoxes )
        {
            boxes.Add( box.GetComponent<MusicBox>() );
        }
    }

    // Update is called once per frame
    void Update()
    {
        if( !victory )
        {
            CheckVictory();
        }
        else
        {
            //On lance le compteur pour passer au niveau suivant
            chrono += Time.deltaTime;

            if( chrono >= waitingTime && !vicotryTriggered )
            {
                OnVictory.Invoke();
                vicotryTriggered = true;
            }
        }
    }

    private void CheckVictory()
    {
        victory = true;
        foreach ( MusicBox box in boxes )
        {
            victory = victory && box.IsMaxVolume();

            if ( !victory )
            {
                //Si on a trouvé une box false on arrete la boucle
                break;
            }
        }
    }
}
