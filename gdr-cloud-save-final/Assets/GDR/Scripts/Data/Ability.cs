using UnityEngine;

[CreateAssetMenu(fileName = "NewAbility", menuName = "Data/Ability")]
public class Ability : ScriptableObject
{
    public string Name;
    public Sprite Image;
    public string Description;

}
