using System;
using System.Collections.Generic;
using System.Text;

namespace WorldCupOrganization.DataAccess.Interfaces.Errors
{
    public class QueryException : Exception
    {
        public QueryException(Exception inner) : base(("Error al comunicarse con la base de datos: " + inner.Message), inner) { }
    }
}
