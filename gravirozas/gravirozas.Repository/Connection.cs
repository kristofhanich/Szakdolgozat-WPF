using System;
using System.Collections.Generic;
using System.Text;

namespace Gravirozas.Repository
{
    public static class Connection
    {
        public static string String { get; } = @"Data Source=.\SQLEXPRESS;Initial Catalog=gravirozasDB;Integrated Security=SSPI;";
    }
}
