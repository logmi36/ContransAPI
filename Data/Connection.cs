using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace CtrApp8.Data
{
    public class Connection
    {

        private static readonly IConfiguration _configuration;

        //public SqlConnection conContrans = new SqlConnection("Server=tcp:crtappserver.database.windows.net,1433;Initial Catalog=ctrappdb;Persist Security Info=False;User ID=imendoza;Password=So@cat12;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        //public SqlConnection conContrans = new SqlConnection(@"Data Source=DESKTOP-OQ29MHF\SQLEXPRESS;Initial Catalog=contrans_oper;Integrated Security=SSPI;Persist Security Info=true;integrated security=false;User ID=imendoza;Password=qwerty;Connection TimeOut=60;");
        //public SqlConnection conContrans = new SqlConnection(@"Server=tcp:ctrserver.database.windows.net,1433;Initial Catalog=ctrdb;Persist Security Info=False;User ID=imendoza;Password=So@cat12;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        //public SqlConnection conContrans = new SqlConnection(_configuration.GetConnectionString("ctrconstr2"));

        public SqlConnection conContrans = new SqlConnection(@"Server=tcp:ctrappsrv.database.windows.net,1433;Initial Catalog=ctrappdb;Persist Security Info=False;User ID=imendoza;Password=So@cat12;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        //public SqlConnection conContrans = new SqlConnection(@"Data Source=DESKTOP-OQ29MHF\SQLEXPRESS;Initial Catalog=ctrdb8;Integrated Security=SSPI;Persist Security Info=true;integrated security=false;User ID=imendoza;Password=qwerty;Connection TimeOut=60;");


    }
}
