namespace Quantum
{
    using Photon.Deterministic;
    using UnityEngine;

    public class PlayerView : QuantumEntityViewComponent
    {
        private void OnEnable()
        {
            QuantumCallback.Subscribe(this, (CallbackPollInput callback) => PollInput(callback));
        }

        /// <summary>
        /// Set an empty input when polled by the simulation.
        /// </summary>
        /// <param name="callback"></param>
        public void PollInput(CallbackPollInput callback)
        {
            Quantum.Input i = new Quantum.Input();
            i.Up = UnityEngine.Input.GetKey(KeyCode.UpArrow);
            i.Down = UnityEngine.Input.GetKey(KeyCode.DownArrow);
            i.Left = UnityEngine.Input.GetKey(KeyCode.LeftArrow);
            i.Right = UnityEngine.Input.GetKey(KeyCode.RightArrow);
            i.Bomb = UnityEngine.Input.GetKey(KeyCode.Space);
            callback.SetInput(i, DeterministicInputFlags.Repeatable);
        }
    }
}
