
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class CardboardModeMgr : MonoBehaviour {
    
    /**
    * Precisamos da referência da camera 
    * é como recuperamos os componentes do Cardboard
    **/
    public GameObject mainCamera;
    
    public void Start()
    {
        // Salva a preferencia do jogador para inicializar em VR Mode.
        int doVR = PlayerPrefs.GetInt("VREnabled");
        Cardboard.SDK.VRModeEnabled = doVR == 1;
        CardboardHead head = mainCamera.GetComponent<CardboardHead>();
        head.enabled  = Cardboard.SDK.VRModeEnabled;
        Cardboard.SDK.TapIsTrigger = true;
    }

   // Captura o evento do clique do botão e modifica a camera para VR mode.
    public void ChangeCardboardMode ()
    {
        CardboardHead head = mainCamera.GetComponent<CardboardHead>();
        if (Cardboard.SDK.VRModeEnabled) {
            // Desabilita.
            head.transform.localRotation = Quaternion.identity;
        }
        Cardboard.SDK.VRModeEnabled = !Cardboard.SDK.VRModeEnabled;
        head.enabled  = Cardboard.SDK.VRModeEnabled;
        PlayerPrefs.SetInt("VREnabled", Cardboard.SDK.VRModeEnabled?1:0);
        PlayerPrefs.Save();        
    }
}
