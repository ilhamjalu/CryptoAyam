using PlayFab.PfEditor.EditorModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginSystem : MonoBehaviour
{
    [Header("Sign Up")]
    [SerializeField] TMP_InputField signUpUsername;
    [SerializeField] TMP_InputField signUpPassword;
    [SerializeField] TMP_InputField signUpEmail;

    [Header("Sign In")]
    [SerializeField] TMP_InputField signInEmail;
    [SerializeField] TMP_InputField signInPassword;

    [Header("Recovery")]
    [SerializeField] TMP_InputField recoverEmail;

    [Header("Password")]
    [SerializeField] List<Sprite> passwordAssets;

    [Header("Notification")]
    [SerializeField] GameObject successPanel;
    [SerializeField] GameObject failedPanel;
    [SerializeField] TextMeshProUGUI failedText;
    [SerializeField] TextMeshProUGUI successText;

    [Header("Panel")]
    [SerializeField] GameObject panelRegister;
    [SerializeField] GameObject panelLogin;
    [SerializeField] GameObject panelForgotPassword;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RegisterUser()
    {
        var request = new RegisterPlayFabUserRequest
        {
            DisplayName = signUpUsername.text,
            Password = signUpPassword.text,
            Email = signUpEmail.text,

            RequireBothUsernameAndEmail = false
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    public void Login()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = signInEmail.text,
            Password = signInPassword.text,
        };

        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }

    public void RecoverUser()
    {
        var request = new SendAccountRecoveryEmailRequest 
        { 
            Email = recoverEmail .text, 
            TitleId = "762E0"
        };

        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnRecoverSuccess, OnError);

    }

    private void OnRecoverSuccess(SendAccountRecoveryEmailResult result)
    {
        Debug.Log(result);

        successPanel.SetActive(true);
        successText.text = "email has been sent";

        panelForgotPassword.SetActive(false);
    }

    private void OnLoginSuccess(PlayFab.ClientModels.LoginResult result)
    {
        Debug.Log(result);
        SceneManager.LoadScene(1);
    }

    private void OnError(PlayFab.PlayFabError error)
    {
        Debug.Log(error.ErrorMessage);
        failedPanel.SetActive(true);
        failedText.text = error.ErrorMessage;
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("User Register Success");

        successPanel.SetActive(true);
        successText.text = "CONGRATULATION! YOUR ACCOUNT HAS BEES SUCCESFULLY CREATED.";

        panelRegister.SetActive(false);
    }
}
