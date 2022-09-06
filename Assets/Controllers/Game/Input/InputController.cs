using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController instance;

    [SerializeField] private Keybindings keybindings;
    
    // Start is called before the first frame update
    private void Awake()
    {
        
        if (instance !=null && instance != this){
            Destroy(this);
        }
        else{
            instance = this;
        }
    }
    


    public KeyCode GetKeyForAction(KeybindingActions keybindingAction){
        foreach(Keybindings.KeybindingCheck keybindingCheck in keybindings.keybindingChecks)
        {
            if(keybindingCheck.keybindingAction == keybindingAction){
                return keybindingCheck.keyCode;
            }
        }
        return KeyCode.None;
    }

    public bool GetKeyDown(KeybindingActions keybindingAction){
        foreach(Keybindings.KeybindingCheck keybindingCheck in keybindings.keybindingChecks)
        {
            if(keybindingCheck.keybindingAction == keybindingAction){
                return Input.GetKey(keybindingCheck.keyCode);
            }
        }
        return false;
    }
}
