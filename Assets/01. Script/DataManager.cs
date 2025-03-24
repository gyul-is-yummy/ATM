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
        File.WriteAllText(Application.persistentDataPath + $"/UserData/{data.userName}.txt", saveData);

        Debug.Log("������ �����");
        Debug.Log(Application.persistentDataPath);
    }

    public static UserData Load(string userName)
    {
        //����� �����Ͱ� ������ �⺻ �����͸� ��� ������
        if (!File.Exists(Application.persistentDataPath + $"/UserData/{userName}.txt"))
        {
            Debug.Log($"����� {userName}�� �����Ͱ� �����ϴ�! �⺻ �����͸� �����մϴ�.");

            return new UserData("������", 100000, 50000);
        }

        string loadData = File.ReadAllText(Application.persistentDataPath + $"/UserData/{userName}.txt");

        Debug.Log($"����� {userName} ������ �ε��");
        return JsonUtility.FromJson<UserData>(loadData);
    }
}