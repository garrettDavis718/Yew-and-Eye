using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace DigiviceEmulatorLib
{
	/// <summary>
	/// class for performing email operations.
	/// </summary>
	public static class EmailOps
	{
		/// <summary>
		/// Send email(s) using smtp and gmail servers. 
		/// </summary>
		/// <param name="subject">email subject line.</param>
		/// <param name="body">email body. this supports HTML.</param>
		/// <param name="recipients">email recipients. group messages can be 
		/// created using ',' to delimit addresses in single string.</param>
		/// <param name="isBodyHtml">set to true to display body as html.</param>
		public static void SendEail(string subject,
									 string body,
									 string[] recipients,
									 bool isBodyHtml = false)
		{
			List<MailMessage> emails = new List<MailMessage>();
			foreach (string recipient in recipients)
			{
				MailMessage mail = new MailMessage
				{
					From = new MailAddress(GmailAddress)
				};
				mail.To.Add(recipient);
				mail.Subject = subject;
				mail.Body = body;
				mail.IsBodyHtml = isBodyHtml;
				emails.Add(mail);
			}
			// create & fill list of emails.

			using (SmtpClient smtpServer = new SmtpClient("smtp.gmail.com"))
			{
				smtpServer.Port = 587;
				smtpServer.Credentials = new System.Net.NetworkCredential(GmailAddress, Password);
				smtpServer.EnableSsl = true;
				foreach (MailMessage email in emails)
				{
					smtpServer.Send(email);
				}
			}
			// connect to server and send emails. 
		}

		/// <summary>
		/// gmail address to send emails from.
		/// </summary>
		private static string GmailAddress { get; } = @"DigiviceEmulator@gmail.com";

		/// <summary>
		/// password to auth gmail address. 
		/// </summary>
		private static string Password { get; } = @"Ftcc2022.";
	}
}
