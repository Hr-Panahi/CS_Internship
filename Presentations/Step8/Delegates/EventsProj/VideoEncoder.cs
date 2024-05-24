using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsProj
{
	public class VideoEncoder
	{
		// 1- Define a delegate
		// 2- Define an event based on that delegate
		// 3- Raise the event

		public delegate void VideoEncodedEventHandler(object source, EventArgs args);

		//EventHandler
		//EventHandler<TEventArgs>

		public event VideoEncodedEventHandler VideoEncoded;

		public void Encode(Video video)
		{
            Console.WriteLine("Encoding video...");
			Thread.Sleep(3000);

			OnVideoEncoded();
        }

		//event publisher
		protected virtual void OnVideoEncoded()
		{
			if(VideoEncoded != null)
			{
				VideoEncoded(this, EventArgs.Empty);
			}
		}
	}
}
