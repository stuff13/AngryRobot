using UnityEditor;
using System;
class BuildScript
{
	static void BuildWebPlayer ()
	{
		string buildTarget = System.Environment.GetEnvironmentVariable("UNITY_BUILD_TARGET");
		if (buildTarget == null || buildTarget.Length == 0) {
			throw new Exception("UNITY_BUILD_TARGET -system property not defined, aborting.");
		}
		
		string[] scenes = { "Assets/AngryBots.unity" /*, "Assets/Level1.unity", "Assets/Level2.unity", "Assets/Level3.unity"*/ };
		
		string error = BuildPipeline.BuildPlayer(scenes, buildTarget, BuildTarget.WebPlayerStreamed, BuildOptions.None);
		
		if (error != null && error.Length > 0) {
			throw new Exception("Build failed: " + error);
		}
	}
}