using System;
using Raylib_cs;

namespace DinoGame2.Game.Services
{
    class SoundService
    {
        //set variables
        public string BattleTowerSongText = "sounds/pokemonSong.wav";
        public Sound BattleTowerSong;
        //constructor
        public SoundService()

        {
            Raylib.InitAudioDevice();
            //Raylib.SetSoundVolume();
            this.BattleTowerSong = Raylib.LoadSound(BattleTowerSongText);
        }

        //add other methods

        public void PlaySound(Sound sound)
        {
            Raylib.PlaySound(sound);
        }

        public Sound LoadSound(string sound)
        {
            Sound song = Raylib.LoadSound(sound);
            return song;
        }

        public Sound GetSound()
        {
            return this.BattleTowerSong;
        }

        public string GetSoundString()
        {
            return this.BattleTowerSongText;
        }
    }
}