﻿using System;
using System.Collections.Generic;
using System.Linq;
using CSharpWars.Common.Extensions;
using CSharpWars.DtoModel;
using CSharpWars.Enums;

namespace CSharpWars.Scripting.Model
{
    public class BotProperties
    {
        public Guid BotId { get; private set; }
        public Int32 Width { get; private set; }
        public Int32 Height { get; private set; }
        public Int32 X { get; private set; }
        public Int32 Y { get; private set; }
        public PossibleOrientations Orientation { get; private set; }
        public PossibleMoves LastMove { get; private set; }
        public Int32 MaximumHealth { get; private set; }
        public Int32 CurrentHealth { get; private set; }
        public Int32 MaximumStamina { get; private set; }
        public Int32 CurrentStamina { get; private set; }
        public Dictionary<String, String> Memory { get; private set; }
        public List<String> Messages { get; private set; }
        public List<Bot> Bots { get; set; }
        public PossibleMoves CurrentMove { get; set; }
        public Int32 MoveDestinationX { get; set; }
        public Int32 MoveDestinationY { get; set; }

        private BotProperties() { }

        public static BotProperties Build(BotDto bot, ArenaDto arena, IList<BotDto> bots)
        {
            return new BotProperties
            {
                BotId = bot.Id,
                Width = arena.Width,
                Height = arena.Height,
                X = bot.X,
                Y = bot.Y,
                Orientation = bot.Orientation,
                LastMove = bot.Move,
                MaximumHealth = bot.MaximumHealth,
                CurrentHealth = bot.CurrentHealth,
                MaximumStamina = bot.MaximumStamina,
                CurrentStamina = bot.CurrentStamina,
                Memory = bot.Memory.Deserialize<Dictionary<String, String>>(),
                Messages = new List<String>(),
                Bots = BuildBots(bots),
                CurrentMove = PossibleMoves.Idling
            };
        }

        private static List<Bot> BuildBots(IList<BotDto> bots)
        {
            return bots.Select(x => new Bot
            {
                Id = x.Id,
                Name = x.Name,
                X = x.X,
                Y = x.Y,
                Orientation = x.Orientation
            }).ToList();
        }
    }
}