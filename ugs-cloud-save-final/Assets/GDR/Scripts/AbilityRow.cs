using UnityEditor;

using UnityEngine.UIElements;

public class AbilityRow : VisualElement
{
    //This should use the addressables system in a real project and would not work in a built project.
    VisualTreeAsset rowAsset;

    public AbilityRow()
    {
        rowAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/GDR/UserInterface/AbilityRow.uxml");
        Add(rowAsset.CloneTree());
    }

}
