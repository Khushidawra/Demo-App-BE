using Demo_App_BE.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Demo_App_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public RegistrationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("register")]
        public IActionResult registration(Registration registration)
        {
            SqlConnection con= new SqlConnection(_configuration.GetConnectionString("conn").ToString());
            SqlDataAdapter data = new SqlDataAdapter("Select * from Users where Email = '" + registration.Email +"'", con);
            DataTable dt = new DataTable();
            data.Fill(dt);
            if(dt.Rows.Count > 0 )
            {
                return BadRequest("Email Already Exists");
            }
            SqlCommand cmd= new SqlCommand("Insert into Users(UserName,Password,Email) Values ('"+registration.UserName+"','"+registration.Password+"', '"+registration.Email +"')",con);
            con.Open();
            int i=cmd.ExecuteNonQuery();
            con.Close();
            if(i>0)
            {
                var user = new
                {
                    Email = registration.Email.ToString(),
                    UserName = registration.UserName.ToString()
                };
                return Ok(user);
            }
            else
            return BadRequest("Error");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult login(Registration login)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("conn").ToString());
            SqlDataAdapter da = new SqlDataAdapter("Select * from Users where Email = '" + login.Email + "'AND Password = '" + login.Password + "'", con);
            DataTable dataTable= new DataTable();
            da.Fill(dataTable);
            if (dataTable.Rows.Count == 1)
            {
                var user = new
                {
                    Email = dataTable.Rows[0]["Email"].ToString(),
                    UserName = dataTable.Rows[0]["UserName"].ToString()
                };
                return Ok(user);
            }
            else
                return BadRequest("Incorrect Credentials");
        }
    }
}
