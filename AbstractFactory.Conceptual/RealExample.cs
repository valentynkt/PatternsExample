using System;

namespace AbstractFactory.Conceptual
{
    public interface IButton
    {
        void Paint();
    }
    public interface ICheckBox
    {
        void Paint();
    }


    class WinButton : IButton
    {
        public void Paint()
        {
            Console.WriteLine("This is a Windows Button");
        }
    }
    class WinCheckBox : ICheckBox
    {
        public void Paint()
        {
            Console.WriteLine("This is a Windows CheckBox");
        }
    }

    class MacButton : IButton
    {
        public void Paint()
        {
            Console.WriteLine("This is a Mac Button");
        }
    }
    class MacCheckBox : ICheckBox
    {
        public void Paint()
        {
            Console.WriteLine("This is a Mac CheckBox");
        }
    }

    public interface IGUIFactory
    {
        IButton CreateButton();
        ICheckBox CreateCheckBox();
    }

    public class WinFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new WinButton();
        }
        public ICheckBox CreateCheckBox()
        {
            return new WinCheckBox();
        }
    }

    public class MacFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new MacButton();
        }
        public ICheckBox CreateCheckBox()
        {
            return new MacCheckBox(); ;
        }
    }
    // example how to use Encapsulation on different levels so another project (higher layer) would see only what he needs and concrete elements and factories would be encapsulated
    public class SomeService
    {
        private IGUIFactory _factory { get; set; }
        private IButton _button { get; set; }
        private ICheckBox _checkBox { get; set; }

        public SomeService(string configOS)
        {
            _factory = configOS switch
            {
                "Windows" => new WinFactory(),
                "Mac" => new MacFactory(),
                _ => new WinFactory(),
            };
            _button = _factory.CreateButton();
            _checkBox = _factory.CreateCheckBox();
        }

        public IGUIFactory GetFactory()
        {
            return _factory;
        }

        public void PaintAllElements()
        {
            _button.Paint();
            _checkBox.Paint();
        }
    }
}
