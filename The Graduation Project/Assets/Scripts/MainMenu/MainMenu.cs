using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : Menu
{
    
    [Header("Menu Navigation")]
    [SerializeField] private SaveSlotsMenu saveSlotsMenu;
    
    [Header("Menu Buttons")]
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button continueGameButton;
    [SerializeField] private Button loadGameButton;
    private void Start() 
    {
        DisableButtonsDependingOnData();
    }

    private void DisableButtonsDependingOnData() 
    {
        if (!DataPersistenceManager.instance.HasGameData()) 
        {
            continueGameButton.interactable = false;
            loadGameButton.interactable = false;
        }
    }
 public void OnNewGameClicked()
    {
      //  DisableMenuButtons();
        // Debug.Log("New Game Cliecked"); TEST AMACLI YAPILMISTIR
       // DataPersistenceManager.instance.NewGame();
        //Load the Gameplay scene - which will in turn save the game because of
        //OnSceneUnloaded() in the DataPersistenceManager
     // SceneManager.LoadSceneAsync("SampleScene");
     saveSlotsMenu.ActivateMenu(false);
     this.DeactivateMenu();
    }
 
 public void OnLoadGameClicked() 
 {
     saveSlotsMenu.ActivateMenu(true);
     this.DeactivateMenu();
 }
    public void OnContinueGameClicked()
    {
        DisableMenuButtons();
        // save the game anytime before loading a new scene
        DataPersistenceManager.instance.SaveGame();
        
        //Debug.Log("Continue Game Cliecked"); TEST AMACLI YAPILMISTIR
        //load the next scene - which will in turn load the game because of
        //OnSceneLoaded() in the DataPersistenceManager
       SceneManager.LoadSceneAsync("SampleScene");
    }

    private void DisableMenuButtons()
    {
        newGameButton.interactable = false;
        continueGameButton.interactable = false;
    }
    public void ActivateMenu() 
    {
        this.gameObject.SetActive(true);
        DisableButtonsDependingOnData();
    }
    public void DeactivateMenu() 
    {
        this.gameObject.SetActive(false);
    }
	public void QuitGame()
	{
    Debug.Log("QUIT!");
	//Application.Quit();
	}
}
