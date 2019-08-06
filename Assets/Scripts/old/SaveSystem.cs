using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveVariables(Variables variables)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/variables.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        VariablesData data = new VariablesData(variables);

        formatter.Serialize(stream, data);
        stream.Close();


    }

    public static VariablesData LoadVariables()
    {
        string path = Application.persistentDataPath + "/variables.fun";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            VariablesData data = formatter.Deserialize(stream) as VariablesData;
            stream.Close();

            return data;


        }else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }

 

}
