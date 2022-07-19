using System;
using Raylib_cs;

namespace DinoGame2.Game.Services
{
    public class SoundService
    {
        //set variables
        public string BattleTowerSongText = "sounds/pokemonSong.wav";
        public Sound BattleTowerSong;
        private string ExplosionSoundText = "sounds/explosion.mp3";
        public Sound ExplosionSound;
        public string DeathSoundText = "sounds/youdie.mp3";
        public Sound DeathSound;

        //constructor
        public SoundService()
        {
            Raylib.InitAudioDevice();
            //Raylib.SetSoundVolume();
            this.BattleTowerSong = Raylib.LoadSound(BattleTowerSongText);
            this.ExplosionSound = Raylib.LoadSound(ExplosionSoundText);
            this.DeathSound = Raylib.LoadSound(this.DeathSoundText);
            Raylib.SetSoundVolume(ExplosionSound, 0.05f);
            Raylib.SetSoundVolume(DeathSound, 0.05f);
            Raylib.SetSoundVolume(BattleTowerSong, 0.05f);
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

        public Sound GetSoundExplosion()
        {
            return this.ExplosionSound;
        }

        public string GetSoundString()
        {
            return this.BattleTowerSongText;
        }
    }
}