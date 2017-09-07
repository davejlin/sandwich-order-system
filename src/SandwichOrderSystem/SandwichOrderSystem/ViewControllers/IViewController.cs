using System;

namespace SandwichOrderSystem.ViewControllers
{
    public interface IViewController
    {
        void Start();
        Action GetSegueAction();
    }
}
