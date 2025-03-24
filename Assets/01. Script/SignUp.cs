using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SignUp : MonoBehaviour
{
    //기본 현금 10만원 / 예금 5만원

    //public GameObject popupSignUp;

    public InputField idField;
    public InputField nameField;
    public InputField pwField;
    public InputField confirmField;

    public Text guideText;

    private InputField[] signUpFields;

    public void OnClickSignUpBtn()
    {
        if(InputCheck())
        {
            UserData newUser = new UserData(nameField.text, 100000, 50000, idField.text, pwField.text);
            DataManager.Save(newUser);

            GameManager.Instance.popupBank.ErrorPopup("가입이 완료되었습니다.");
            this.gameObject.SetActive(false);
        }
        else
        {
            //에러창을 띄운다.
            GameManager.Instance.popupBank.ErrorPopup("정보를 확인해주세요.");
        }

        
    }

    public bool InputCheck()
    {
        signUpFields = new InputField[4] { idField, nameField, pwField, confirmField };
        for (int i = 0; i < signUpFields.Length; i++)
        {
            //만약 아무것도 입력하지 않았거나, 입력값에 공백이 포함되어 있다면
            if (signUpFields[i].text.Length <= 0 || signUpFields[i].text.Contains(" "))
            {
                Debug.Log($"{signUpFields[i].name}을 확인해주세요.");
                guideText.text = $"{signUpFields[i].name}을 확인해주세요.";
                return false;
            }
        }

        if (pwField.text != confirmField.text)
        {
            guideText.text = "PS가 일치하지 않습니다.";
            return false;
        }
            
        return true;      
    }
}
