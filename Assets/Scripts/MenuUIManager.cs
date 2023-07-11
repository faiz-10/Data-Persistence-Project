using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField inputField;
    public TextMeshProUGUI bestScore;

    private void Start()
    {
        bestScore.text = "Best Score : " + DataPersist.instance.playerName + " : " + DataPersist.instance.highestScore;
    }
    public void Enter()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SetName()
    {
        DataPersist.instance.currentPlayer = inputField.text;

        //DataPersist.instance.playerName = name;
    }
    
    
    
}