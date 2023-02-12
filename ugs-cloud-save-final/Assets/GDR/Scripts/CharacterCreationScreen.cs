using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.UIElements;

public class CharacterCreationScreen : MonoBehaviour
{
    [SerializeField]
    private UIDocument _uiDocument;
    

    // Start is called before the first frame update
    void Start()
    {
        _uiDocument.rootVisualElement.Q<Label>("Next").RegisterCallback<MouseDownEvent>(NextButton_Clicked);
        var abilityContainer = _uiDocument.rootVisualElement.Q<VisualElement>("Abilities");

        abilityContainer.Add(new AbilityRow());
        
    }

    private void NextButton_Clicked(MouseDownEvent e)
    {
        throw new System.NotImplementedException();
    }
}
