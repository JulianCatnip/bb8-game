using UnityEngine.EventSystems;

public interface IReceiveMessage : IEventSystemHandler
{
    void OnRecieve(string showText);
}