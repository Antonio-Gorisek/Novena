using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Language {
    public int LanguageId;
    public string LanguageName;
    public Topic[] Topics;
}

[System.Serializable]
public class Topic {
    public string Name;
    public Media[] Media;
}

[System.Serializable]
public class Media {
    public string Name;
    public Photo[] Photos;
    public string FilePath;
}

[System.Serializable]
public class Photo {
    public string Path;
    public string Name;
}

public class JsonManager : MonoBehaviour {
    private static Language data;
    public static JsonManager instance;
    private string _language = "Data_Hrvatski";

    public static Language LoadJson(string fileName) {
        TextAsset jsonFile = Resources.Load<TextAsset>(fileName);
        if (jsonFile == null) {
            Debug.LogError("JSON file not found: " + fileName);
            return default(Language);
        }

        string jsonString = jsonFile.text;

        Language data = JsonUtility.FromJson<Language>(jsonString);
        return data;
    }

    private void Awake() {
        instance = this;
        data = LoadJson(_language);
    }

    public int GetLaguageID() { return data.LanguageId; }

    public string GetLaguageName() { return data.LanguageName; }

    public int GetTopicLenght() { return data.Topics.Length; }

    public void SelectLanguage(string value) {
        _language = value;
        data = LoadJson(value);
    }

    public List<string> GetTopicNames() {
        List<string> topicNames = new List<string>();
        foreach (Topic t in data.Topics) {
            topicNames.Add(t.Name);
        }
        return topicNames;
    }

    public List<string> GetMediaData(string main_name) {
        List<string> mediaData = new List<string>();
        foreach (Topic topic in data.Topics) {
            if (topic.Name == main_name) {
                foreach (Media media in topic.Media) {
                    if (media.Name == "Gallery") {
                        foreach (Photo photo in media.Photos) {
                            mediaData.Add(photo.Path);
                        }
                    }
                }
            }
        }
        return mediaData;
    }

    public List<string> GetAudioData(string main_name) {
        List<string> audioData = new List<string>();
        foreach (Topic topic in data.Topics) {
            if (topic.Name == main_name) {
                foreach (Media media in topic.Media) {
                    if (media.Name == "Audio") {
                        audioData.Add(media.FilePath);
                    }
                }
            }
        }
        return audioData;
    }
}
