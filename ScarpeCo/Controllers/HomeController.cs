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
            List<Scarpe> scarpa = new List<Scarpe>();
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
                        d.imgPath = reader["imgPath"].ToString();
                        d.imgAlt1 = reader["imgAlt1"].ToString();
                        d.imgAlt2 = reader["imgAlt2"].ToString();
                        d.Visibile = Convert.ToBoolean(reader["Visibile"]);
                        scarpa.Add(d);
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
                return View(scarpa);
            }

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "A so Putia re Scarpi";

            return View();
        }
        
        [HttpGet]
        public ActionResult Dettagli(int id)
        {

            List<Scarpe> scarpa = new List<Scarpe>();
            string connectionString = ConfigurationManager.ConnectionStrings["Scarpe"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM SCARPE WHERE IdArticolo = @IdArticolo";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdArticolo", id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Scarpe d = new Scarpe();
                        d.IdArticolo = Convert.ToInt16(reader["IdArticolo"]);
                        d.Nome = reader["Nome"].ToString();
                        d.Descrizione = reader["Descrizione"].ToString();
                        d.Prezzo = Convert.ToDecimal(reader["Prezzo"]);
                        d.imgPath = reader["imgPath"].ToString();
                        d.imgAlt1 = reader["imgAlt1"].ToString();
                        d.imgAlt2 = reader["imgAlt2"].ToString();
                        d.Visibile = Convert.ToBoolean(reader["Visibile"]);
                        scarpa.Add(d);
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
            }

            return View(scarpa);
        }
    }
}