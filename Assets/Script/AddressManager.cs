using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class AddressManager : MonoBehaviour
{
    private string name;
    private string phone;
    private string address;

    public TMP_InputField nameInputField;
    public TMP_InputField phoneInputField;
    public TMP_InputField addressInputField;

    public TMP_Text toPayName;
    public TMP_Text toPayPhone;
    public TMP_Text toPayAddress;
    public TMP_Text errorMessage;

    public GameObject popupPage;
    public GameObject toPayPage;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Phone
    {
        get { return phone; }
        set { phone = value; }
    }

    public string Address
    {
        get { return address; }
        set { address = value; }
    }

    void Start()
    {
        
        errorMessage.gameObject.SetActive(false);
    }

    public void SendAddressToPay()
{
    errorMessage.gameObject.SetActive(false);

    if (string.IsNullOrEmpty(nameInputField.text) || string.IsNullOrEmpty(phoneInputField.text) || string.IsNullOrEmpty(addressInputField.text))
    {
        errorMessage.text = "กรุณากรอกข้อมูลให้ครบถ้วน!";
        StartCoroutine(ShowErrorMessage());
        return;
    }

    if (!Regex.IsMatch(nameInputField.text, @"^[a-zA-Zก-๙\s]+$"))
    {
        errorMessage.text = "ชื่อจะต้องเป็นตัวอักษรเท่านั้น!";
        StartCoroutine(ShowErrorMessage());
        return;
    }

    if (!Regex.IsMatch(phoneInputField.text, @"^\d{10}$"))
    {
        errorMessage.text = "เบอร์โทรต้องมี 10 หลักและเป็นตัวเลขเท่านั้น!";
        StartCoroutine(ShowErrorMessage());
        return;
    }

    
    if (popupPage != null && toPayPage != null)
    {
        Name = nameInputField.text;
        Phone = phoneInputField.text;
        Address = addressInputField.text;

        toPayName.text = "ชื่อ: " + Name;
        toPayPhone.text = "เบอร์โทร: " + Phone;
        toPayAddress.text = "ที่อยู่: " + Address;

        popupPage.SetActive(false);
        toPayPage.SetActive(true);
        errorMessage.text = "";
    }
    else
    {
        Debug.LogError("popupPage หรือ toPayPage ไม่สามารถเข้าถึงได้ อาจถูกทำลายไปแล้ว");
    }
}

IEnumerator ShowErrorMessage()
{
    if (errorMessage != null)
    {
        errorMessage.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        errorMessage.gameObject.SetActive(false);
    }
}

}