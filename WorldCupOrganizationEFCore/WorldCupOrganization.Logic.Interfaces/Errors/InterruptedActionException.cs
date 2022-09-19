using System;
using System.Collections.Generic;
using System.Text;

namespace WorldCupOrganization.Logic.Interfaces.Errors
{
    public class InterruptedActionException : Exception
    {
        public InterruptedActionException(Exception inner) : base(("Accion interrumpida: " + inner.Message), inner) { }
    }
}
