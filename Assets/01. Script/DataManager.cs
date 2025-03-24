using UnityEngine;
using System.IO; // ���� ������� ���� ���ӽ����̽�

public static class DataManager
{
    public static void Save(UserData data)
    {
        // ���� ������ �������� ������ ����
        if (!Directory.Exists(Application.persistentDataPath + $"/UserData"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + $"/UserData");
        }

        // saveDataf JSON ���ڿ��� ��ȯ
        string saveData = JsonUtility.ToJson(data, true); // true: ���� ���� ����(�� �ٲ� ����)

        // JSON ���ڿ��� ���Ϸ� ����
        File.WriteAllText(Application.persistentDataPath + $"/UserData/{data.userID}.txt", saveData);

        Debug.Log("������ �����");
        Debug.Log(Application.persistentDataPath);
    }

    public static UserData Load(string id)
    {
        if (!File.Exists(Application.persistentDataPath + $"/UserData/{id}.txt"))
        {
            Debug.Log($"����� {id}�� �����Ͱ� �����ϴ�!");

            return null;
        }

        string loadData = File.ReadAllText(Application.persistentDataPath + $"/UserData/{id}.txt");

        Debug.Log($"����� {id} ������ �ε��");
        return JsonUtility.FromJson<UserData>(loadData);
    }
}