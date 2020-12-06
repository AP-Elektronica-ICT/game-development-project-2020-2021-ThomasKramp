using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.Interfaces.Commands;
using Sailor.LoadSprites;
using Sailor.World;
using Sailor.World.Abstract;
using System;
using System.Collections.Generic;

namespace Sailor.LevelDesign
{
    class Level
    {
        /* Texture number
         * Nothing = 0
         * Tile = 1
         * Player = 2
         * Enemy = 3
         * Barrel = 4
         * Table = 5
         * Chair = 6
         * Platform = 7
         */

        private byte[,] BackgroundArray = new Byte[,]
           {
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
           };
        private byte[,] SurroundingsArray = new Byte[,]
        {
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,7,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,7,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,7,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,7,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
        };
        private byte[,] ForegroundArray = new Byte[,]
        {
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,1,1,0,0,0,1,1,0,0,0,1,1,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,1,1,1,0,0,1,1,1,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,1,1,0,0,0,1,1,0,0,0,1,1,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,1,1,1,0,0,1,1,1,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
        };
        private byte[,] TestArray = new Byte[,]
        {
            {1,1,1,1,1,1},
            {1,0,0,0,0,1},
            {1,0,0,0,0,1},
            {1,0,0,0,0,1},
            {1,0,0,0,0,1},
            {1,0,0,0,0,1},
            {1,0,0,0,0,1},
            {1,3,0,2,0,1},
            {1,0,0,0,0,1},
            {1,1,1,1,1,1},
        };

        private List<DrawBlok> Background = new List<DrawBlok>();
        public List<DrawBlok> Surroundings = new List<DrawBlok>();
        private List<DrawBlok> Foreground = new List<DrawBlok>();

        private Dictionary<SurroundingObjects, List<Texture2D>> backTextures;
        private Dictionary<SurroundingObjects, List<Texture2D>> surrTextures;
        private Dictionary<SurroundingObjects, List<Texture2D>> foreTextures;
        private List<Dictionary<CharacterState, List<Texture2D>>> enemyTexures;

        public List<DynamicBlok> Enemies = new List<DynamicBlok>();

        public Level(List<Dictionary<SurroundingObjects, List<Texture2D>>> LevelTexures,
            List<Dictionary<CharacterState, List<Texture2D>>> EnemyTexures)
        {
            this.backTextures = LevelTexures[0];
            this.surrTextures = LevelTexures[1];
            this.enemyTexures = EnemyTexures;
        }

        public void AddEnemies()
        {
            Enemies.Add(new Enemy(enemyTexures[0]));
        }

        public void CreateWorld(DrawBlok player)
        {
            CreateBackGround();
            CreateSurroundings(player);
            CreateForeground();
        }

        private void CreateBackGround()
        {
            Random r = new Random();
            for (int y = 0; y < BackgroundArray.GetLength(0); y++)
            {
                for (int x = 0; x < BackgroundArray.GetLength(1); x++)
                {
                    if (BackgroundArray[y, x] == 1)
                    {
                        // X en Y zijn geinverteerd in de array[hoogte, breedte]
                        Background.Add(new StaticBlok(backTextures[SurroundingObjects.Tile]
                            [r.Next(0, backTextures[SurroundingObjects.Tile].Count)],
                            new Vector2((x * 64) + ((y % 2) * 32), y * 16)));
                    }
                }
            }
        }

        private void CreateSurroundings(DrawBlok player)
        {
            int enemyTeller = 0;
            Random r = new Random();
            for (int y = 0; y < SurroundingsArray.GetLength(0); y++)
            {
                for (int x = 0; x < SurroundingsArray.GetLength(1); x++)
                {
                    switch (SurroundingsArray[y, x])
                    {
                        case 1:
                            Surroundings.Add(new StaticBlok(surrTextures[(SurroundingObjects)(y % 2)]
                                [r.Next(0, surrTextures[(SurroundingObjects)(y % 2)].Count)],
                                new Vector2(x * 64, y * 16)));
                            break;
                        case 2:
                            Surroundings.Add(player);
                            player.Positie = new Vector2(x * 64, y * 16 - 58);
                            break;
                        case 3:
                            if (Enemies.Count > enemyTeller)
                            {
                                Surroundings.Add(Enemies[enemyTeller]);
                                Enemies[enemyTeller].Positie = new Vector2(x * 64, y * 16 - 58);
                                enemyTeller++;
                            }
                            break;
                        case 4:
                            Surroundings.Add(new StaticBlok(surrTextures[SurroundingObjects.Furniture][0],
                                new Vector2(x * 64, y * 16 - 28)));
                            break;
                        case 5:
                            Surroundings.Add(new StaticBlok(surrTextures[SurroundingObjects.Furniture][1],
                                new Vector2(x * 64, y * 16 - 16)));
                            break;
                        case 6:
                            Surroundings.Add(new StaticBlok(surrTextures[SurroundingObjects.Furniture][2],
                                new Vector2(x * 64, y * 16 - 40)));
                            break;
                        case 7:
                            Surroundings.Add(new PlatformBlok(surrTextures[SurroundingObjects.Platform][0],
                                new Vector2(x * 64, y * 16)));
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void CreateForeground()
        {
            
        }

        List<IKillAble> deadBlocks;
        public void RemoveDead(IKillAble Player)
        {
            deadBlocks = new List<IKillAble>();
            if (Player.Levens <= 0)
            {
                if(Player.Hit) Player.Dead = true;
                deadBlocks.Add(Player);
            }
            foreach (var enemy in Enemies)
            {
                if (enemy.Levens <= 0)
                {
                    if (enemy.Hit) 
                        enemy.Dead = true;
                    deadBlocks.Add(enemy);
                }
            }
            foreach (var dead in deadBlocks)
            {
                if(dead.Dead && !dead.Hit)
                {
                    Surroundings.Remove((DrawBlok)dead);
                    if (dead != Player) Enemies.Remove((DynamicBlok)dead);
                }
            }
        }

        public void DrawWorld(SpriteBatch spritebatch)
        {
            foreach (var backItem in Background)
            {
                backItem.Draw(spritebatch);
            }
            foreach (var SurrItem in Surroundings)
            {
                if (SurrItem != null)
                {
                    SurrItem.Draw(spritebatch);
                }
            }
        }
    }
}
