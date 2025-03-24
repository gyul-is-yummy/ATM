using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SignUp : MonoBehaviour
{
    //�⺻ ���� 10���� / ���� 5����

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

            GameManager.Instance.popupBank.ErrorPopup("������ �Ϸ�Ǿ����ϴ�.");
            this.gameObject.SetActive(false);
        }
        else
        {
            //����â�� ����.
            GameManager.Instance.popupBank.ErrorPopup("������ Ȯ�����ּ���.");
        }

        
    }

    public bool InputCheck()
    {
        signUpFields = new InputField[4] { idField, nameField, pwField, confirmField };
        for (int i = 0; i < signUpFields.Length; i++)
        {
            //���� �ƹ��͵� �Է����� �ʾҰų�, �Է°��� ������ ���ԵǾ� �ִٸ�
            if (signUpFields[i].text.Length <= 0 || signUpFields[i].text.Contains(" "))
            {
                Debug.Log($"{signUpFields[i].name}�� Ȯ�����ּ���.");
                guideText.text = $"{signUpFields[i].name}�� Ȯ�����ּ���.";
                return false;
            }
        }

        if (pwField.text != confirmField.text)
        {
            guideText.text = "PS�� ��ġ���� �ʽ��ϴ�.";
            return false;
        }
            
        return true;      
    }
}
