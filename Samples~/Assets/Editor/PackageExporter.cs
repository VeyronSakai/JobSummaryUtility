using System.Linq;
using UnityEditor;

namespace Editor
{
    public class PackageExporter
    {
        private const string PackagePath = "Packages/com.veyron-sakai.job-summary-utility/";
        private const string ExportPath = "./JobSummaryUtility.unitypackage";

        [MenuItem("Tools/ExportPackage")]
        private static void Export()
        {
            var assetPathNames = AssetDatabase.FindAssets("", new[] { PackagePath })
                .Select(AssetDatabase.GUIDToAssetPath)
                .ToArray();

            AssetDatabase.ExportPackage(
                assetPathNames,
                ExportPath,
                ExportPackageOptions.IncludeDependencies);
        }
    }
}