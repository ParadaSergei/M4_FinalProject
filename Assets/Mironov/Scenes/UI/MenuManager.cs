using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void NewLevel1()
    {
        PlayerPrefs.SetInt("Lvl", 1);
        SceneManager.LoadScene(1);
    }
    public void BckToMnu()
    {
        SceneManager.LoadScene(0);
    }
    public void NextLvl()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        var newSceneIndex = currentSceneIndex + 1;
        PlayerPrefs.SetInt("Lvl", newSceneIndex);
        SceneManager.LoadScene(newSceneIndex);
        
    }
    public void LoadLevel()
    {
        var loadlvl = PlayerPrefs.GetInt("Lvl");
        SceneManager.LoadScene(loadlvl);
    }
}
