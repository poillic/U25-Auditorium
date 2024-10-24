using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelComponent : MonoBehaviour
{
    public TextMeshProUGUI levelNameLabel;
    public Image levelIcon;
    public Button btn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Initialize( LevelData data )
    {
        levelIcon.sprite = data.icon;
        levelNameLabel.text = data.levelName;

        if( !data.unlock )
        {
            btn.interactable = false;
        }

        /*btn.onClick.AddListener( delegate
        {
            SceneManager.LoadScene( data.sceneName );
        } );*/

        btn.onClick.AddListener( () => {
            SceneManager.LoadScene( data.sceneName );
        } );
    }

}
