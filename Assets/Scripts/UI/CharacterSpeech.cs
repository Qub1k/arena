using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterSpeech : MonoBehaviour
{
    private TextMesh text;
    public TextMesh Text => text;

    private void Start()
    {
        text = GetComponent<TextMesh>();
    }

    
}
