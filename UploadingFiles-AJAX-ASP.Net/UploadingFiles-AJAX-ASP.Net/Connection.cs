using System.Configuration;
using System.Data.SqlClient;

namespace UploadingFiles_AJAX_ASP.Net
{
    public class Connection
    {
        public static SqlConnection getConnection()
        {
            string cnnStrng = ConfigurationManager.ConnectionStrings["UploadingFiles"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnStrng);
            cnn.Open();
            return cnn;
        }
    }
}