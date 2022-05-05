using MailKit.Net.Smtp;
using MimeKit;
using post_office.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace post_office.Helpers
{
    public class Helpers
    {
        private static readonly Regex _regex = new Regex("[^0-9]+");
        private static Random random = new Random();

        public static string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, 20)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public static string RandomCode()
        {
            return DateTime.Now.Ticks.ToString();
        }
        public static bool IsNumber(string text)
        {
            return _regex.IsMatch(text);
        }
        public static string RandomVerifyCode()
        {
            Random r = new Random();
            int randNum = r.Next(1000000);
            return randNum.ToString("D6");
        }
        public static VerifyModel SendVerifyCode(string email,string userName,bool ISForUser, bool type)
        {
            //type==true=>verify to setup. false: verify account
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Postal office" + (type == true ? " - set up new password" : ""), "postaloffice.hcmc@gmail.com"));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = "Verify your email";
            string vcode = RandomVerifyCode();
            message.Body = new TextPart("plain")
            {
                Text = $"Hello {userName}, This is your confirmation code, please do not share with anyone: {vcode} \n *The code is valid for 5 minutes*"
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("postaloffice.hcmc@gmail.com", "Abc123@@");
                client.Send(message);
                client.Disconnect(true);
            }
            return new VerifyModel() { email = email, created_at = DateTime.Now, isForUser = ISForUser, verify_code = vcode };

        }
       
        public enum DefaultStatus
        {
            [Display(Name = "Deactivated")]
            Deactivated,
            [Display(Name = "Activated")]
            Activated
        }

        public enum DeliveryStatus
        {
            [Display(Name = "Pending")]
            Pending,
            [Display(Name = "Picked up")]
            Picked,
            [Display(Name = "Queuing")]
            Queuing,
            [Display(Name = "On delivery")]
            Delivery,
            [Display(Name = "Delivered")]
            Delivered,
            [Display(Name = "Failed")]
            Failed,
            [Display(Name = "Redeliver")]
            Redeliver
        }

        public enum OrderStatus
        {
            [Display(Name = "Pending")]
            Pending,
            [Display(Name = "Canceled")]
            Canceled,
            [Display(Name = "Completed")]
            Completed,
            [Display(Name = "Proccessing")]
            Proccessing
        }

        public enum PaymentStatus
        {
            [Display(Name = "Unpaid")]
            Unpaid,
            [Display(Name = "Paid")]
            Paid
        }

        public enum PaymentType
        {
            [Display(Name = "COD")]
            COD,
            [Display(Name = "OnePay")]
            OnePay
        }

        //check stt
        public static string CheckStatusValue(int status, string type)
        {
            string statusValue = "";
            switch(type){
                case "DefaultStatus":
                    statusValue = status == (int)DefaultStatus.Activated ? DefaultStatus.Activated.ToString() : DefaultStatus.Deactivated.ToString();
                    break;
                case "DeliveryStatus":
                    switch(status){
                            case (int)DeliveryStatus.Pending:
                                statusValue = DeliveryStatus.Pending.ToString();
                                break;
                            case (int)DeliveryStatus.Picked:
                                statusValue = DeliveryStatus.Picked.ToString();
                                break;
                            case (int)DeliveryStatus.Queuing:
                                statusValue = DeliveryStatus.Queuing.ToString();
                                break;
                            case (int)DeliveryStatus.Failed:
                                statusValue = DeliveryStatus.Failed.ToString();
                                break;
                            case (int)DeliveryStatus.Delivery:
                                statusValue = DeliveryStatus.Delivery.ToString();
                                break;
                            case (int)DeliveryStatus.Delivered:
                                statusValue = DeliveryStatus.Delivered.ToString();
                                break;
                            case (int)DeliveryStatus.Redeliver:
                                statusValue = DeliveryStatus.Redeliver.ToString();
                                break;
                        }
                    break;
                case "OrderStatus":
                    switch(status){
                        case (int)OrderStatus.Pending:
                            statusValue = OrderStatus.Pending.ToString();
                            break; 
                        case (int)OrderStatus.Canceled:
                            statusValue = OrderStatus.Canceled.ToString();
                            break; 
                        case (int)OrderStatus.Proccessing:
                            statusValue = OrderStatus.Proccessing.ToString();
                            break; 
                        case (int)OrderStatus.Completed:
                            statusValue = OrderStatus.Completed.ToString();
                            break; 
                    }
                    break;
                case "PaymentStatus":
                    statusValue = status == (int)PaymentStatus.Paid ? PaymentStatus.Paid.ToString() : PaymentStatus.Unpaid.ToString();
                    break;
                case "PaymentType":
                    switch(status){
                        case (int)PaymentType.COD:
                            statusValue = PaymentType.COD.ToString();
                            break;
                        case (int)PaymentType.OnePay:
                            statusValue = PaymentType.OnePay.ToString();
                            break;
                    }
                    break;
            }
            return statusValue;
        }
    }
}