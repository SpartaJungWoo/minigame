using System.IO;
using UnityEditor;

public class AssetBundleBuildManager
{
    [MenuItem("Mytool/AssetBundle Build")]

    public static void AssetBundleBuild()
    {
        string _directory = "./Bundle";

        if (Directory.Exists(_directory))
        {
            Directory.CreateDirectory(_directory);
        }

        BuildPipeline.BuildAssetBundles(_directory, BuildAssetBundleOptions.None, BuildTarget.Android);

        EditorUtility.DisplayDialog("에셋 번들 빌드", "에셋 번들 빌드를 완료했습니다.", "완료");
    }
}
