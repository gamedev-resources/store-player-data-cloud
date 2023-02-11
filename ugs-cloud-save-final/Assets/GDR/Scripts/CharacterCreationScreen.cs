using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterCreationScreen : MonoBehaviour
{
    [SerializeField]
    private UIDocument _uiDocument;

    // Start is called before the first frame update
    void Start()
    {
        _uiDocument.rootVisualElement.Q<Button>("Next").clicked += NextButton_Clicked;            
        _uiDocument.rootVisualElement.Q<Button>("Next").clicked += NextButton_Clicked;            
    }

    private void NextButton_Clicked()
    {
        throw new System.NotImplementedException();
    }
}
