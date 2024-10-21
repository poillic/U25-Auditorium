using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityEvent<int> MyIntEvent;

    public GameEvent OnHitEvent;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D( Collider2D collision )
    {
        //CompareTag("Enemy")
        OnHitEvent.Trigger();
    }

    public void Hit()
    {
        Debug.Log( "J'ai été touché" );
    }
}
