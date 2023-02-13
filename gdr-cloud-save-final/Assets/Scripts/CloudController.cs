using Unity.Services.CloudSave;
using Unity.Services.Core;
using Unity.Services.Authentication;
using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json;
using Unity.Services.CloudCode;

public class CloudController : MonoBehaviour
{
    public enum CloudSaveKeys
    {
        Name,
        Class,
        Abilities,
        Experience
    }

    public Player PlayerDetails;

    async void Start()
    {
        var options = new InitializationOptions();
        options.SetOption("com.unity.services.core.environment-name", "integration");

        await UnityServices.InitializeAsync(options);
        await AuthenticationService.Instance.SignInAnonymouslyAsync();

        Debug.Log(AuthenticationService.Instance.IsAuthorized 
            ? "Sign in Successful" 
            : "Issue Authenticating. Are you connected to the internet?");

        LoadPlayerData();

    }

    public async void LoadPlayerData()
    {
        if (!AuthenticationService.Instance.IsAuthorized)
        {
            return;
        }

        HashSet<string> keys = new HashSet<string> 
        { 
            CloudSaveKeys.Name.ToString(), 
            CloudSaveKeys.Experience.ToString(), 
            CloudSaveKeys.Abilities.ToString(), 
            CloudSaveKeys.Class.ToString() 
        };

        Dictionary<string, string> data = await CloudSaveService.Instance.Data.LoadAsync(keys);

        if (!int.TryParse(data[CloudSaveKeys.Experience.ToString()], out int experience))
        {
            //Put error handling logic here as the value can't be parsed
        }

        PlayerDetails = new Player()
        {
            Name = data[CloudSaveKeys.Name.ToString()],
            Class = data[CloudSaveKeys.Class.ToString()],
            Experience = experience,
            Abilities = JsonConvert.DeserializeObject<string[]>(data[CloudSaveKeys.Abilities.ToString()]),
        };
    }

    public static async void SavePlayerData(Player player)
    {

        var data = new Dictionary<string, object>();
        var abilities = JsonConvert.SerializeObject(player.Abilities);

        data.Add(CloudSaveKeys.Name.ToString(), player.Name);
        data.Add(CloudSaveKeys.Class.ToString(), player.Class);
        data.Add(CloudSaveKeys.Abilities.ToString(), abilities);

        var response = await CloudCodeService.Instance.CallEndpointAsync<bool>("CreateNewPlayer", data);

        Debug.Log($"{response}");

    }
}
