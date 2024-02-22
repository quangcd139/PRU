using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Panel;
    public bool isPanelOpen;
    public void Open()
    {

        if (Panel != null)
        {

            isPanelOpen = !isPanelOpen;

            Panel.SetActive(isPanelOpen);

            if (isPanelOpen)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
                
            }

        }
    }
    
}
