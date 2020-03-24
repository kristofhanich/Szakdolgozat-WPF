using System;
using System.Collections.Generic;
using System.Text;

namespace Gravirozas.Repository
{
    public static class Connection
    {
        public static string String { get; } = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=gravirozasDB;Integrated Security=SSPI;";
        /*public static string String { get; } = @"Data Source=.\SQLEXPRESS;Initial Catalog=gravirozasDB;Integrated Security=SSPI;"; MacBook*/
    }
}
