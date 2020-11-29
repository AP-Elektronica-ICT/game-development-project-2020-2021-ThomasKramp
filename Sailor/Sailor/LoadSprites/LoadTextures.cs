using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.LoadSprites
{
    class LoadTextures
    {
        public static Dictionary<SurroundingObjects, List<Texture2D>> LoadSurroundingsSprites(String Directory, ContentManager Content)
        {
            Dictionary<SurroundingObjects, List<Texture2D>> textureDic = new Dictionary<SurroundingObjects, List<Texture2D>>(); ;
            // Lijst van alle variabele in de meegegeven enum
            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo($"Content\\{Directory}");
            List<Texture2D> tempList;
            for (int i = 0; i < directory.GetDirectories().Length; i++)
            {
                tempList = new List<Texture2D>();
                SurroundingObjects enumType = (SurroundingObjects)i;
                System.IO.DirectoryInfo subDirectory = new System.IO.DirectoryInfo($"Content\\{Directory}\\{enumType.ToString()}");

                int lengte = subDirectory.GetFiles().Length;
                for (int j = 0; j < subDirectory.GetFiles().Length; j++)
                {
                    tempList.Add(Content.Load<Texture2D>($"{Directory}\\{enumType.ToString()}\\{enumType.ToString() + (j + 1).ToString()}"));
                }
                textureDic.Add(enumType, tempList);
            }
            return textureDic;
        }

        public static Dictionary<CharacterState, List<Texture2D>> LoadCharacterSprites(String Directory, ContentManager Content)
        {
            Dictionary<CharacterState, List<Texture2D>> textureDic = new Dictionary<CharacterState, List<Texture2D>>(); ;
            // Lijst van alle variabele in de meegegeven enum
            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo($"Content\\{Directory}");
            List<Texture2D> tempList;
            for (int i = 0; i < directory.GetDirectories().Length; i++)
            {
                tempList = new List<Texture2D>();
                CharacterState enumType = (CharacterState)i;
                System.IO.DirectoryInfo subDirectory = new System.IO.DirectoryInfo($"Content\\{Directory}\\{enumType.ToString()}");

                int lengte = subDirectory.GetFiles().Length;
                for (int j = 0; j < subDirectory.GetFiles().Length; j++)
                {
                    tempList.Add(Content.Load<Texture2D>($"{Directory}\\{enumType.ToString()}\\{enumType.ToString() + (j + 1).ToString()}"));
                }
                textureDic.Add(enumType, tempList);
            }
            return textureDic;
        }
    }
}
