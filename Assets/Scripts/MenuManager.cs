using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
	
	//Show Level 2
	public void ShowLevel2()
    {
        SceneManager.LoadScene("Nivel_2");
    }

    // Show How to play
    public void ShowHowToPlay()
    {
        SceneManager.LoadScene(2);
    }
}
