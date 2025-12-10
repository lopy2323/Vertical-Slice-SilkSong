using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Pauze : MonoBehaviour
{
    [SerializeField]private GameObject panel;
    [SerializeField]private GameObject pauzeMenu;

    [SerializeField] private List<GameObject> Button = new List<GameObject>();

    private bool isPauzed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauzeGame();
        }
    }
    public void PauzeGame()
    {
        if (isPauzed == true)
        {
            isPauzed = false;
            panel.SetActive(false);
            pauzeMenu.SetActive(false);
            foreach (GameObject but in Button)
            {
                but.SetActive(false);
            }
        }
        else
        {
            isPauzed = true;
            panel.SetActive(true);
            pauzeMenu.SetActive(true);
        }
    }
    public void Quit()
    {
        Application.Quit();
        EditorApplication.Exit(0);
    }
}
