using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace Yoshida.Plugins
{
    public class FolderTemplateCreate
    {
        /// <summary>
        /// 右クリックしたフォルダのPathでFolderCreateメソッドを呼ぶ
        /// </summary>
        [MenuItem("Assets/Create/FolderCreate", priority = 21)]
        public static void GameObjectMenuItem()
        {
            // 現在右クリックで表示されたGUIなどのインスタンスIDを取得し
            var instanceID = Selection.activeInstanceID;
            // プロジェクトウィンドウ以外で指定した時
            if (instanceID == 0)
            {
                Debug.LogWarning("フォルダを作成したい場所をプロジェクトウィンドウ上で指定して下さい");
                return;
            }
            // そのインスタンスIDのPathを入手する
            var path = AssetDatabase.GetAssetPath(instanceID);
            Debug.Log($"Folder Create : {path}");
            FolderCreate(path);
        }

        /// <summary>
        /// テンプレートに登録したフォルダ名のフォルダを自動生成する
        /// </summary>
        /// <param name="path">フォルダを作成する場所</param>
        private static void FolderCreate(string path)
        {
            // 生成したいフォルダの名前を入れる
            var names = new List<string>
            {
                "Audios",
                "Images",
                "Prefabs",
                "Scripts"
            };

            foreach (var name in names)
            {
                // 生成したいフォルダが存在しないとき、フォルダ作成
                if (!AssetDatabase.IsValidFolder(path + '/' + name))
                {
                    AssetDatabase.CreateFolder(path, name);
                    AssetDatabase.Refresh();
                }
            }
        }
    }
}