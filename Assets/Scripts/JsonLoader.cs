using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class JsonLoader
{
    public struct TranslatedContent
    {
        public int LanguageId;
        public string LanguageName;
        public Topic[] Topics;
    }

    public struct Topic
    {
        public string Name;
        public Media[] Media;
    }

    public struct Media
    {
        public string Name;
        public Photo[] Photos;
        public string FilePath;
    }

    public struct Photo
    {
        public string Path;
        public string Name;
    }

    public static TranslatedContent LoadJson(string fileName)
    {
        TextAsset jsonFile = Resources.Load<TextAsset>(fileName);
        string jsonString = jsonFile.text;        
        TranslatedContent data = JsonConvert.DeserializeObject<TranslatedContent>(jsonString);
        return data;
    }
}
