
namespace EventsProj
{
	public class MessageService
	{
		public void OnVideoEncoded(object source, EventArgs args)
		{
			Console.WriteLine("Message Service: Sending a message...");
		}
	}
}
