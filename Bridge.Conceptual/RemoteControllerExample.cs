// The "abstraction" defines the interface for the "control"
// part of the two class hierarchies. It maintains a reference
// to an object of the "implementation" hierarchy and delegates
// all of the real work to this object.
namespace Bridge.Conceptual
{
    public class RemoteControl
    {
        protected Device device;

        public RemoteControl(Device device)
        {
            this.device = device;
        }

        public void TogglePower()
        {
            if (device.IsEnabled())
            {
                device.Disable();
            }
            else
            {
                device.Enable();
            }
        }

        public void VolumeDown()
        {
            device.SetVolume(device.GetVolume() - 10);
        }

        public void VolumeUp()
        {
            device.SetVolume(device.GetVolume() + 10);
        }

        public void ChannelDown()
        {
            device.SetChannel(device.GetChannel() - 1);
        }

        public void ChannelUp()
        {
            device.SetChannel(device.GetChannel() + 1);
        }
    }

    // You can extend classes from the abstraction hierarchy
    // independently from device classes.
    public class AdvancedRemoteControl : RemoteControl
    {
        public AdvancedRemoteControl(Device device) : base(device)
        {
        }

        public void Mute()
        {
            device.SetVolume(0);
        }
    }

    // The "implementation" interface declares methods common to all
    // concrete implementation classes. It doesn't have to match the
    // abstraction's interface. In fact, the two interfaces can be
    // entirely different. Typically the implementation interface
    // provides only primitive operations, while the abstraction
    // defines higher-level operations based on those primitives.
    public interface Device
    {
        bool IsEnabled();
        void Enable();
        void Disable();
        int GetVolume();
        void SetVolume(int percent);
        int GetChannel();
        void SetChannel(int channel);
    }

    // All devices follow the same interface.
    public class Tv : Device
    {
        // Implement methods from the Device interface
        // ...
        public void Disable()
        {
            throw new System.NotImplementedException();
        }

        public void Enable()
        {
            throw new System.NotImplementedException();
        }

        public int GetChannel()
        {
            throw new System.NotImplementedException();
        }

        public int GetVolume()
        {
            throw new System.NotImplementedException();
        }

        public bool IsEnabled()
        {
            throw new System.NotImplementedException();
        }

        public void SetChannel(int channel)
        {
            throw new System.NotImplementedException();
        }

        public void SetVolume(int percent)
        {
            throw new System.NotImplementedException();
        }
    }

    public class Radio : Device
    {
        // Implement methods from the Device interface
        // ...
        public void Disable()
        {
            throw new System.NotImplementedException();
        }

        public void Enable()
        {
            throw new System.NotImplementedException();
        }

        public int GetChannel()
        {
            throw new System.NotImplementedException();
        }

        public int GetVolume()
        {
            throw new System.NotImplementedException();
        }

        public bool IsEnabled()
        {
            throw new System.NotImplementedException();
        }

        public void SetChannel(int channel)
        {
            throw new System.NotImplementedException();
        }

        public void SetVolume(int percent)
        {
            throw new System.NotImplementedException();
        }
    }
}
