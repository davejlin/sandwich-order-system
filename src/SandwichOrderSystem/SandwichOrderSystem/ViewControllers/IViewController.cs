using SandwichOrderSystem.Views;
using System;
using System.Collections.Generic;

namespace SandwichOrderSystem.ViewControllers
{
    public interface IViewController
    {
        void Start();
        Action GetSegueAction();
    }
}
