﻿using media.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace media
{
    public partial class DBImageOperation
    {
        private string ConnectionString = DatabaseCredentials.connectionStringLocalServer;
        private int userId;
        private Image image;
        private int postId;
        public int UserId
        {
            get { return this.userId; }
            set { this.userId = value; }
        }
        public int PostId
        {
            get { return this.postId; }
            set { this.postId = value; }
        }
        public Image Image
        {
            get { return this.image; }
            set { this.image = value; }
        }


        public  Image SelectImageFromFile()
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Image Files (*.bmp, *.jpg, *.png, *.gif)|*.bmp;*.jpg;*.png;*.gif";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    image = Image.FromFile(dialog.FileName);
                }
            }
            return image;
        }

        public void SaveToDataBase(int userId)
        {
            this.UserId = userId;
            if (image == null)
            {
                MessageBox.Show("Please select an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte[] imageBytes = ImageToByteArray(image);
            UpdateUserImage(imageBytes, this.UserId);
            MessageBox.Show("Image saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public Image LoadImageFromDataBase(int userId)
        {
            this.UserId= userId;
            byte[] imageBytes = GetUserImage(this.UserId);
            if (imageBytes == null)
            {
                MessageBox.Show("No image found for user ID " + userId + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            image = ByteArrayToImage(imageBytes);
            return image;
        }
        public Image LoadPostImageFromDataBase(int postId)
        {
            this.PostId = postId;
            byte[] imageBytes = GetPostImage(this.PostId);
            if (imageBytes == null)
            {
                MessageBox.Show("No image found for the post ID " + PostId + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            image = ByteArrayToImage(imageBytes);
            return image;
        }

        public byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, image.RawFormat);
                return stream.ToArray();
            }
        }

        public void UpdateUserImage(byte[] imageBytes,  int userId)
        {
            this.UserId = userId;

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "UPDATE user SET userimage = @userimage WHERE userId = @userId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userimage", imageBytes);
                    command.Parameters.AddWithValue("@userId", userId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public byte[] GetUserImage(int userId)
        {
            this.UserId = userId;

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT userimage FROM user WHERE userId = @userId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    using (MySqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                return (byte[])reader[0];
                            }
                        }
                    }
                }
            }

            return null;
        }
        public byte[] GetPostImage(int postId)
        {
            this.PostId = postId;

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT image FROM mediacontent_postuser WHERE postid = @postID";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@postID", postId);

                    using (MySqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                return (byte[])reader[0];
                            }
                        }
                    }
                }
            }

            return null;
        }

        private Image ByteArrayToImage(byte[] imageBytes)
        {
            using (MemoryStream stream = new MemoryStream(imageBytes))
            {
                return Image.FromStream(stream);
            }
        }
        public Classes.User GetUserByUserId(int userId)
        {
            DBImageOperation dbio = new DBImageOperation();
            Classes.User user = new Classes.User();
            try
            {
                string connectionString = DatabaseCredentials.connectionStringLocalServer;
                string query = "SELECT * FROM user WHERE userid = @userId";
                MySqlConnection connection = new MySqlConnection(connectionString);
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", userId);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    user.Key = reader.GetInt32("userid");
                    user.UserFirstName = reader.GetString("userfirstname");
                    user.UserLastName = reader.GetString("userlastname");
                    user.Dob = reader.GetDateTime("dob");
                    user.Email = reader.GetString("email");
                    user.PhoneNumber = reader.GetString("phoneno");
                    user.ProfilePhoto = dbio.LoadImageFromDataBase(reader.GetInt32("userid"));
                    user.Gender = reader.GetString("gender");
                    user.Bio = reader.GetString("bio");

                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return user;
        }
    }
}
