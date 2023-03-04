namespace GameServer.Sound
{
    public class Sound
    {
        public int PropagationDistance { get; private set; }
        public string Name { get; private set; }

        public Sound(int propagationDistance, string name)
        {
            PropagationDistance = propagationDistance;
            Name = name;
        }
    }
} 
