using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UploadingFiles_AJAX_ASP.Net
{
    public class Service
    {
        //When is executed this method, returns id from current register inserted
        //that id is obtained from a trigger
        public int UploadFile(File file)
        {
            using (SqlConnection cnn = Connection.getConnection())
            {
                int res = 0;
                string query = "INSERT INTO FILES " +
                                $"VALUES('{file.Name}','{file.Data}','{file.Extension}','{file.Date}')";
                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                    if (sdr.Read())
                        res = Convert.ToInt32(sdr["Id"]);
                sdr.Close();
                sdr.Dispose();
                return res;
            }
        }
        //Gets only data file to spare resources
        public string GetFile(int idFile)
        {
            using (SqlConnection cnn = Connection.getConnection())
            {
                string file = null;
                string query = $"SELECT Data FROM Files WHERE Id={idFile}";
                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                    if (sdr.Read())
                        file = sdr["Data"].ToString();
                sdr.Close();
                sdr.Dispose();
                return file;
            }
        }
        //This method only returns id, name, date and extension to do not 
        //send all since this may consume a lot unnecessary resources
        public List<File> GetFiles()
        {
            using (SqlConnection cnn = Connection.getConnection())
            {
                List<File> files = new List<File>();
                string query = "SELECT * FROM Files";
                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                        files.Add(
                            new File()
                            {
                                Id = (int)sdr["id"],
                                Name = sdr["Name"].ToString(),
                                Date = Convert.ToDateTime(sdr["Date"]),
                                Extension = sdr["Extension"].ToString()
                            });
                }
                sdr.Close();
                sdr.Dispose();
                return (files.Count > 0) ? files : null;
            }
        }
    }
}