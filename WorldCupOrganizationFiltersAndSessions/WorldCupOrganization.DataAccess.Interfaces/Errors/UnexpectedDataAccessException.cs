using System;
using System.Collections.Generic;
using System.Text;

namespace WorldCupOrganization.DataAccess.Interfaces.Errors
{
    public class UnexpectedDataAccessException : Exception
    {
        public UnexpectedDataAccessException(Exception inner) : base(("Error desconocido en la base de datos: " + inner.Message), inner) { }
    }
}
