using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.LoadSprites
{
    class LoadDrunkenSailor
    {
        public Dictionary<CharacterState, List<Texture2D>> textureDic { get; set; }

        public LoadDrunkenSailor()
        {
            
            textureDic = new Dictionary<CharacterState, List<Texture2D>>();
        }

        public void LoadSprites(ContentManager Content)
        {
            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo($"Content\\Drunken Sailor");
            List<Texture2D> tempList;
            for (int i = 1; i <= directory.GetDirectories().Length; i++)
            {
                tempList = new List<Texture2D>();

                CharacterState state = (CharacterState)i;
                // Gaat naar de juiste folder zoeken in de "Drunken Sailor" Directory
                System.IO.DirectoryInfo subDirectory = new System.IO.DirectoryInfo($"Content\\Drunken Sailor\\{state.ToString()}");

                // directory.GetFiles().Length geeft hoeveel files er in de aangeroepen folder staan
                for (int j = 1; j <= subDirectory.GetFiles().Length; j++)
                {
                    // "Drunken Sailor\\{state.ToString()}\\{state.ToString()}DS{i}"
                    // kan overeen komen met
                    // "Drunken Sailor\\Idle\\IdleDS1"
                    tempList.Add(Content.Load<Texture2D>($"Drunken Sailor\\{state.ToString()}\\{state.ToString()}DS{j}"));
                }
                textureDic.Add(state, tempList);
            }
        }
    }
}
