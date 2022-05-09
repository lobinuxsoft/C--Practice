using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Class.Objects
{
    class Enemy : Character
    {
        public Enemy(char graph, int maxHealth = 10) : base(graph, maxHealth) { }

        public Enemy(char graph, Vector2 position, int maxHealth = 10) : base(graph, position, maxHealth) { }

        public override void Update()
        {
            Move(IaCalculationMove(2000).Result);
        }

        private async Task<Vector2> IaCalculationMove(int delay)
        {
            Vector2 result = Vector2.Zero;

            // TODO enemy movement

            await Task.Delay(delay);

            return result;
        }
    }
}
