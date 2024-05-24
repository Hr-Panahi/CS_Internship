namespace EventsProj
{
	class Program
	{
		static void Main()
		{
			Video video = new Video() { Title = "Video 1"};
			VideoEncoder videoEncoder = new VideoEncoder(); //publisher
			MailService mailService = new MailService(); //subscriber
			MessageService messageService = new MessageService(); //subscriber

			videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
			videoEncoder.VideoEncoded += messageService.OnVideoEncoded;

			videoEncoder.Encode(video);	
		}
	}
}