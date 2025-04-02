using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleScriptManager : MonoBehaviour
{
    [Tooltip("Список объектов, наследумые SampleScript")]
    [SerializeField] 
    private List<SampleScript> scripts = new List<SampleScript>();

    [ContextMenu("Выполнить все скрипты")]
    public void ExecuteAll()
    {
        foreach (var script in scripts)
        {
            script.Use();
        }
    }

    public void AddScript(SampleScript script)
    {
        if (!scripts.Contains(script))
        {
            scripts.Add(script);
        }
    }
}
