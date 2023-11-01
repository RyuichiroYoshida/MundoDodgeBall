using UnityEngine;
using UnityEditor;
using System.IO;

namespace Yoshida.Plugins
{
    public class FolderTemplateCreate : MonoBehaviour
    {
        [MenuItem("Assets/Create/FolderCreate", priority = 21)]
        public static void GameObjectMenuItem()
        {
            print("FolderCreate");
            FolderPath();
        }

        static void FolderPath()
        {
            var temp = new string[4]
            {
                "Scripts", "Prefabs", "Images", "Audios"
            };
            for (var i = 0; i < temp.Length; i++)
            {
                if (!Directory.Exists("Assets/" + temp[i]))
                {
                    Directory.CreateDirectory("Assets/" + temp[i]);
                    AssetDatabase.Refresh();
                }
            }
        }
    }
}