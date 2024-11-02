using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class UserRegistor : MonoBehaviour
{
    [Header("Sing In page")]
    public TMP_InputField nameInput;
    public TMP_InputField passwordInput;
    public TMP_InputField emailInput;
    public GameObject SingInPage;
    public GameObject successPage;

    [Header("Sing In error")]
    public GameObject passwordError;
    public GameObject emailError;
    public GameObject nameError;
    public GameObject inputError;

    [Header("Log In page")]
    public TMP_InputField Usernamelogin;
    public TMP_InputField passwordLogin;
    public GameObject LogInPage;
    public GameObject loginError;


    
    [SerializeField]
    private DataManager dataManager;
    public int sceneHome;

    private void Awake()
    {
        dataManager = FindFirstObjectByType<DataManager>();
    }

    public void RegistorSubmit()
    {
        if (!string.IsNullOrEmpty(nameInput.text)&&!string.IsNullOrEmpty(emailInput.text))
        {
            inputError.SetActive(false);
            if (passwordInput.text.Length >= 8)
            {
                passwordError.SetActive(false);
                if (emailInput.text.Contains("@")){
                    emailError.SetActive(false);
                    StartCoroutine(Registor(ReturnValue =>
                    {
                        if (ReturnValue == 1)
                        {
                            nameError.SetActive(false);
                            successPage.SetActive(true);
                            SingInPage.SetActive(false);
                        }
                        else if(ReturnValue == -1) 
                        {
                            nameError.SetActive(true);
                        }
                    }));
                }
                else { 
                    emailError.SetActive(true) ;
                }

            }else passwordError.SetActive(true) ;

        }
        else inputError.SetActive(true) ;

        
    }

    public void LogIn()
    {
        if (!string.IsNullOrEmpty(Usernamelogin.text) && !string.IsNullOrEmpty(passwordLogin.text))
        {
            StartCoroutine(dataManager.loginUser(Usernamelogin.text, passwordLogin.text, returnValue =>
            {
                if(returnValue == 1)
                {
                    loginError.SetActive(false);
                    print(DataManager.user.ToString()+" Wow");
                    SceneManager.LoadScene(sceneHome);
                }
                else
                {
                    print("log in faile");
                    loginError.SetActive(true);
                }
            }));
        }else loginError.SetActive(true) ;
    }


    public IEnumerator Registor(System.Action<int> callback = null)
    {
        WWWForm form = new WWWForm();
        form.AddField("name",nameInput.text);
        form.AddField("password", passwordInput.text);
        form.AddField("email", emailInput.text);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/Readly_Pj/Registor.php", form))
        {
            yield return www.SendWebRequest();


            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string tex = www.downloadHandler.text;
                if (tex != null) { 
                    if(tex.Equals("success"))
                    {
                        print("create user success");
                        if (callback != null) callback.Invoke(1);
                    }
                    else if(tex.Equals("3: Name already exists"))
                    {
                        if (callback != null) callback.Invoke(-1);
                    }
                    print(tex);
                }

            }
        }
    }
    // Start is called before the first frame update

}
