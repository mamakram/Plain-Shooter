using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 [CreateAssetMenu(fileName = "config", menuName = "Keybindings")]
public class Keybindings : ScriptableObject
{
    [System.Serializable]
    public class KeybindingCheck{
        public KeybindingActions keybindingAction;
        public KeyCode keyCode;
    }

    public KeybindingCheck[] keybindingChecks;
}
