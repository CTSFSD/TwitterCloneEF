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
    public class TweetsController : Controller
    {
        //
        // GET: /Tweets/

        public ActionResult Index()
        {
            string strUserName = Request.Form["uname"].ToString();
            string strPwd = Request.Form["psw"].ToString();

            if (strUserName.Trim().Length == 0  || strPwd.Trim().Length == 0)
            {
                Response.Redirect("../login.aspx");
            }

            if (UserValidation(strUserName, strPwd) == false)
            {
                Response.Redirect("../login.aspx");
            }

            Session["userid"] = strUserName;

            getTweetCount(strUserName);

            return View("TweetsView", getTweets(strUserName));

        }
        private bool UserValidation(string strUserName, string strPassword)
        {
            MD5CryptoServiceProvider md5hasher = new MD5CryptoServiceProvider();
            UTF8Encoding encoder = new UTF8Encoding();

            string strPassWrodEnc = md5hasher.ComputeHash(encoder.GetBytes(strPassword)).ToString();

            //DataSet ds = new DataSet();
            //SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConString"]);
            //SqlCommand cmd = new SqlCommand();
            //string Query = @"Select * from person (nolock) where user_id=@UserID and Password=@PasswordEnc";
            //cmd = new SqlCommand(Query, con);
            //cmd.Parameters.AddWithValue("@UserID", strUserName);
            //cmd.Parameters.AddWithValue("@PasswordEnc", strPassWrodEnc);           
            //SqlDataAdapter sda = new SqlDataAdapter(Query,con);
            //con.Open();
            //sda.Fill(ds);
            //con.Close();

            //if (ds.Tables.Count >0 && ds.Tables[0].Rows.Count > 0)
            //{
            //    return true;
            //}

            testEntities dbPersonEntity = new testEntities();
            var empQuery = from person in dbPersonEntity.People
                           where person.user_Id == strUserName
                           select person;

            Person objPerson = empQuery.Single();
            if(objPerson.user_Id == strUserName && objPerson.Password == strPassWrodEnc)
            {
                return true;
            }

            return false;
        }
        private void getTweetCount(string strUserName)
        {
            //SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConString"]);
            //SqlCommand cmd = new SqlCommand();
            //string Query = @"usp_getFollowTweets";
            //cmd = new SqlCommand(Query, con);
            //cmd.Parameters.AddWithValue("@UserID", strUserName);
            //DataSet ds = new DataSet();
            //SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            //con.Open();
            //sda.Fill(ds);
            //con.Close();

            int intFollowerTweets = 0;
            int intFollowingTweets = 0;
            //if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //{
            //    intFollowerTweets = Convert.ToInt32(ds.Tables[0].Rows[0]["FollowerTweets"].ToString());
            //    intFollowingTweets = Convert.ToInt32(ds.Tables[0].Rows[0]["FollowingTweets"].ToString());
            //}

            testEntities dbTweetsEntity = new testEntities();
            UserTweets objTweets = new UserTweets();
            objTweets = dbTweetsEntity.getFollowTweets(strUserName);

            intFollowerTweets = Convert.ToInt32(objTweets.FollowerTweets.ToString());
            intFollowingTweets = Convert.ToInt32(objTweets.FollowingTweets.ToString());

            var userTweet = new UserTweets()
            {
                fullName = Session["UserFullName"].ToString(),
                TotalTweets = intFollowerTweets + intFollowingTweets,
                FollowerTweets = intFollowerTweets,
                FollowingTweets = intFollowingTweets
            };
            ViewBag.UserTweet = userTweet;

        }
        private List<Tweet> getTweets(string strUserName)
        {
            List<Tweet> TweetList = new List<Tweet>();

            //DataSet ds = new DataSet();
            //SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConString"]);
            //SqlCommand cmd = new SqlCommand();
            //string Query = @"SELECT * from Tweet As T (nolock) Join Following as FG (nolock) on FG.user_Id = T.user_Id 	where FG.following_Id = @userid order by created desc UNION SELECT * from Tweet As T (nolock) Join Following as FR (nolock) on FG.[following_Id] = T.user_Id Where FG.[following_Id] = @userid order by created desc";
            //cmd = new SqlCommand(Query, con);
            //cmd.Parameters.AddWithValue("@UserID", strUserName);
            //SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            //con.Open();
            //sda.Fill(ds);
            //con.Close();
            
            //if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //{
            //    for (int i=0; i < ds.Tables[0].Rows.Count; i++ )
            //    {
            //         Tweet obj = new Tweet();
            //         obj.user_id = ds.Tables[0].Rows[i]["user_id"].ToString();
            //         obj.message = ds.Tables[0].Rows[i]["message"].ToString();
            //         string strDate = ds.Tables[0].Rows[i]["created"].ToString();
            //         obj.created = Convert.ToDateTime(strDate).Date.ToShortDateString();
            //         if (Convert.ToDateTime(strDate).Date== DateTime.Now.Date)
            //         {
            //             obj.created = Convert.ToDateTime(strDate).TimeOfDay.ToString();
            //         }
            //         TweetList.Add(obj); 
            //    }               
            //}
            testEntities dbTweetsEntity = new testEntities();

            TweetList = dbTweetsEntity.getAllTweets(strUserName).ToList(); //getAllTweets is a stored procedure which will return the all the tweets.

            return TweetList;

        }
        [HttpPost]
        public ActionResult create(TwitterClone.Models.Tweet objItem)
        {
//            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConString"]);
//            SqlCommand cmd = new SqlCommand();

//            string Query = @"INSERT INTO Tweet  (user_Id ,message ,created )  
//                                               Values(@user_Id,@message,@created)";

//            cmd = new SqlCommand(Query, con);
//            cmd.Parameters.AddWithValue("@user_Id", objItem.user_id);
//            cmd.Parameters.AddWithValue("@message", objItem.message);
//            cmd.Parameters.AddWithValue("@created", DateTime.Now.ToString());
//            con.Open();
//            cmd.ExecuteNonQuery();
//            con.Close();

            testEntities dbPersonEntity = new testEntities();
            Tweet objTweet = new Tweet();
            objTweet.user_Id = objItem.user_id;
            objTweet.message = objItem.message;
            objTweet.created = DateTime.Now;

            dbPersonEntity.Tweets.Add(objTweet);
            dbPersonEntity.SaveChanges();

            return View("TweetsView", getTweets(objItem.user_id));
        }

    }
}
