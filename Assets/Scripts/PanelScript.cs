using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClosePanel(GameObject close)
    {
        close.SetActive(false);
    }

    public void OpenPanel(GameObject show)
    {
        show.SetActive(true);
    }
}
