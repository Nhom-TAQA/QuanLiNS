using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace QLNV
{
    class Dataconnection
    {
        public SqlConnection GetSqlConnection()
        {
            return new SqlConnection(@"Data Source=DESKTOP-RQCU70R\SQLEXPRESS;Initial Catalog=QL_NV;Integrated Security=True");
        }
    }
}
