using System;
using UnityEngine;

public class PlayerModuleInteractionController : MonoBehaviour
{
    private IShipModule currentModule;

    public IShipModule CurrentModule => currentModule;

    public void UseItemOnModule()
    {
        throw new NotImplementedException();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IShipModule module))
        {
            if (currentModule != null)
                Debug.LogWarning("Overridding active module!");
            currentModule = module;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IShipModule module))
        {
            if (module != currentModule)
            {
                Debug.LogWarning("Trying to remove module that is not current!");
                return;
            }

            currentModule = null;
        }
    }
}