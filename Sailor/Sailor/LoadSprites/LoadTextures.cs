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
            
            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo($"Content\\{Directory}");
            List<Texture2D> tempList;
            //int lengte = directory.GetDirectories().Length;
            for (int i = 0; i < directory.GetDirectories().Length; i++)
            {
                try
                {
                    tempList = new List<Texture2D>();
                    SurroundingObjects enumType = (SurroundingObjects)i;
                    System.IO.DirectoryInfo subDirectory = new System.IO.DirectoryInfo($"Content\\{Directory}\\{enumType.ToString()}");

                    //int lengte = subDirectory.GetFiles().Length;
                    for (int j = 0; j < subDirectory.GetFiles().Length; j++)
                    {
                        try
                        {
                            tempList.Add(Content.Load<Texture2D>($"{Directory}\\{enumType.ToString()}\\{enumType.ToString() + (j + 1).ToString()}"));
                        }
                        catch (Exception)
                        {
                            break;
                            throw;
                        }
                    }
                    textureDic.Add(enumType, tempList);
                }
                catch (Exception)
                {
                    break;
                    throw;
                }
            }
            return textureDic;
        }

        public static Dictionary<CharacterState, List<Texture2D>> LoadCharacterSprites(String Directory, ContentManager Content)
        {
            Dictionary<CharacterState, List<Texture2D>> textureDic = new Dictionary<CharacterState, List<Texture2D>>(); ;
            
            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo($"Content\\{Directory}");
            List<Texture2D> tempList;
            //int lengte = directory.GetDirectories().Length;
            for (int i = 0; i < directory.GetDirectories().Length; i++)
            {
                try
                {
                    tempList = new List<Texture2D>();
                    CharacterState enumType = (CharacterState)i;
                    System.IO.DirectoryInfo subDirectory = new System.IO.DirectoryInfo($"Content\\{Directory}\\{enumType.ToString()}");

                    //int lengte = subDirectory.GetFiles().Length;
                    for (int j = 0; j < subDirectory.GetFiles().Length; j++)
                    {
                        try
                        {
                            tempList.Add(Content.Load<Texture2D>($"{Directory}\\{enumType.ToString()}\\{enumType.ToString() + (j + 1).ToString()}"));
                        }
                        catch (Exception)
                        {
                            break;
                            throw;
                        }
                    }
                    textureDic.Add(enumType, tempList);
                }
                catch (Exception)
                {
                    break;
                    throw;
                }
            }
            return textureDic;
        }
        public static List<Texture2D> LoadAttakObjectsSprites(String Directory, ContentManager Content)
        {
            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo($"Content\\{Directory}");
            List<Texture2D> tempList = new List<Texture2D>();
            for (int j = 0; j < directory.GetFiles().Length; j++)
            {
                try
                {
                    tempList.Add(Content.Load<Texture2D>($"{Directory}\\{Directory + (j + 1).ToString()}"));
                }
                catch (Exception)
                {
                    break;
                    throw;
                }
            }
            return tempList;
        }
    }
}
