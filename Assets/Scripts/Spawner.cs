using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [Header( "Spawn" )]
    public float spawnRate;
    [Tooltip("Le rayon pour spawn les particules autour du spawner"), Range(0,354)]
    public float spawnRadius;

    [Header("Pool Params")]
    public int maxPooledItem;
    public GameObject prefabParticle;
    public IObjectPool<GameObject> poolParticles;


    private float chrono;
    // Start is called before the first frame update
    void Start()
    {
        poolParticles = new ObjectPool<GameObject>( OnCreateItem, OnTakeItem, OnReturnToPool, OnDestroyItem, maxSize: maxPooledItem );

        for ( int i = 0; i < maxPooledItem; i++ )
        {
            poolParticles.Release( CreateParticle() );
        }
    }

    // Update is called once per frame
    void Update()
    {

        if( chrono >= 1f / spawnRate )
        {
            poolParticles.Get();
            chrono = 0f;
        }

        chrono += Time.deltaTime;

    }

    private GameObject CreateParticle()
    {
        GameObject particle = Instantiate( prefabParticle );
        ReturnToPool rtp = particle.AddComponent<ReturnToPool>();
        rtp.pool = poolParticles;
        return particle;
    }

    public GameObject OnCreateItem()
    {
        return CreateParticle();
    }

    public void OnTakeItem( GameObject item )
    {
        item.transform.position = (Vector2) transform.position +
                                    Random.insideUnitCircle * spawnRadius;
        item.transform.rotation = transform.rotation;
        item.SetActive( true );
    }

    public void OnReturnToPool( GameObject item )
    {
        item.SetActive( false );
    }

    public void OnDestroyItem( GameObject item )
    {
        Destroy( item );
    }
}
