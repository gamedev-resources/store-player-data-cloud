using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UIElements;

public class CharacterCreationScreen : MonoBehaviour
{
    [SerializeField]
    private UIDocument _uiDocument;
    public List<Ability> Abilities = new List<Ability>();
    private List<Ability> _selectedAbilities = new List<Ability>();
    public bool CanSelectAbility() => _selectedAbilities.Count < 2;
    private TextField _playerName;

    // Start is called before the first frame update
    void Start()
    {
        _playerName = _uiDocument.rootVisualElement.Q<TextField>("PlayerName");

        _uiDocument.rootVisualElement.Q<Label>("Next").RegisterCallback<MouseDownEvent>(ConfirmButton_Clicked);
        var abilityContainer = _uiDocument.rootVisualElement.Q<VisualElement>("Abilities");

        foreach (var a in Abilities)
        {
            abilityContainer.Add(new AbilityRow(a, this));
        }
    }

    /// <summary>
    /// Handles keeping track of the selected abilities
    /// </summary>
    public void ToggleSelectedAbility(Ability ability)
    {
        if (_selectedAbilities.Contains(ability))
        {
            _selectedAbilities.Remove(ability);
        }
        else
        {
            _selectedAbilities.Add(ability);
        }
    }

    private void ConfirmButton_Clicked(MouseDownEvent e)
    {
        var playerDetails = new Player()
        {
            Name = _playerName.text,
            Class = "Archer",
            Abilities = _selectedAbilities.Select(x => x.Name).ToArray(),
            Experience = 1
        };

        CloudController.SavePlayerData(playerDetails);
    }
}
