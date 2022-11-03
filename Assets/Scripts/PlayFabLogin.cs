using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayFabLogin : MonoBehaviour
{
    [Header("Login")]
    private string userEmailLogin;
    private string userPasswordLogin;

    public void Start()
    {
        // Tarkistetaan ettei TitleID ole tyhjä eli null
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            // Lisää oma TitleID,jonka löydät PlayFab pilven GameManagerista
            PlayFabSettings.TitleId = "AFD06";
        }

        // API-kutsu (GET) sähköpostikirjautumista varten

        var request = new LoginWithEmailAddressRequest { Email = userEmailLogin, Password = userPasswordLogin };

        // Tässä suoritetaan API-kutsu pilvessä olevalla palvelimelle
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
    }
    // Tämä metodi suoritetaan jos Loggaus onnistuu
    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
        
        SceneManager.LoadScene("GameScene");
    }
    // Tämä metodi suoritetaan jos loggaus epäonnistuu
    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your first API call. :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }

    // Tallentaa Login-lomakkeelta tulleen salasanan
    public void SavePasswordLogin(string password)
    {
        userPasswordLogin = password;
    }

    // Tallentaa Login-lomakkeelta tulleen sähköpostin
    public void SaveEmailLogin(string email)
    {
        userEmailLogin = email;
    }

    // Login -painikkeen koodi eli tässä tehdään API-kutsu PlayFab pilveen ja selvitetään onko käyttäjä olemassa
    public void LoginButton()
    {
        // API-kutsu (GET) sähköpostikirjautumista varten
        var request = new LoginWithEmailAddressRequest { Email = userEmailLogin, Password = userPasswordLogin };

        // Tässä suoritetaan API-kutsu pilvessä olevalla palvelimelle
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
    }

}