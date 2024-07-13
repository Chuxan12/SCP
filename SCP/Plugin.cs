using Exiled.API.Features;
using UnityEngine;
using System;
using Exiled.Events.EventArgs.Player;

namespace SCP
{
    public class Plugin : Plugin<Config>
    {
        internal GenHandler GenHandler { get; private set; }

        public override string Name => "Custom HUD(info)";

        public override Version Version => new Version(1, 0, 0);

        public override Version RequiredExiledVersion => new Version(9, 0, 0);

        public override void OnEnabled()
        {
            GenHandler = new(Config);
            Exiled.Events.Handlers.Player.Verified += GenHandler.OnVerified;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.Verified -= GenHandler.OnVerified;
            GenHandler = null;
            base.OnDisabled();
        }
    }
}
