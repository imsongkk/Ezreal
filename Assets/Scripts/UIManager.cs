using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text screenUI;

    private void Update()
    {
        screenUI.text = "Creep Score : " + GameManager.instance.cs;
    }

    public void OnClickNewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
