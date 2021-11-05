using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mario
{
    public class SoundManager
    {

        private ContentManager content;
        private Dictionary<String, SoundEffect> soundDictionary = new Dictionary<String, SoundEffect>();

        public SoundManager(ContentManager myContent)
        {
            content = myContent;
            //LoadSoundDictionary();
        }

        public void BeginBackgroundMusic()
        {
            Song backgroundMusic = content.Load<Song>("smwwd1.mid");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(backgroundMusic);
        }

        public void EndBackgroundMusic()
        {
            MediaPlayer.Stop();
        }

        private void LoadSoundDictionary()
        {
            SoundEffect coin = content.Load<SoundEffect>("../../../SoundManager/Sounds/smw_coin.wav");
            soundDictionary.Add("Coin", coin);
        }

        public void PlaySound(String key)
        {
            SoundEffect sound;
            soundDictionary.TryGetValue(key, out sound);
            sound.CreateInstance().Play(); //doing this allows playing multiple effects at once if needed.
        }














    }
}
