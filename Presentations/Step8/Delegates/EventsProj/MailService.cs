
namespace EventsProj
{
	public class MailService
	{	
		public void OnVideoEncoded(object source, EventArgs e)
		{
			Console.WriteLine("Mail Service: Sending an email...");
		}
	}
}
