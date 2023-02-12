using UnityEditor;

using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Visual element that controls information for each of the abilities
/// </summary>
public class AbilityRow : VisualElement
{
    private static CharacterCreationScreen _characterCreationScreen;
    private VisualTreeAsset _rowAsset;
    private bool _isSelected = false;

    public AbilityRow(Ability abilityData, CharacterCreationScreen parentScreen)
    {
        _characterCreationScreen = parentScreen;

        //Note: This should use the addressables system in a real project and would not work in a built project.
        _rowAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/GDR/UserInterface/AbilityRow.uxml");
        Add(_rowAsset.CloneTree());

        //Set the properties of the ability
        this.Q<Label>("Title").text = abilityData.Name;
        this.Q<Label>("Ability_Description").text = abilityData.Description;
        this.Q<VisualElement>("Icon").style.backgroundImage = new StyleBackground(abilityData.Image);

        //Handles logic for when the player (un)selects the row
        this.RegisterCallback<MouseDownEvent>((e) => 
        {
            //Can only select two abilities - this will ignore the third selection
            if (!_characterCreationScreen.CanSelectAbility() && !_isSelected)
            {
                return;
            }

            ToggleInClassList("selected");
            _isSelected = !_isSelected;
            _characterCreationScreen.ToggleSelectedAbility(abilityData);
        });

    }

}
