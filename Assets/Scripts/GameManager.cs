using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelOne : MonoBehaviour
{
    public Button nextLevelButton;
    public Canvas nextCanvas; 
    public List<BoxScript> boxScripts;
    //private BoxScript boxOneScipt; 
    private bool gameOverBoolean = false;
    public int thisScene;


    void Start()
    {
        nextCanvas.gameObject.SetActive(gameOverBoolean);
        nextLevelButton.onClick.AddListener(() => nextLevelButtonListener());
    }

    void nextLevelButtonListener() {
        if(thisScene + 1 < 4) SceneManager.LoadScene(thisScene + 1);
        else SceneManager.LoadScene(0);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(thisScene);
        }
        gameOverBoolean = CheckAllSpots();
        nextCanvas.gameObject.SetActive(gameOverBoolean);
    }

    bool CheckAllSpots(){
        foreach(BoxScript b in boxScripts){
            if(!b.GetOnSpot()) return false;
        }
        return true;
    }
}
