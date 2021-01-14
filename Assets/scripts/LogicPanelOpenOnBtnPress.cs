using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicPanelOpenOnBtnPress : MonoBehaviour
{

    public GameObject PanelGamObj;
  


   public void OpenPanel()
    {
        if (PanelGamObj != null)
            PanelGamObj.SetActive(true);
    }
}
