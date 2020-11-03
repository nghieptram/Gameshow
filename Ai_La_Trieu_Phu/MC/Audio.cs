using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;

namespace MC
{
    class Audio
    {
        private static WMPLib.WindowsMediaPlayer sound = new WMPLib.WindowsMediaPlayer();
        public static void batAmThanh(string amthanh)
        {
            sound.URL = @"Audio\" + amthanh + ".mp3";
            sound.controls.play();

            ////thêm đường dẫn thư mục Audio
            //SoundPlayer Sound = new SoundPlayer(@"Audio\wav\" + amthanh + ".wav");
            //Sound.Play();
        }
    }
}
