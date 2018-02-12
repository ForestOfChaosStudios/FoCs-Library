using UnityEditor;

namespace ForestOfChaosLib.Editor
{
	public static class MenuItems
	{
		[MenuItem(FileStrings._FORESTOFCHAOS_ + FileStrings.FOLDERS_ + "Create All Folders")]
		public static void CreateAllFolders()
		{
			CreateNormalFolders();
			CreateResourcesFolder();
			CreateStreamingAssetsFolder();
			CreatePluginsFolder();
		}

		[MenuItem(FileStrings._FORESTOFCHAOS_ + FileStrings.FOLDERS_ + "Create Normal Folders")]
		public static void CreateNormalFolders()
		{
			CreateScriptFolder();
			CreateScenesFolder();
			CreateArtFolders();
			CreatePrefabsFolder();
		}

		[MenuItem(FileStrings._FORESTOFCHAOS_ + FileStrings.FOLDERS_ + "Normal Folders/" + FileStrings.SCENES)]
		private static void CreateScenesFolder()
		{
			EditorHelpers.CreateAndCheckFolder(FileStrings.ASSETS, FileStrings.SCENES);
		}

		[MenuItem(FileStrings._FORESTOFCHAOS_ + FileStrings.FOLDERS_ + "Normal Folders/" + FileStrings.PREFABS)]
		private static void CreatePrefabsFolder()
		{
			EditorHelpers.CreateAndCheckFolder(FileStrings.ASSETS, FileStrings.PREFABS);
		}

		[MenuItem(FileStrings._FORESTOFCHAOS_ + FileStrings.FOLDERS_ + "Normal Folders/Art")]
		private static void CreateArtFolders()
		{
			EditorHelpers.CreateAndCheckFolder(FileStrings.ASSETS, FileStrings.ART);
			EditorHelpers.CreateAndCheckFolder(FileStrings.ASSETS_ART, FileStrings.MODELS);
			EditorHelpers.CreateAndCheckFolder(FileStrings.ASSETS_ART, FileStrings.TEXTURES);
			EditorHelpers.CreateAndCheckFolder(FileStrings.ASSETS_ART, FileStrings.MATERIALS);
		}

		[MenuItem(FileStrings._FORESTOFCHAOS_ + FileStrings.FOLDERS_ + "Normal Folders/Scripts")]
		public static void CreateScriptFolder()
		{
			EditorHelpers.CreateAndCheckFolder(FileStrings.ASSETS, FileStrings.SCRIPTS);
		}

		[MenuItem(FileStrings._FORESTOFCHAOS_ + FileStrings.FOLDERS_ + "Create Resource Folder")]
		public static void CreateResourcesFolder()
		{
			EditorHelpers.CreateAndCheckFolder(FileStrings.ASSETS, FileStrings.RESOURCES);
		}

		[MenuItem(FileStrings._FORESTOFCHAOS_ + FileStrings.FOLDERS_ + "Create StreamingAssets Folder")]
		public static void CreateStreamingAssetsFolder()
		{
			EditorHelpers.CreateAndCheckFolder(FileStrings.ASSETS, FileStrings.STREAMINGASSETS);
		}

		[MenuItem(FileStrings._FORESTOFCHAOS_ + FileStrings.FOLDERS_ + "Create Plugins Folder")]
		public static void CreatePluginsFolder()
		{
			EditorHelpers.CreateAndCheckFolder(FileStrings.ASSETS, FileStrings.PLUGINS);
		}

		[MenuItem(FileStrings._FORESTOFCHAOS_ + FileStrings.FOLDERS_ + "Create Editor Resources Folder")]
		public static void CreateEditorResourcesFolder()
		{
			EditorHelpers.CreateAndCheckFolder(FileStrings.ASSETS, FileStrings.EDITOR_RESOURCES);
		}
	}

	/// <summary>
	/// The strings contained within this class are used for filepaths,
	/// The variable names are a exact for underscores "_" it means a "/"
	/// </summary>
	public static class FileStrings
	{
		public const string FORESTOFCHAOS = "ForestOfChaos";
		public const string FOLDERS = "Folders";
		public const string ASSETS = "Assets";
		public const string GENERATED = "Generated";
		public const string ENUM = "Enum";
		public const string RAWDATA = "RawData";
		public const string STATICCLASS = "StaticClasses";

		public const string SCRIPTS = "Scripts";
		public const string ART = "Art";
		public const string MODELS = "Models";
		public const string PREFABS = "Prefabs";
		public const string MATERIALS = "Materials";
		public const string TEXTURES = "Textures";
		public const string SCENES = "Scenes";
		public const string SYSTEMS = "Systems";
		public const string TOOLS = "Tools";

		public const string PLUGINS = "Plugins";
		public const string STREAMINGASSETS = "StreamingAssets";
		public const string RESOURCES = "Resources";
		public const string EDITOR_RESOURCES = "Editor Resources";

		public const string FOCS_EXTENSION = ".FoCs";

		public const string S = "/";
		public const string SPLIT = S;

		public const string SCRIPTS_FILE_EXTENSION = ".cs";

		public const string FORESTOFCHAOS_ = FORESTOFCHAOS + S;
		public const string FORESTOFCHAOS_SYSTEMS_ = FORESTOFCHAOS + S + SYSTEMS + S;
		public const string FORESTOFCHAOS_TOOLS_ = FORESTOFCHAOS + S + TOOLS + S;
		public const string _FORESTOFCHAOS_ = S + FORESTOFCHAOS + S;
		public const string FOLDERS_ = FOLDERS + S;
		public const string ASSETS_ART = ASSETS + S + ART;
		public const string ASSETS_GENERATED = ASSETS + S + GENERATED;
		public const string ASSETS_GENERATED_SCRIPTS = ASSETS_GENERATED + S + SCRIPTS;
		public const string ASSETS_GENERATED_ENUM = ASSETS_GENERATED + S + ENUM;
		public const string ASSETS_GENERATED_STATICCLASS = ASSETS_GENERATED + S + STATICCLASS;

		public const string ASSETS_PLUGINS_GENERATED = ASSETS + S + PLUGINS + S + GENERATED;
		public const string ASSETS_PLUGINS_GENERATED_SCRIPTS = ASSETS_PLUGINS_GENERATED + S + SCRIPTS;
		public const string ASSETS_PLUGINS_GENERATED_ENUM = ASSETS_PLUGINS_GENERATED + S + ENUM;
		public const string ASSETS_PLUGINS_GENERATED_STATICCLASS = ASSETS_PLUGINS_GENERATED + S + STATICCLASS;

		public const string ASSETS_GENERATED_RAWDATA = ASSETS_GENERATED + S + RAWDATA;
		public const string ASSETS_SCRIPTS = ASSETS + S + SCRIPTS;
		public const string ASSETS_PLUGINS = ASSETS + S + PLUGINS;
		public const string ASSETS_STREAMINGASSETS = ASSETS + S + STREAMINGASSETS;
		public const string ASSETS_RESOURCES = ASSETS + S + RESOURCES;
	}
}