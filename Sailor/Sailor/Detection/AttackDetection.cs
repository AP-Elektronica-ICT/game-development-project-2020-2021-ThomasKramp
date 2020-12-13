using Microsoft.Xna.Framework;
using Sailor.Interfaces;
using Sailor.World.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Detection
{
    class AttackDetection
    {
        public static void LeftCollide(IGameObject attackObject, Vector2 richting, List<DynamicBlok> Targets)
        {
            // Top = 0      Bottom = ∞
            // Links = 0    Rechts = ∞

            foreach (var target in Targets)
            {
                // Ziet of blokken bestaan
                if (target != null)
                {
                    // if (Tile is PlatformBlok) continue;
                    // !(Tile ligt te hoog)
                    if (!(target.Positie.Y + target.Frame.Top < attackObject.Positie.Y + attackObject.Frame.Top
                        && target.Positie.Y + target.Frame.Bottom < attackObject.Positie.Y + attackObject.Frame.Top))
                    {
                        // !(Tile ligt te laag)
                        if (!(target.Positie.Y + target.Frame.Top > attackObject.Positie.Y + attackObject.Frame.Bottom
                            && target.Positie.Y + target.Frame.Bottom > attackObject.Positie.Y + attackObject.Frame.Bottom))
                        {
                            // !(Tile ligt te rechts)
                            if (!(target.Positie.X + target.Frame.Left < attackObject.Positie.X + attackObject.Frame.Right
                                && target.Positie.X + target.Frame.Right < attackObject.Positie.X + attackObject.Frame.Right))
                            {
                                // Tile is links
                                if (target.Positie.X + target.Frame.Left < attackObject.Positie.X + attackObject.Frame.Right + richting.X)
                                {
                                    target.Levens--;
                                    target.Hit = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void RightCollide(IGameObject attackObject, Vector2 richting, List<DynamicBlok> Targets)
        {
            // Top = 0      Bottom = ∞
            // Links = 0    Rechts = ∞

            foreach (var target in Targets)
            {
                // Ziet of blokken bestaan
                if (target != null)
                {
                    // if (Tile is PlatformBlok) continue;
                    // !(Tile ligt te hoog)
                    if (!(target.Positie.Y + target.Frame.Top < attackObject.Positie.Y + attackObject.Frame.Top
                        && target.Positie.Y + target.Frame.Bottom < attackObject.Positie.Y + attackObject.Frame.Top))
                    {
                        // !(Tile ligt te laag)
                        if (!(target.Positie.Y + target.Frame.Top > attackObject.Positie.Y + attackObject.Frame.Bottom
                            && target.Positie.Y + target.Frame.Bottom > attackObject.Positie.Y + attackObject.Frame.Bottom))
                        {
                            // !(Tile ligt te links)
                            if (!(target.Positie.X + target.Frame.Left > attackObject.Positie.X + attackObject.Frame.Left
                                && target.Positie.X + target.Frame.Right > attackObject.Positie.X + attackObject.Frame.Left))
                            {
                                // Tile is rechts
                                if (target.Positie.X + target.Frame.Right > attackObject.Positie.X + attackObject.Frame.Left + richting.X)
                                {
                                    target.Levens--;
                                    target.Hit = true;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
