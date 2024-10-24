using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu( fileName = "GameData", menuName = "Game/GameData")]
public class GameData : ScriptableObject
{
    public int currentLevelIndex = 0;
    public List<LevelData> levels;

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
        currentLevelIndex++;
        SceneManager.LoadScene( levels[ currentLevelIndex ].sceneName );
    }
}
