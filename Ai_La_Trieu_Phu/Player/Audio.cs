using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Player
{
    class Audio
    {
        private static WMPLib.WindowsMediaPlayer sound = new WMPLib.WindowsMediaPlayer();
        public static void batAmThanh(string amthanh)
        {
            sound.URL = @"Audio\" + amthanh + ".mp3";
            sound.controls.play();
        }
        public static void batAmThanh_wav(string amthanh)
        {
            SoundPlayer Sound = new SoundPlayer(@"Audio\wav\" + amthanh + ".wav");
            Sound.Play();
        }
    }
}
