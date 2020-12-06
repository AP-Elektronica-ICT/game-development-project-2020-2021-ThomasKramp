using Sailor.Interfaces;
using Sailor.Interfaces.Commands;
using Sailor.LoadSprites;
using Sailor.World.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailor.Detection
{
    class AttackDetection
    {
        public static void LeftCollide(IGameObject punchObject, List<DynamicBlok> Targets)
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
                    if (!(target.Positie.Y + target.Frame.Top < punchObject.Positie.Y + punchObject.Frame.Top
                        && target.Positie.Y + target.Frame.Bottom < punchObject.Positie.Y + punchObject.Frame.Top))
                    {
                        // !(Tile ligt te laag)
                        if (!(target.Positie.Y + target.Frame.Top > punchObject.Positie.Y + punchObject.Frame.Bottom
                            && target.Positie.Y + target.Frame.Bottom > punchObject.Positie.Y + punchObject.Frame.Bottom))
                        {
                            // !(Tile ligt te rechts)
                            if (!(target.Positie.X + target.Frame.Left < punchObject.Positie.X + punchObject.Frame.Right
                                && target.Positie.X + target.Frame.Right < punchObject.Positie.X + punchObject.Frame.Right))
                            {
                                // Tile is links
                                if (target.Positie.X + target.Frame.Left < punchObject.Positie.X + punchObject.Frame.Right)
                                {
                                    target.Levens--;
                                    target.state = CharacterState.Idle;
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void RightCollide(IGameObject punchObject, List<DynamicBlok> Targets)
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
                    if (!(target.Positie.Y + target.Frame.Top < punchObject.Positie.Y + punchObject.Frame.Top
                        && target.Positie.Y + target.Frame.Bottom < punchObject.Positie.Y + punchObject.Frame.Top))
                    {
                        // !(Tile ligt te laag)
                        if (!(target.Positie.Y + target.Frame.Top > punchObject.Positie.Y + punchObject.Frame.Bottom
                            && target.Positie.Y + target.Frame.Bottom > punchObject.Positie.Y + punchObject.Frame.Bottom))
                        {
                            // !(Tile ligt te links)
                            if (!(target.Positie.X + target.Frame.Left > punchObject.Positie.X + punchObject.Frame.Left
                                && target.Positie.X + target.Frame.Right > punchObject.Positie.X + punchObject.Frame.Left))
                            {
                                // Tile is rechts
                                if (target.Positie.X + target.Frame.Right > punchObject.Positie.X + punchObject.Frame.Left)
                                {
                                    target.Levens--;
                                    target.state = CharacterState.Idle;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
