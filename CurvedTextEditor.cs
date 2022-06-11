using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CurvedText))]
public class CurvedTextEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
	}
}
#endif