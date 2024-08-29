namespace Quantum
{
    using Photon.Deterministic;
    using UnityEngine.Scripting;

    [Preserve]
    public unsafe class Player : SystemMainThreadFilter<Player.Filter>
    {
        public struct Filter
        {
            public EntityRef Entity;
            public PhysicsBody2D* Body;
            public PlayerInfo* playerInfo;
        }
        

        public override void Update(Frame f, ref Filter filter)
        {
            var input = f.GetPlayerInput(0);
            Move(f, ref filter, input);
        }

        private void Move(Frame f, ref Filter filter, Input* input)
        {
            var direction = FPVector2.Zero;
            if(filter.playerInfo -> CurrentHp <= 0)
            {
                filter.Body->Velocity = FPVector2.Zero;
                return;
            }

            if (input->Right) direction = FPVector2.Right;
            else if (input->Left) direction = FPVector2.Left;
            else if (input->Up) direction = FPVector2.Up;
            else if (input->Down) direction = FPVector2.Down;
            else direction = FPVector2.Zero;
            filter.Body->Velocity = direction.Normalized * filter.playerInfo->speed;
        }

        private void AnimationCheck()
        {

        }
    }
}
