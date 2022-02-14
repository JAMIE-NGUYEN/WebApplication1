using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtDate.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            txtDate.Attributes["min"] = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            txtDate.Attributes["max"] = DateTime.Now.AddDays(15).ToString("yyyy-MM-dd");
            //DateTime dtCurrentDate = DateTime.Today;
            //DateTime dtCurrentTime = DateTime.Now;
            //ListItem listItem1 = new ListItem(dtCurrentTime.ToShortTimeString(), dtCurrentTime.ToShortTimeString());
            //listItem1.Enabled = listItem1.Selected = true;

            //for (int i = 0; i <= 12; i++)
            //{
            //    ListItem listItem2 = new ListItem(dtCurrentDate.ToShortTimeString(), dtCurrentDate.ToShortTimeString());
            //    listItem2.Selected = false;
            //    ddlStartTime.Items.Add(listItem2);
            //    if (dtCurrentDate.CompareTo(dtCurrentTime) < 0 && dtCurrentDate.CompareTo(dtCurrentTime) > 0)
            //        ddlStartTime.Items.Add(listItem1);
            //    dtCurrentDate = dtCurrentDate.AddMinutes(30);
            //}

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime st = DateTime.Parse(ddlStartTime.SelectedValue);
            string nst = st.ToString("H:mm");
            string date = txtDate.Text;
            DateTime combined = DateTime.Parse(date + ' ' + nst);

            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var now = DateTime.UtcNow;
            var apiSecret = "TWGXilIqPwb5k4MO1NvvQxX87hdJALogJx9x";
            byte[] symmetricKey = Encoding.ASCII.GetBytes(apiSecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "62ic91AzQ_-C6klfk4OSDw",
                Expires = now.AddSeconds(300),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);


            var client = new RestClient("https://api.zoom.us/v2/users/Appdevproject9@gmail.com/meetings");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { topic = "Meeting with Tutor", duration = "60", start_time = combined, type = "2" });
            request.AddHeader("authorization", String.Format("Bearer {0}", tokenString));


            IRestResponse restResponse = client.Execute(request);
            HttpStatusCode statusCode = restResponse.StatusCode;
            int numericStatusCode = (int)statusCode;
            var jObject = JObject.Parse(restResponse.Content);
            Host.Text = (string)jObject["start_url"];
            Join.Text = (string)jObject["join_url"];
            Code.Text = Convert.ToString(numericStatusCode);
        }
    }
}