namespace State.Conceptual
{
    // State interface
    public interface IState
    {
        void ClickLock();
        void ClickPlay();
        void ClickNext();
        void ClickPrevious();
    }

    // Context class
    public class AudioPlayer
    {
        public IState State { get; set; }
        // Fields for UI, volume, playlist, currentSong are assumed to be implemented

        public AudioPlayer()
        {
            State = new ReadyState(this);
            // Assume UI with buttons is initialized and events are hooked up properly
        }

        // Methods to change the states
        public void ClickLock()
        {
            State.ClickLock();
        }
        public void ClickPlay()
        {
            State.ClickPlay();
        }
        public void ClickNext()
        {
            State.ClickNext();
        }
        public void ClickPrevious()
        {
            State.ClickPrevious();
        }

        // Other functionality related to the player
        public void StartPlayback()
        {
            // Start playing the music
        }
        public void StopPlayback()
        {
            // Stop the music
        }
        public void NextSong()
        {
            // Switch to the next song
        }
        public void PreviousSong()
        {
            // Switch to the previous song
        }
    }

    // Concrete states
    public class LockedState : IState
    {
        private readonly AudioPlayer _player;

        public LockedState(AudioPlayer player)
        {
            _player = player;
        }

        public void ClickLock()
        {
            // Unlock the player and change the state to the appropriate state
            _player.State = new ReadyState(_player);
        }

        public void ClickPlay()
        {
            // Do nothing
        }

        public void ClickNext()
        {
            // Do nothing
        }

        public void ClickPrevious()
        {
            // Do nothing
        }
    }

    public class ReadyState : IState
    {
        private readonly AudioPlayer _player;

        public ReadyState(AudioPlayer player)
        {
            _player = player;
        }

        public void ClickLock()
        {
            _player.State = new LockedState(_player);
        }

        public void ClickPlay()
        {
            _player.StartPlayback();
            _player.State = new PlayingState(_player);
        }

        public void ClickNext()
        {
            _player.NextSong();
        }

        public void ClickPrevious()
        {
            _player.PreviousSong();
        }
    }

    public class PlayingState : IState
    {
        private readonly AudioPlayer _player;

        public PlayingState(AudioPlayer player)
        {
            _player = player;
        }

        public void ClickLock()
        {
            _player.State = new LockedState(_player);
        }

        public void ClickPlay()
        {
            _player.StopPlayback();
            _player.State = new ReadyState(_player);
        }

        public void ClickNext()
        {
            // Double-click logic is not handled here for simplicity
            _player.NextSong();
        }

        public void ClickPrevious()
        {
            // Double-click logic is not handled here for simplicity
            _player.PreviousSong();
        }
    }
}
