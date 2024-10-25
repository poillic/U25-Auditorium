using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu( fileName = "GameData", menuName = "Game/GameData")]
public class GameData : ScriptableObject
{
    public int currentLevelIndex = 0;
    public List<LevelData> levels;

    public void ResetIndex()
    {
        currentLevelIndex = 0;
    }

    public void GoToLevel( int index )
    {
        currentLevelIndex = index;
        SceneManager.LoadScene( levels[ currentLevelIndex ].sceneName );
    }

    public void LoadPreviousLevel()
    {
        currentLevelIndex--;
        SceneManager.LoadScene( levels[ currentLevelIndex ].sceneName );
    }

    public void LoadNextLevel()
    {
        levels[ currentLevelIndex ].unlock = true;
        currentLevelIndex++;
        

        if( currentLevelIndex >= levels.Count -1 )
        {
            SceneManager.LoadScene( "Menu" );
        }
        else
        {
            //currentLevelIndex = Mathf.Clamp( currentLevelIndex, 0, levels.Count - 1 );
            SceneManager.LoadScene( levels[ currentLevelIndex ].sceneName );
        }
        //On peut aller plus loin que le dernier index du tableau
    }
}
