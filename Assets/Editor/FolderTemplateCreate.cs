using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace Yoshida.Plugins
{
    public class FolderTemplateCreate
    {
        /// <summary>
        /// �E�N���b�N�����t�H���_��Path��FolderCreate���\�b�h���Ă�
        /// </summary>
        [MenuItem("Assets/Create/FolderCreate", priority = 21)]
        public static void GameObjectMenuItem()
        {
            // ���݉E�N���b�N�ŕ\�����ꂽGUI�Ȃǂ̃C���X�^���XID���擾��
            var instanceID = Selection.activeInstanceID;
            // ���̃C���X�^���XID��Path����肷��
            var path = AssetDatabase.GetAssetPath(instanceID);
            Debug.Log($"Folder Create : {path}");
            FolderCreate(path);
        }

        /// <summary>
        /// �e���v���[�g�ɓo�^�����t�H���_���̃t�H���_��������������
        /// </summary>
        /// <param name="path">�t�H���_���쐬����ꏊ</param>
        private static void FolderCreate(string path)
        {
            // �����������t�H���_�̖��O������
            var names = new List<string>
            {
                "Audios",
                "Images",
                "Prefabs",
                "Scripts"
            };

            foreach (var name in names)
            {
                // �����������t�H���_�����݂��Ȃ��Ƃ��A�t�H���_�쐬
                if (!AssetDatabase.IsValidFolder(path + '/' + name))
                {
                    AssetDatabase.CreateFolder(path, name);
                    AssetDatabase.Refresh();
                }
            }
        }
    }
}