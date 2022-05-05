namespace Game.Class.Objects
{
    class Player : Entity
    {
        public Player(char graph):base(graph) { }
        public Player(char graph, Vector2 position):base(graph, position) { }

        public void Move(Vector2 newPosition)=> Position += newPosition;
    }
}
