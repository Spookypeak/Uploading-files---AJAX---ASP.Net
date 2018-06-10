using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UploadingFiles_AJAX_ASP.Net
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Only Webmethods were used as a web service to comunicate client side
        //to server side
        //This methods only works as a middleware


        //This method is called when client-side makes a file uploading
        //Search in app.js file with id [001]
        [WebMethod]
        public static int UploadFile(string name, string extension, DateTime date, string data)
        {
            Service srv = new Service();
            return srv.UploadFile(new File() { Name = name, Extension = extension, Date = date, Data = data });
        }


        //This method sends to client-side only data file requested by id
        //Search in app.js file with id [002]
        [WebMethod]
        public static string GetFile(int idFile)
        {
            Service srv = new Service();
            return srv.GetFile(idFile);
        }


        //This method sends to client-side a file list to draw the table
        //Search in app.js file with id [003]
        [WebMethod]
        public static List<File> GetFiles()
        {
            Service srv = new Service();
            return srv.GetFiles();
        }
    }
}