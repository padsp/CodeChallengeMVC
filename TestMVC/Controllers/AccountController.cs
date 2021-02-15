using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using CodeChallengeMVC.Models;

namespace TestMVC.Controllers
{
    public class AccountController : Controller
    {
        public async Task<ActionResult> Index()
        {
            string Baseurl = "https://frontiercodingtests.azurewebsites.net/";

            List<AccountModel> accountList = new List<AccountModel>();
            
            using( var APIClient = new HttpClient())
            {
                APIClient.BaseAddress = new Uri(Baseurl);
                APIClient.DefaultRequestHeaders.Clear();
                APIClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await APIClient.GetAsync("api/accounts/getall");
                if (response.IsSuccessStatusCode)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    accountList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AccountModel>>(responseString);                   
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            return View(accountList.OrderBy(row => row.PaymentDueDate != null).ThenBy(row => row.PaymentDueDate));
        }
    }
}