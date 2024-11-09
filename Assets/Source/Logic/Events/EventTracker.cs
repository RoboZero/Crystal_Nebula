using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Source.Logic.Events
{
    public class EventTracker : MonoBehaviour
    {
        public List<EventCommand> EventCommands => eventCommands;
        
        private List<EventCommand> eventCommands = new();

        public async UniTask<bool> AddEvent(EventCommand eventCommand)
        {
            eventCommands.Add(eventCommand);
            var result = await eventCommand.Apply(destroyCancellationToken);
            Debug.Log($"Event Tracker added and performed event: {eventCommand} \n {eventCommand.GetLog()}");
            return result;
        }
    }
}
