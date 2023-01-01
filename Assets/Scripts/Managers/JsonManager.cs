using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static JsonLoader;

public class JsonManager : MonoBehaviour
{
    private void Start()
    {
        TranslatedContent data = JsonLoader.LoadJson("example");

        Debug.Log(data.LanguageId);
        Debug.Log(data.LanguageName);

        foreach (Topic topic in data.Topics)
        {
            Debug.Log(topic.Name);

            foreach (Media media in topic.Media)
            {
                Debug.Log(media.Name);

                if (media.Name == "Gallery")
                {
                    foreach (Photo photo in media.Photos)
                    {
                        Debug.Log(photo.Path);
                        Debug.Log(photo.Name);
                    }
                }
                else
                {
                    Debug.Log(media.FilePath);
                }
            }
        }
    }
}
