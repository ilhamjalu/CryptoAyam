using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;
using System;

public class ProfileScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI displayName;

    // Start is called before the first frame update
    void Start()
    {
        SetDisplayName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDisplayName()
    {
        PlayFabClientAPI.GetPlayerProfile(new GetPlayerProfileRequest()
        {
            ProfileConstraints = new PlayerProfileViewConstraints()
            {
                ShowDisplayName = true
            }
        },
        result => displayName.SetText(result.PlayerProfile.DisplayName),
        error => Debug.LogError(error.GenerateErrorReport()));
    }
}
