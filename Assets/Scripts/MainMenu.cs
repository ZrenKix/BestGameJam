using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayClicked() {
        SceneManager.LoadScene("Chicken AI");
   }

   public void QuitClicked() {
        Application.Quit();
   }
    
}
