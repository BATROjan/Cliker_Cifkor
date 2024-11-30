using UnityEngine;

namespace UI
{
    public interface IUIRoot
    {
        ActivateContainer ActivateContainer { get; }
        Transform DeativateContainer { get; }
        Canvas RootCanvas { get; }

    }
}