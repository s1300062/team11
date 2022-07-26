using UnityEngine;
using UnityEditor;

namespace Unity.VisualScripting
{
    internal class ProjectSettingsProviderView : SettingsProvider
    {
        private const string Path = "Project/Visual Scripting";
        private const string Title = "Visual Scripting";
        private const string TitleGroup = "Generate Nodes";

        private AssemblyOptionsSettings _assemblyOptionsSettings;
        private TypeOptionsSettings _typeOptionsSettings;
        private CustomPropertyProviderSettings _customPropertyProviderSettings;
        private BackupSettings _backupSettings;
        private ScriptReferenceResolverSettings _scriptReferenceResolverSettings;

        private BoltCoreConfiguration _vsCoreConfig = null;

        public ProjectSettingsProviderView() : base(Path, SettingsScope.Project)
        {
            label = Title;
            EditorTypeUtility.Initialize();
        }

        private void CreateOptionsIfNeeded()
        {
            _assemblyOptionsSettings ??= new AssemblyOptionsSettings(_vsCoreConfig);
            _typeOptionsSettings ??= new TypeOptionsSettings(_vsCoreConfig);
            _customPropertyProviderSettings ??= new CustomPropertyProviderSettings();
            _backupSettings ??= new BackupSettings();
            _scriptReferenceResolverSettings ??= new ScriptReferenceResolverSettings();
        }

        private void EnsureConfig()
        {
            if (_vsCoreConfig != null)
                return;

            if (BoltCore.instance == null || BoltCore.Configuration == null)
            {
                UnityAPI.Initialize();
                PluginContainer.Initialize();
            }

            _vsCoreConfig = BoltCore.Configuration;
        }

        public override void OnGUI(string searchContext)
        {
            EnsureConfig();

            GUILayout.Space(5f);

            GUILayout.Label(TitleGroup, EditorStyles.boldLabel);

            GUILayout.Space(10f);

            // happens when opening unity with the settings window already opened. there's a delay until the singleton is assigned
            if (_vsCoreConfig == null)
            {
                EditorGUILayout.HelpBox("Loading Configuration...", MessageType.Info);
                return;
            }

            CreateOptionsIfNeeded();

            _typeOptionsSettings.OnGUI();

            GUILayout.Space(10f);

            _assemblyOptionsSettings.OnGUI();

            GUILayout.Space(10f);

            _customPropertyProviderSettings.OnGUI();

            GUILayout.Space(10f);

            _backupSettings.OnGUI();

            GUILayout.Space(10f);

            _scriptReferenceResolverSettings.OnGUI();
        }
    }
}
