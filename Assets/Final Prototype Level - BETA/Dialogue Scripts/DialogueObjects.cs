using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]
public class DialogueObjects : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialogue;
    public string[] Dialogue => dialogue;

}
