using ResourceBox.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace ResourceBox.Services.Data
{
    public class SecurityDAO
    {
        private string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\IDM\3.2 temp\R\ResourceBox\App_Data\ResourceBox.mdf;Integrated Security=True";




        public void createUser(User user)
        {
            string name, email, phone, password, hashCode;
            name = user.userName;
            email = user.email;
            phone = user.phone;
            password = user.password;
            hashCode = user.hashCode;


            using (SqlConnection sqlcon = new SqlConnection(connection))
            {
                string sqlquery = "insert into Users(userName,email,phone,password,hashCode) values ('" + name + "','" + email + "','" + phone + "','" + password + "','" + hashCode + "')";
                using (SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon))
                {
                    sqlcon.Open();
                    sqlcom.ExecuteNonQuery();
                }
            }
        }
        public void addBook(Book book)
        {

            using (SqlConnection sqlcon = new SqlConnection(connection))
            {
                string sqlquery = "insert into Books(bookName,bookAuthor,bookPrice,bookCategory,department,releaseDate,bookImage,userId,locationId) values ('" + book.bookName + "','" + book.bookAuthor + "','" + book.bookPrice + "','" + book.bookCategory + "','" + book.department + "','" + book.releaseDate + "','" + book.bookImage + "','" + book.userIdFK + "','" + book.locationIdFK + "')";
                using (SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon))
                {
                    sqlcon.Open();
                    sqlcom.ExecuteNonQuery();
                }
            }
        }
        public void deleteBook(int bookId)
        {

            using (SqlConnection sqlcon = new SqlConnection(connection))
            {
                string sqlquery = "Delete From Books Where bookId="+bookId;
                using (SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon))
                {
                    sqlcon.Open();
                    sqlcom.ExecuteNonQuery();
                }
            }
        }
        public List<Book> fetchbook()
        {
            List<Book> bookList = new List<Book>();

            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Books", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var book = new Book();

                    book.bookID = Convert.ToInt32(rdr["bookID"]);
                    book.bookName = rdr["bookName"].ToString();
                    book.bookCategory = rdr["bookCategory"].ToString();
                    book.bookPrice = Convert.ToInt32(rdr["bookPrice"]);
                    book.bookImage = rdr["bookImage"].ToString();
                    book.bookAuthor = rdr["bookAuthor"].ToString();
                    book.releaseDate = rdr["releaseDate"].ToString();
                    book.userIdFK = Convert.ToInt32(rdr["userId"]);
                    book.locationIdFK = Convert.ToInt32(rdr["locationId"]);
                    bookList.Add(book);
                }
            }
            return bookList;
        }
        public List<Book> fetchbook(int bookId)
        {
            List<Book> bookList = new List<Book>();

            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Books where bookID ="+ bookId, con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var book = new Book();

                    book.bookID = Convert.ToInt32(rdr["bookID"]);
                    book.bookName = rdr["bookName"].ToString();
                    book.bookCategory = rdr["bookCategory"].ToString();
                    book.bookPrice = Convert.ToInt32(rdr["bookPrice"]);
                    book.bookImage = rdr["bookImage"].ToString();
                    book.bookAuthor = rdr["bookAuthor"].ToString();
                    book.releaseDate = rdr["releaseDate"].ToString();
                    book.userIdFK = Convert.ToInt32(rdr["userId"]);
                    book.locationIdFK = Convert.ToInt32(rdr["locationId"]);
                    bookList.Add(book);
                }
            }
            return bookList;
        }
        public List<Book> fetchbook(String searchKey)
        {
            List<Book> bookList = new List<Book>();

            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Books where bookName LIKE '%" + searchKey + "%' OR bookAuthor LIKE '%" + searchKey + "%'", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var book = new Book();

                    book.bookID = Convert.ToInt32(rdr["bookID"]);
                    book.bookName = rdr["bookName"].ToString();
                    book.bookCategory = rdr["bookCategory"].ToString();
                    book.bookPrice = Convert.ToInt32(rdr["bookPrice"]);
                    book.bookImage = rdr["bookImage"].ToString();
                    book.bookAuthor = rdr["bookAuthor"].ToString();
                    book.releaseDate = rdr["releaseDate"].ToString();
                    book.userIdFK = Convert.ToInt32(rdr["userId"]);
                    book.locationIdFK = Convert.ToInt32(rdr["locationId"]);
                    bookList.Add(book);
                }
            }
            return bookList;
        }

        public List<Book> fetchbook(int filterSearch,String query)
        {
            List<Book> bookList = new List<Book>();

            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var book = new Book();

                    book.bookID = Convert.ToInt32(rdr["bookID"]);
                    book.bookName = rdr["bookName"].ToString();
                    book.bookCategory = rdr["bookCategory"].ToString();
                    book.bookPrice = Convert.ToInt32(rdr["bookPrice"]);
                    book.bookImage = rdr["bookImage"].ToString();
                    book.bookAuthor = rdr["bookAuthor"].ToString();
                    book.releaseDate = rdr["releaseDate"].ToString();
                    book.userIdFK = Convert.ToInt32(rdr["userId"]);
                    book.locationIdFK = Convert.ToInt32(rdr["locationId"]);
                    bookList.Add(book);
                }
            }
            return bookList;
        }
        public List<Book> fetchbook(Double MinLattitude, Double MinLongitude, Double MaxLattitude, Double MaxLongitude)
        {
            List<Book> bookList = new List<Book>();

            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("SELECT * from Books INNER JOIN Locations ON Books.locationId=Locations.locationId WHERE lattitude>=" + MinLattitude + " AND lattitude<=" + MaxLattitude + " AND longitude>=" + MinLongitude + " AND longitude<=" + MaxLongitude, con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var book = new Book();

                    book.bookID = Convert.ToInt32(rdr["bookID"]);
                    book.bookName = rdr["bookName"].ToString();
                    book.bookCategory = rdr["bookCategory"].ToString();
                    book.bookPrice = Convert.ToInt32(rdr["bookPrice"]);
                    book.bookImage = rdr["bookImage"].ToString();
                    book.bookAuthor = rdr["bookAuthor"].ToString();
                    book.releaseDate = rdr["releaseDate"].ToString();
                    book.userIdFK = Convert.ToInt32(rdr["userId"]);
                    book.locationIdFK = Convert.ToInt32(rdr["locationId"]);
                    bookList.Add(book);
                }
            }
            return bookList;
        }
        public List<User> fetchUser()
        {
            List<User> userList = new List<User>();

            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var user = new User();

                    user.userId = Convert.ToInt32(rdr["userId"]);
                    user.userName = rdr["userName"].ToString();
                    user.email = rdr["email"].ToString();
                    user.phone = rdr["phone"].ToString();
                    user.image = rdr["userImage"].ToString();
                    userList.Add(user);
                }
            }
            return userList;
        }
        public List<User> fetchUser(int userId)
        {
            List<User> userList = new List<User>();

            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users where userId=" + userId, con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var user = new User();

                    user.userId = Convert.ToInt32(rdr["userId"]);
                    user.userName = rdr["userName"].ToString();
                    user.email = rdr["email"].ToString();
                    user.phone = rdr["phone"].ToString();
                    user.image = rdr["userImage"].ToString();
                    userList.Add(user);
                }
            }
            return userList;
        }
        public List<User> fetchUser(String email)
        {
            List<User> userList = new List<User>();

            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users where email='" + email + "'", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var user = new User();

                    user.userId = Convert.ToInt32(rdr["userId"]);
                    user.userName = rdr["userName"].ToString();
                    user.email = rdr["email"].ToString();
                    user.phone = rdr["phone"].ToString();
                    userList.Add(user);
                }
            }
            return userList;
        }


        public void DeleteUser(int UserId)
        {

            using (SqlConnection sqlcon = new SqlConnection(connection))
            {
                string sqlquery = "Delete From Users Where userId="+UserId;
                using (SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon))
                {
                    sqlcon.Open();
                    sqlcom.ExecuteNonQuery();
                }
            }
        }



 

        public int UserCount()
        {
            int usercount=0;
            using (SqlConnection sqlcon = new SqlConnection(connection))
            {
              

                string sqlquery2 = "SELECT COUNT(*) as countUser FROM Users;";
                using (SqlCommand sqlcom = new SqlCommand(sqlquery2, sqlcon))
                {
                    sqlcon.Open();
                    sqlcom.ExecuteNonQuery();
                    SqlDataReader reader = sqlcom.ExecuteReader();
                    while (reader.Read())
                    {

                        usercount = Convert.ToInt32(reader["countUser"]);

                    }
                    reader.Close();
                }
            }
            return usercount;
        }

        public int postCount()
        {
            int postcount = 0;
            using (SqlConnection sqlcon = new SqlConnection(connection))
            {


                string sqlquery2 = "SELECT COUNT(*) as countPost FROM Posts;";
                using (SqlCommand sqlcom = new SqlCommand(sqlquery2, sqlcon))
                {
                    sqlcon.Open();
                    sqlcom.ExecuteNonQuery();
                    SqlDataReader reader = sqlcom.ExecuteReader();
                    while (reader.Read())
                    {

                        postcount = Convert.ToInt32(reader["countPost"]);

                    }
                    reader.Close();
                }
            }
            return postcount;
        }












        internal bool FindByUser(User user)
        {
            bool success = false;
            using (SqlConnection sqlcon = new SqlConnection(connection))
            {
                string sqlquery = "SELECT * FROM Users WHERE email='" + user.email + "' AND password='" + user.password + "'";
                using (SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon))
                {
                    try
                    {
                        sqlcon.Open();
                        SqlDataReader reader = sqlcom.ExecuteReader();
                        if (reader.HasRows)
                        {
                            success = true;
                        }
                        else
                        {
                            success = false;
                        }
                        reader.Close();
                    }
                    catch (Exception e)
                    {
                        ;
                    }
                }

            }
            return success;
        }
        public string getHash(User user)
        {
            String hashCode = null;
            bool success = false;
            using (SqlConnection sqlcon = new SqlConnection(connection))
            {
                string sqlquery = "SELECT hashCode FROM Users WHERE email='" + user.email + "'";
                using (SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon))
                {
                    try
                    {
                        sqlcon.Open();
                        SqlDataReader reader = sqlcom.ExecuteReader();
                        while (reader.Read())
                        {

                            hashCode = reader["hashCode"].ToString();

                        }
                        reader.Close();
                    }
                    catch (Exception e)
                    {
                        ;
                    }
                }

            }
            return hashCode;
        }
        public int addLocation(Location location)
        {
            int addedLocationId = -1;
            using (SqlConnection sqlcon = new SqlConnection(connection))
            {
                string sqlquery = "insert into Locations(locationName,area,city,country,lattitude,longitude) values ('" + location.locationName + "','" + location.area + "','" + location.city + "','" + location.country + "','" + location.lattitude + "','" + location.longitude + "')";
                using (SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon))
                {
                    sqlcon.Open();
                    sqlcom.ExecuteNonQuery();
                    sqlcon.Close();
                }

                string sqlquery2 = "SELECT TOP 1 locationId FROM Locations ORDER BY locationId DESC";
                using (SqlCommand sqlcom = new SqlCommand(sqlquery2, sqlcon))
                {
                    sqlcon.Open();
                    sqlcom.ExecuteNonQuery();
                    SqlDataReader reader = sqlcom.ExecuteReader();
                    while (reader.Read())
                    {

                        addedLocationId = Convert.ToInt32(reader["locationId"]);

                    }
                    reader.Close();
                }
            }
            return addedLocationId;
        }
        public List<Location> fetchLocation()
        {
            List<Location> locationList = new List<Location>();

            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Locations", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var location = new Location();

                    location.locationId = Convert.ToInt32(rdr["locationId"]);
                    location.locationName = rdr["locationName"].ToString();
                    location.lattitude = rdr["lattitude"].ToString();
                    location.longitude = rdr["longitude"].ToString();
                    location.area = rdr["area"].ToString();
                    location.city = rdr["city"].ToString();
                    location.country = rdr["country"].ToString();
                    locationList.Add(location);
                }
            }
            return locationList;
        }

        public List<UserChat> fetchMessages()
        {
            List<UserChat> userChats = new List<UserChat>();

            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("CREATE OR ALTER VIEW[USERNAME1] AS SELECT messageId, userId1 as SenderId, message,seen, userName as Sender,userImage as SenderImage,date_time FROM UserMessage INNER JOIN Users ON Users.userId = UserMessage.userId1 ", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Close();
                cmd = new SqlCommand("CREATE OR ALTER VIEW[USERNAME2] AS SELECT messageId, userId2 as RecieverId, message, userName as Receiver,userImage as RecieverImage FROM UserMessage INNER JOIN Users ON Users.userId = UserMessage.userId2", con);
                cmd.CommandType = CommandType.Text;

                rdr = cmd.ExecuteReader();
                rdr.Close();
                cmd = new SqlCommand("SELECT USERNAME1.messageId, SenderId, Sender,SenderImage, RecieverId, Receiver,RecieverImage, USERNAME1.message,date_time ,seen FROM USERNAME1 INNER JOIN USERNAME2 ON USERNAME1.messageId = USERNAME2.messageId ", con);
                cmd.CommandType = CommandType.Text;


                rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    var userChat = new UserChat();

                    userChat.messageId = Convert.ToInt32(rdr["messageId"]);
                    userChat.senderId = Convert.ToInt32(rdr["senderId"]);
                    userChat.senderName = rdr["Sender"].ToString();
                    userChat.senderImage = rdr["SenderImage"].ToString();
                    userChat.recieverId = Convert.ToInt32(rdr["recieverId"]);
                    userChat.recieverName = rdr["Receiver"].ToString();
                    userChat.recieverImage = rdr["RecieverImage"].ToString();
                    userChat.message = rdr["message"].ToString();
                    userChat.date_time = rdr["date_time"].ToString();
                    userChat.seen = rdr["seen"].ToString();
                   //userChat.seen_time = rdr["seen_time"].ToString();

                    userChats.Add(userChat);
                }
            }
            return userChats;
        }
        public void addChat(UserChat userChat)
        {

            using (SqlConnection sqlcon = new SqlConnection(connection))
            {
                string sqlquery = "insert into UserMessage(userId1,userId2,message,date_time) values ('" + userChat.senderId + "','" + userChat.recieverId + "','" + userChat.message + "','" + userChat.date_time + "')";
                using (SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon))
                {
                    sqlcon.Open();
                    sqlcom.ExecuteNonQuery();
                    sqlcon.Close();
                }

            }

        }
        public void addPost(Post post)
        {

            using (SqlConnection sqlcon = new SqlConnection(connection))
            {
                string sqlquery = "insert into Posts(post,postImage,postFile,postType,privacy,userId,date_time) values ('" + post.post + "','" + post.postImage + "','" + post.file + "','" + post.postType + "','" + post.privacy + "','" + post.userId + "','" + post.date_time + "')";
                using (SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon))
                {
                    sqlcon.Open();
                    sqlcom.ExecuteNonQuery();
                }
            }
        }
        public List<Post> fetchPost()
        {
            List<Post> posts = new List<Post>();

            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Posts", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var post = new Post();

                    post.postId = Convert.ToInt32(rdr["postId"]);
                    post.post = rdr["post"].ToString();
                    post.postImage = rdr["postImage"].ToString();
                    post.file = rdr["postFile"].ToString();
                    post.postType = rdr["postType"].ToString();
                    post.privacy = rdr["privacy"].ToString();
                    post.userId = Convert.ToInt32(rdr["userId"]);
                    post.date_time= rdr["date_time"].ToString();
                    posts.Add(post);
                }
            }
            return posts;
        }

        public List<UserNotification> fetchNotification(int userId)
        {
            List<UserNotification> userNotifications = new List<UserNotification>();

            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM UserNotifications where userId="+userId, con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var notification = new UserNotification();

                    notification.userId = Convert.ToInt32(rdr["userId"]);
                    notification.messageUnread = Convert.ToInt32(rdr["messageUnread"]);
                    notification.newNotification = Convert.ToInt32(rdr["newNotifications"]);
                   
                    userNotifications.Add(notification);
                }
                rdr.Close();
               // updateNotifcation(userId,0);
            }
            return userNotifications;
        }
        public void updateNotifcation(int userId,int setMessage)
        {
            using (SqlConnection sqlcon = new SqlConnection(connection))
            {
                string sqlquery = "UPDATE UserNotifications SET messageUnread="+setMessage+",newNotifications=0 WHERE userId=" + userId;
                using (SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon))
                {
                    sqlcon.Open();
                    sqlcom.ExecuteNonQuery();
                    sqlcon.Close();
                }

            }
        }
        public void updateSeenHistory(int userId, int selectedId)
        {
            using (SqlConnection sqlcon = new SqlConnection(connection))
            {
                string sqlquery = "UPDATE UserMessage SET seen='true' WHERE userId1=" + selectedId+" AND userId2="+userId;
                using (SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon))
                {
                    sqlcon.Open();
                    sqlcom.ExecuteNonQuery();
                    sqlcon.Close();
                }

            }
        }

        public void updateOTP(String email, String OTP, String Activated)
        {
            using (SqlConnection sqlcon = new SqlConnection(connection))
            {
                string sqlquery = "UPDATE Users SET OTPCode='" + OTP + "',Activated='"+Activated+"'WHERE email='" + email+"'";
                using (SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon))
                {
                    sqlcon.Open();
                    sqlcom.ExecuteNonQuery();
                    sqlcon.Close();
                }

            }
        }

        public bool sendOTP(string from, string to, string subject, string body)
        {
            bool f = false;
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(to);
                mailMessage.From = new MailAddress(from);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.Credentials = new System.Net.NetworkCredential("resourceboxbd@gmail.com", "resourcebox3719");
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);
                f = true;
            }
            catch (Exception ex)
            {
                f = false;
            }
            return f;
        }
        public bool matchOTP(string email,string otp)
        {
            bool success = false;
            using (SqlConnection sqlcon = new SqlConnection(connection))
            {
                string sqlquery = "SELECT * FROM Users WHERE email='" + email + "' AND OTPCode='" + otp + "'";
                using (SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon))
                {
                    try
                    {
                        sqlcon.Open();
                        SqlDataReader reader = sqlcom.ExecuteReader();
                        if (reader.HasRows)
                        {
                            success = true;
                        }
                        else
                        {
                            success = false;
                        }
                        reader.Close();
                    }
                    catch (Exception e)
                    {
                        ;
                    }
                }

            }
            return success;
        }

        public List<AboutUs> fetchAbout()
        {
            List<AboutUs> aboutUs = new List<AboutUs>();

            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM AboutUS", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var about = new AboutUs();

                    about.id = Convert.ToInt32(rdr["Id"]);
                    about.storyHeader = rdr["storyHeader"].ToString();
                    about.story = rdr["story"].ToString();
                    about.aboutImg1 = rdr["aboutImg1"].ToString();
                    about.aboutImg2 = rdr["aboutImg2"].ToString();
                    about.aboutImg3 = rdr["aboutImg3"].ToString();
                    about.focusImg1 = rdr["focusImg1"].ToString();
                    about.focusImg2 = rdr["focusImg2"].ToString();
                    about.focusImg3 = rdr["focusImg3"].ToString();

                    aboutUs.Add(about);
                }
            }
            return aboutUs;
        }
        public List<TermsAndCondition> fetchTermsAndCondition()
        {
            List<TermsAndCondition> TermsAndCOndition = new List<TermsAndCondition>();

            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM TermsAndCondition", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var terms = new TermsAndCondition();

                    terms.id = Convert.ToInt32(rdr["Id"]);
                    terms.termsHeader = rdr["termsHeader"].ToString();
                    terms.heading1 = rdr["heading1"].ToString();
                    terms.description1 = rdr["description1"].ToString();
                    terms.heading2 = rdr["heading2"].ToString();
                    terms.description2 = rdr["description2"].ToString();
                    terms.heading3 = rdr["heading3"].ToString();
                    terms.description3 = rdr["description3"].ToString();
                    terms.heading4 = rdr["heading4"].ToString();
                    terms.description4 = rdr["description4"].ToString();
                    terms.heading5 = rdr["heading5"].ToString();
                    terms.description5 = rdr["description5"].ToString();
                    terms.heading6 = rdr["heading6"].ToString();
                    terms.description6 = rdr["description6"].ToString();

                    TermsAndCOndition.Add(terms);
                }
            }
            return TermsAndCOndition;
        }
    }

}
   