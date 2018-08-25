using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TwitterClone.Models;


namespace TwitterClone.Controllers
{
    public class PersonController : Controller
    {
        //
        // GET: /Person/

        public ActionResult Index()
        {
            return View("SignUpview");
        }

        [HttpPost]
        public ActionResult create(TwitterClone.Models.Person objItem)
        {
            MD5CryptoServiceProvider md5hasher = new MD5CryptoServiceProvider();
            UTF8Encoding encoder = new UTF8Encoding();

            string strPassWrodEnc = md5hasher.ComputeHash(encoder.GetBytes(objItem.password)).ToString();

//            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConString"]);
//            SqlCommand cmd = new SqlCommand();

//            string Query = @"INSERT INTO Person  (user_Id ,Password ,fullName, email, joined, active )  
//                                               Values(@user_Id ,@Password ,@fullName, @email, @joined, @active)";

//            cmd = new SqlCommand(Query, con);
//            cmd.Parameters.AddWithValue("@user_Id", objItem.user_id);
//            cmd.Parameters.AddWithValue("@Password", strPassWrodEnc);
//            cmd.Parameters.AddWithValue("@fullName", objItem.fullName);
//            cmd.Parameters.AddWithValue("@email", objItem.email);
//            cmd.Parameters.AddWithValue("@joined", DateTime.Now.ToString());
//            cmd.Parameters.AddWithValue("@active", 1);
//            con.Open();
//            cmd.ExecuteNonQuery();
//            con.Close();

            testEntities dbPersonEntity = new testEntities();
            Person objPerson = new  Person();
            objPerson.user_Id = objItem.user_id;
            objPerson.Password = strPassWrodEnc;
            objPerson.fullName = objItem.fullName;
            objPerson.email = objItem.email;
            objPerson.joined = DateTime.Now;
            objPerson.active = true;

            dbPersonEntity.People.Add(objPerson);
            dbPersonEntity.SaveChanges();

            return View("SignUpview");
            
        }

        [HttpPost]
        public ActionResult Edit(TwitterClone.Models.Person objItem)
        {
            MD5CryptoServiceProvider md5hasher = new MD5CryptoServiceProvider();
            UTF8Encoding encoder = new UTF8Encoding();

            string strPassWrodEnc = md5hasher.ComputeHash(encoder.GetBytes(objItem.password)).ToString();

            //SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConString"]);
            //SqlCommand cmd = new SqlCommand();

            //string Query = @"Update person set password=@Password, fullName=@fullName, email=@email where user_id = @user_Id";

            //cmd = new SqlCommand(Query, con);
            //cmd.Parameters.AddWithValue("@user_Id", objItem.user_id);
            //cmd.Parameters.AddWithValue("@Password", strPassWrodEnc);
            //cmd.Parameters.AddWithValue("@fullName", objItem.fullName);
            //cmd.Parameters.AddWithValue("@email", objItem.email);
            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();

            testEntities dbPersonEntity = new testEntities();
            var empQuery = from person in dbPersonEntity.People
                           where person.user_Id == objItem.user_id
                           select person;

            Person objPerson = empQuery.Single();

            objPerson.user_Id = objItem.user_id;
            objPerson.Password = strPassWrodEnc;
            objPerson.fullName = objItem.fullName;
            objPerson.email = objItem.email;

            dbPersonEntity.SaveChanges();

            return View("SignUpview");

        }
        [HttpPost]
        public ActionResult Delete(TwitterClone.Models.Person objItem)
        {
           
            //SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConString"]);
            //SqlCommand cmd = new SqlCommand();

            //string Query = @"Update person set active=0 where user_id = @user_Id";

            //cmd = new SqlCommand(Query, con);
            //cmd.Parameters.AddWithValue("@user_Id", objItem.user_id);
            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();

            testEntities dbPersonEntity = new testEntities();
            var empQuery = from person in dbPersonEntity.People
                           where person.user_Id == objItem.user_id
                           select person;

            Person objPerson = empQuery.Single();

            objPerson.user_Id = objItem.user_id;
            objPerson.active = false;

            dbPersonEntity.SaveChanges();

            return View("TweetsView");

        }
    }
}
