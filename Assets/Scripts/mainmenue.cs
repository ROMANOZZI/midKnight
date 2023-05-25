using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenue : MonoBehaviour
{
    // Start is called before the first frame update
   public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }


    
    
}
