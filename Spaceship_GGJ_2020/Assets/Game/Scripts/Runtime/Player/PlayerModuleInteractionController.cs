using System;
using UnityEngine;

public class PlayerModuleInteractionController : MonoBehaviour
{
    public IShipModule CurrentModule { get; private set; }

    public void UseItemOnModule()
    {
        throw new NotImplementedException();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IShipModule module))
        {
            if (CurrentModule != null)
                Debug.LogWarning("Overridding active module!");
            CurrentModule = module;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IShipModule module))
        {
            if (module != CurrentModule)
            {
                Debug.LogWarning("Trying to remove module that is not current!");
                return;
            }

            CurrentModule = null;
        }
    }

    //private void OnGUI()
    //{
    //    float offset = 40 + 60;
    //    GUI.Label(new Rect(20, 20 + offset, 400, 20), $"Module: {CurrentModule?.Name}");
    //}
}