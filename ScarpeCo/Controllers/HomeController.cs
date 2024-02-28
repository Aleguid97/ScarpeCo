using ScarpeCo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScarpeCo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Scarpe> scarpe = new List<Scarpe>();
            string connectionString = ConfigurationManager.ConnectionStrings["Scarpe"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM SCARPE";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Scarpe d = new Scarpe();
                        d.IdArticolo = Convert.ToInt16(reader["IdArticolo"]);
                        d.Nome = reader["Nome"].ToString();
                        d.Descrizione = reader["Descrizione"].ToString();
                        d.Prezzo = Convert.ToDecimal(reader["Prezzo"]);
                        d.ImgPath = reader["ImgPath"].ToString();
                        d.ImgAlt1 = reader["ImgAlt1"].ToString();
                        d.ImgAlt2 = reader["ImgAlt2"].ToString();
                        d.Visibile = Convert.ToBoolean(reader["Visibile"]);
                        scarpe.Add(d);
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Errore: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                return View(scarpe);
            }

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
