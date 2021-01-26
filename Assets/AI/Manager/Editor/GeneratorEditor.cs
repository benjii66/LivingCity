using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(M_AiGenerator))]
public class GeneratorEditor : Editor
{
    M_AiGenerator agentGenerator = null;



    private void OnEnable()=>agentGenerator = (M_AiGenerator)target;

    private void OnSceneGUI()
    {
        Handles.BeginGUI();
        GUILayout.Window(0, new Rect(Screen.width * .01f, Screen.height * .6f, Screen.width * .3f, Screen.height * .3f), AiWindow, "Agent Status");
        Handles.EndGUI();
    }

    void AiWindow(int _id)
    {
        if (agentGenerator == null) return;
        GUILayout.Label($"Number of Agent : {agentGenerator.AgentNumber}");
        GUILayout.Space(8);
        GUILayout.Label($"Agent : {agentGenerator.Agent.otherTarget}");
        GUILayout.Toggle(agentGenerator.Agent.GotTarget, "Move on Target");
        GUILayout.Space(8);
        GUILayout.Label($"Agent 2 : {agentGenerator.Agent2.otherTarget}");
        GUILayout.Toggle(agentGenerator.Agent2.GotTarget, "Move on Target");
        GUILayout.Space(8);
        GUILayout.Label($"Agent 3 : {agentGenerator.Agent3.otherTarget}");
        GUILayout.Toggle(agentGenerator.Agent3.GotTarget, "Move on Target");
    }
}
