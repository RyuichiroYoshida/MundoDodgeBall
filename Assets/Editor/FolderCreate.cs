using UnityEngine;
using UnityEditor;

namespace Yoshida.Plugins
{
    public class FolderCreate : MonoBehaviour
    {
        [MenuItem("GameObject/FolderCreate", priority = 21)]
        public static void GameObjectMenuItem()
        {
            print("FolderCreate");
        }
    }
}