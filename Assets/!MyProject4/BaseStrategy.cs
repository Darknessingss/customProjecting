using UnityEngine;

public abstract class BaseStrategy : MonoBehaviour, IStrategy
{
    protected abstract int Amount { get; }

    public void Execute(Model model)
    {
        ApplyEffect(model);
        OnExecuted();
    }

    protected abstract void ApplyEffect(Model model);

    protected virtual void OnExecuted() { }
}