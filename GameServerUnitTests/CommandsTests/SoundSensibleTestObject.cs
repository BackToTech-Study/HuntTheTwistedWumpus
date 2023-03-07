using GameServer.Messages;

class SoundSensibleTestObjects : ISoundSensible
{
    public List<Sound> ReceivedSounds = new List<Sound>();

    public void ReceiveSound(Sound sound)
    {
        ReceivedSounds.Add(sound);
    }
}