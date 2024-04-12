using System;

namespace Mediator.Conceptual.AuthUIExample
{
    // Mediator interface
    public interface IMediator
    {
        void Notify(Component sender, string evnt);
    }

    // Concrete Mediator
    public class AuthenticationDialog : IMediator
    {
        private string title;
        public readonly Checkbox loginOrRegisterChkBx;
        public readonly Textbox loginUsername, loginPassword;
        public readonly Textbox registrationUsername, registrationPassword, registrationEmail;
        public readonly Button okBtn, cancelBtn;
        public AuthenticationDialog()
        {
            // Instantiate all component objects by passing 'this' mediator to their constructors
            loginOrRegisterChkBx = new Checkbox(this, "loginOrRegisterChkBx");
            loginUsername = new Textbox(this, "loginUsername");
            loginPassword = new Textbox(this, "loginPassword");
            registrationUsername = new Textbox(this, "registrationUsername");
            registrationPassword = new Textbox(this, "registrationPassword");
            registrationEmail = new Textbox(this, "registrationEmail");
            okBtn = new Button(this, "okBtn");
            cancelBtn = new Button(this, "cancelBtn");
        }

        public void Notify(Component sender, string evnt)
        {
            switch (sender.Name)
            {
                case "loginOrRegisterChkBx":
                    if (evnt == "check")
                    {
                        bool isLogin = loginOrRegisterChkBx.IsChecked;
                        title = isLogin ? "Log in" : "Register";
                        ToggleLoginRegister(isLogin);
                    }
                    break;
                case "okBtn":
                    if (evnt == "click")
                    {
                        if (loginOrRegisterChkBx.IsChecked)
                        {
                            ProcessLogin();
                        }
                        else
                        {
                            ProcessRegistration();
                        }
                    }
                    break;
                    // Add cases for other components and events as needed
            }
        }

        public void ToggleLoginRegister(bool isLogin)
        {
            loginUsername.Visible = isLogin;
            loginPassword.Visible = isLogin;
            registrationUsername.Visible = !isLogin;
            registrationPassword.Visible = !isLogin;
            registrationEmail.Visible = !isLogin;
        }

        public void ProcessLogin()
        {
            // Validate login credentials
            if (string.IsNullOrEmpty(loginUsername.Text) || string.IsNullOrEmpty(loginPassword.Text))
            {
                Console.WriteLine("Login fields cannot be empty.");
                return;
            }
            Console.WriteLine("Processing login for " + loginUsername.Text);
            // Further login processing...
        }

        public void ProcessRegistration()
        {
            // Validate registration details
            if (string.IsNullOrEmpty(registrationUsername.Text) ||
                string.IsNullOrEmpty(registrationPassword.Text) ||
                string.IsNullOrEmpty(registrationEmail.Text))
            {
                Console.WriteLine("Registration fields cannot be empty.");
                return;
            }
            Console.WriteLine("Processing registration for " + registrationUsername.Text);
            // Further registration processing...
        }
    }

    // Abstract Component class
    // Abstract Component class
    public abstract class Component
    {
        protected IMediator dialog;
        public string Name { get; private set; } // Unique identifier for each component

        protected Component(IMediator dialog, string name)
        {
            this.dialog = dialog;
            Name = name;
        }

        public abstract void Click();
        public abstract void Keypress();
    }

    // Concrete Components
    public class Button : Component
    {
        public Button(IMediator dialog, string name) : base(dialog, name) { }

        public override void Click()
        {
            Console.WriteLine(Name + " button clicked.");
            dialog.Notify(this, "click");
        }

        public override void Keypress()
        {
            // Button-specific keypress behavior
        }
    }

    public class Textbox : Component
    {
        public string Text { get; set; }
        public bool Visible { get; set; } // To show/hide the textbox based on the state

        public Textbox(IMediator dialog, string name) : base(dialog, name)
        {
            Visible = true; // Default visibility
        }

        public override void Click()
        {
            // Textbox-specific click behavior
        }

        public override void Keypress()
        {
            Console.WriteLine(Name + " textbox keypress.");
            dialog.Notify(this, "keypress");
        }
    }

    public class Checkbox : Component
    {
        public bool IsChecked { get; private set; }

        public Checkbox(IMediator dialog, string name) : base(dialog, name) { }

        public void Check()
        {
            IsChecked = !IsChecked;
            Console.WriteLine(Name + " checkbox is " + (IsChecked ? "checked" : "unchecked"));
            dialog.Notify(this, "check");
        }

        public override void Click()
        {
            // Checkbox-specific click behavior
            Check(); // Toggle state on click
        }

        public override void Keypress()
        {
            // Checkbox-specific keypress behavior
        }
    }
}
