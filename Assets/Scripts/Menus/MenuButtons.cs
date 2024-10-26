using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{

    public GameObject setMenu;
    public bool isMenu;



    public void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        setMenu.SetActive(false);
        isMenu = false;
    }

    public void PlayGame()
    {
        Debug.Log("PLAY!");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void Options()
    {
        OpenMenu();
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMenu)
            {
                CloseMenu();
            }
        }
    }


    public void OpenMenu()
    {
        setMenu.SetActive(true);
        isMenu = true;
    }

    public void CloseMenu()
    {
        setMenu.SetActive(false);
        isMenu = false;
    }

}