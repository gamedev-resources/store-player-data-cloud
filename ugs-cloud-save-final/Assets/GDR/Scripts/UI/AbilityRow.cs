using UnityEditor;

using UnityEngine.UIElements;

public class AbilityRow : VisualElement
{
    private VisualTreeAsset _rowAsset;
    public Ability Ability { get; private set; }

    public AbilityRow(Ability abilityData)
    {
        //This should use the addressables system in a real project and would not work in a built project.
        _rowAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/GDR/UserInterface/AbilityRow.uxml");
        Add(_rowAsset.CloneTree());

        this.Q<Label>("Title").text = abilityData.Name;
        this.Q<Label>("Ability_Description").text = abilityData.Description;
        this.Q<VisualElement>("Icon").style.backgroundImage = new StyleBackground(abilityData.Image);

        Ability = abilityData;

        this.RegisterCallback<MouseDownEvent>((e) => 
        {
            ToggleInClassList("selected");
        });

    }

}
