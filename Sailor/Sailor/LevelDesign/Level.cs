using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sailor.Detection;
using Sailor.Interfaces;
using Sailor.Interfaces.Commands;
using Sailor.LevelDesign.Schematics;
using Sailor.LoadSprites;
using Sailor.World;
using Sailor.World.Abstract;
using System;
using System.Collections.Generic;

namespace Sailor.LevelDesign
{
    class Level : ILevel
    {
        private List<DrawBlok> Background = new List<DrawBlok>();
        public List<DrawBlok> Surroundings { get; set; } = new List<DrawBlok>();
        private List<DrawBlok> Foreground = new List<DrawBlok>();

        private Dictionary<SurroundingObjects, List<Texture2D>> backTextures;
        private Dictionary<SurroundingObjects, List<Texture2D>> surrTextures;
        private Dictionary<SurroundingObjects, List<Texture2D>> foreTextures;
        private List<Dictionary<CharacterState, List<Texture2D>>> enemyTexures;
        private Dictionary<DoorState, List<Texture2D>> doorTexures;
        private List<Texture2D> signTextures;

        public List<CharacterBlok> Enemies { get; set; } = new List<CharacterBlok>();
        public List<DynamicBlok> ThrowAbles { get; set; } = new List<DynamicBlok>();
        public List<DoorBlok> Doors { get; set; } = new List<DoorBlok>();
        public IGameObject LowestTile { get; set; }

        public Level(List<Dictionary<SurroundingObjects, List<Texture2D>>> LevelTexures,
            List<Dictionary<CharacterState, List<Texture2D>>> EnemyTexures,
            Dictionary<DoorState, List<Texture2D>> DoorTextures,
            List<Texture2D> signTextures) {
            this.backTextures = LevelTexures[0];
            this.surrTextures = LevelTexures[1];
            this.enemyTexures = EnemyTexures;
            this.doorTexures = DoorTextures;
            this.signTextures = signTextures;
        }

        public void CreateWorld(DrawBlok player, Schematic schematic)
        {
            CreateBackGround(schematic.BackgroundArray);
            CreateSurroundings(schematic.SurroundingsArray, player);
            CreateForeground(schematic.ForegroundArray);
            LowestTile = EndlessFallDetection.GetLowestTile(Surroundings);
        }

        private void CreateBackGround(byte[,] BackgroundArray)
        {
            Random r = new Random();
            for (int y = 0; y < BackgroundArray.GetLength(0); y++)
            {
                for (int x = 0; x < BackgroundArray.GetLength(1); x++)
                {
                    // X en Y zijn geinverteerd in de array[hoogte, breedte]
                    switch (BackgroundArray[y, x])
                    {
                        case 1:
                            Background.Add(new StaticBlok(backTextures[SurroundingObjects.Tile]
                                [r.Next(0, backTextures[SurroundingObjects.Tile].Count)],
                                new Vector2((x * 64) + ((y % 2) * 32), y * 16)));
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void CreateSurroundings(byte[,] SurroundingsArray, DrawBlok player)
        {
            Random r = new Random();
            for (int y = 0; y < SurroundingsArray.GetLength(0); y++)
            {
                for (int x = 0; x < SurroundingsArray.GetLength(1); x++)
                {
                    switch (SurroundingsArray[y, x])
                    {
                        case 1:
                            int realCount = (surrTextures[SurroundingObjects.Tile].Count) / 2;
                            Surroundings.Add(new StaticBlok(surrTextures[SurroundingObjects.Tile]
                                [r.Next(0, realCount) + realCount * (y % 2)],
                                new Vector2(x * 64, y * 16)));
                            break;
                        case 2:
                            Surroundings.Add(player);
                            player.Positie = new Vector2(x * 64, y * 16 - 58);
                            break;
                        case 3:
                            Enemy newEnemy = new Enemy(enemyTexures[0]);
                            Enemies.Add(newEnemy);
                            Surroundings.Add(newEnemy);
                            newEnemy.Positie = new Vector2(x * 64, y * 16 - 58);
                            break;
                        case 4:
                            Surroundings.Add(new StaticBlok(surrTextures[SurroundingObjects.Object][0],
                                new Vector2(x * 64 + 11, y * 16 - 28)));
                            break;
                        case 5:
                            Surroundings.Add(new StaticBlok(surrTextures[SurroundingObjects.Object][1],
                                new Vector2(x * 64, y * 16 - 16)));
                            break;
                        case 6:
                            Surroundings.Add(new StaticBlok(surrTextures[SurroundingObjects.Object][2],
                                new Vector2(x * 64, y * 16 - 40)));
                            break;
                        case 7:
                            Surroundings.Add(new StaticBlok(surrTextures[SurroundingObjects.Object][3],
                                new Vector2(x * 64 + 44, y * 16 - 40)));
                            break;
                        case 8:
                            Surroundings.Add(new PassableBlok(surrTextures[SurroundingObjects.Platform][0],
                                new Vector2(x * 64, y * 16)));
                            break;
                        case 9:
                            Surroundings.Add(new PassableBlok(surrTextures[SurroundingObjects.Platform][1],
                                new Vector2(x * 64, y * 16)));
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void CreateForeground(byte[,] ForegroundArray)
        {
            for (int y = 0; y < ForegroundArray.GetLength(0); y++)
            {
                for (int x = 0; x < ForegroundArray.GetLength(1); x++)
                {
                    // X en Y zijn geinverteerd in de array[hoogte, breedte]
                    switch (ForegroundArray[y, x])
                    {
                        case 1:
                            DoorBlok NextDoor = new DoorBlok(doorTexures, new Vector2(x * 64, y * 16 - 80), DoorType.Next);
                            Doors.Add(NextDoor);
                            Foreground.Add(NextDoor);
                            break;
                        case 2:
                            DoorBlok PrevDoor = new DoorBlok(doorTexures, new Vector2(x * 64, y * 16 - 80), DoorType.Previous);
                            Doors.Add(PrevDoor);
                            Foreground.Add(PrevDoor);
                            break;
                        case 3:
                            DoorBlok EndDoor = new DoorBlok(doorTexures, new Vector2(x * 64, y * 16 - 80), DoorType.End);
                            Doors.Add(EndDoor);
                            Foreground.Add(EndDoor);
                            break;
                        case 10:
                            Foreground.Add(new StaticBlok(signTextures[0], new Vector2(x * 64, y * 16)));
                            break;
                        case 11:
                            Foreground.Add(new StaticBlok(signTextures[1], new Vector2(x * 64, y * 16)));
                            break;
                        case 12:
                            Foreground.Add(new StaticBlok(signTextures[2], new Vector2(x * 64, y * 16)));
                            break;
                        case 13:
                            Foreground.Add(new StaticBlok(signTextures[3], new Vector2(x * 64, y * 16)));
                            break;
                        case 14:
                            Foreground.Add(new StaticBlok(signTextures[4], new Vector2(x * 64, y * 16)));
                            break;
                        case 15:
                            Foreground.Add(new StaticBlok(signTextures[5], new Vector2(x * 64, y * 16)));
                            break;
                        default:
                            break;
                    }
                }
            }
                        
        }

        public void RemoveDead(IKillAble Player)
        {
            List<IKillAble> deadBlocks = new List<IKillAble>();
            if (Player.Levens <= 0) deadBlocks.Add(Player);
            foreach (var enemy in Enemies)
            {
                if (enemy.Levens <= 0) deadBlocks.Add(enemy);
            }
            foreach (var dead in deadBlocks)
            {
                if (dead.Hit) dead.Dead = true;
                else if (dead.Dead)
                {
                    Surroundings.Remove((DrawBlok)dead);
                    if (dead != Player) Enemies.Remove((CharacterBlok)dead);
                }
            }
        }
        public void RemoveSpecialBloks()
        {
            List<DynamicBlok> specialBloks = new List<DynamicBlok>();
            foreach (var bottle in ThrowAbles)
            {
                if (bottle.Hit) specialBloks.Add(bottle);
            }
            foreach (var dead in specialBloks)
            {
                if (dead.Hit) ThrowAbles.Remove(dead);
            }
        }

        public void DrawWorld(SpriteBatch spritebatch)
        {
            foreach (var backItem in Background)
            {
                backItem.Draw(spritebatch);
            }
            foreach (var foreItem in Foreground)
            {
                foreItem.Draw(spritebatch);
            }
            foreach (var surrItem in Surroundings)
            {
                if (surrItem != null)
                {
                    surrItem.Draw(spritebatch);
                }
            }
        }
    }
}
