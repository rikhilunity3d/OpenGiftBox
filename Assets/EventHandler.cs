using UnityEngine;
using System;

public class EventHandler : GenericSingleton<EventHandler>
{
    
    
    public static event Action <int> OnGiftBoxShakeAnimation;
    public static event Action <int>OnNextGiftColliderShake;
    public static event Action OnResetGiftBoxStatus;

    public void InvokeOnNextGiftColliderShake(int id) => OnNextGiftColliderShake?.Invoke(id);
    public void InvokeOnGiftBoxShakeAnimation(int id) => OnGiftBoxShakeAnimation?.Invoke(id);

    public void InvokeOnResetGiftBoxStatus() => OnResetGiftBoxStatus?.Invoke();
}
