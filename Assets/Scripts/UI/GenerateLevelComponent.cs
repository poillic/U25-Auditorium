using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevelComponent : MonoBehaviour
{
    // Start is called before the first frame update
    public List<LevelData> levelDatas;
    public GameObject levelComponent;

    void Start()
    {
        foreach ( LevelData data in levelDatas )
        {
           Instantiate( levelComponent, transform ).GetComponent<LevelComponent>().Initialize( data );

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
