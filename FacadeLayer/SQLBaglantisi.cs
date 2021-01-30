using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FacadeLayer
{
    public class SQLBaglantisi
    {
        public static SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-GHE5HQN\SQLEXPRESS;Initial Catalog=DB_OopTestKatmanı;Integrated Security=True");
    }
}
