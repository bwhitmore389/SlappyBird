
using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    //Screen object variables
    [Header("UI")]
    public GameObject loginUI;
    public GameObject registerUI;

    //Login variables
    [Header("Login")]
    public TMP_InputField emailLoginField;
    public TMP_InputField passwordLoginField;


    //Register variables
    [Header("Register")]
    public TMP_InputField usernameRegisterField;
    public TMP_InputField emailRegisterField;
    public TMP_InputField passwordRegisterField;
    public TMP_InputField passwordRegisterVerifyField;

    private void StartNewGame()
    {
        ScenesManager.Instance.LoadNewGame();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }

    }

    //Functions to change the login screen UI
    public void LoginScreen() //Back button
    {
        loginUI.SetActive(true);
        registerUI.SetActive(false);
        ClearRegisterFields();
    }
    public void RegisterScreen() // Regester button
    {
        loginUI.SetActive(false);
        registerUI.SetActive(true);
        ClearLoginFields();
    }

    public void NewGameScreen() // Login button
    {
        loginUI.SetActive(false);
        registerUI.SetActive(false);
    }

    public void ClearLoginFields()
    {
        emailLoginField.text = "";
        passwordLoginField.text = "";
    }

    public void ClearRegisterFields()
    {
        usernameRegisterField.text = "";
        emailRegisterField.text = "";
        passwordRegisterField.text = "";
        passwordRegisterVerifyField.text = "";

    }

}
