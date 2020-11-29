using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.LoadSprites
{
    class LoadCucumber
    {
        public Dictionary<CharacterState, List<Texture2D>> textureDic { get; set; }

        public LoadCucumber()
        {

            textureDic = new Dictionary<CharacterState, List<Texture2D>>();
        }

        public void LoadSprites(ContentManager Content)
        {
            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo($"Content\\Cucumber");
            List<Texture2D> tempList;
            for (int i = 1; i < directory.GetDirectories().Length; i++)
            {
                tempList = new List<Texture2D>();

                CharacterState state = (CharacterState)i;
                System.IO.DirectoryInfo subDirectory = new System.IO.DirectoryInfo($"Content\\Cucumber\\{state.ToString()}");

                for (int j = 1; j <= subDirectory.GetFiles().Length; j++)
                {
                    tempList.Add(Content.Load<Texture2D>($"Cucumber\\{state.ToString()}\\{state.ToString() + j}"));
                }
                textureDic.Add(state, tempList);
            }
        }
    }
}
