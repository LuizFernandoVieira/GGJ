using UnityEngine;
using System.Collections;

public class MenuHandler : MonoBehaviour {

    public void PlayClicked()
    {
        Application.LoadLevel(1);
    }
    
    public void ExitClicked()
    {
        Application.Quit();
    }
    
}
