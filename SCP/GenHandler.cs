using Exiled.Events.EventArgs.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SCP
{
    internal class GenHandler
    {
        private Config config;
        private TextMesh[] textLines = new TextMesh[5];
        /// <summary>
        /// Initializes a new instance of the <see cref="GenHandler"/> class.
        /// </summary>
        internal GenHandler(Config instance)
        {
            // We're going pass the config instance from the plugin's main class, or the entrypoint.
            config = instance;
        }
        /// <summary>
        /// Fired when a player has joined the server.
        /// </summary>
        internal void OnVerified(VerifiedEventArgs ev)
        {
            for (int i = 0; i < 5; i++)
            {
                textLines[i] = ev.Player.GameObject.AddComponent<TextMesh>();
                textLines[i].characterSize = 0.05f;
                textLines[i].fontSize = 100;
                textLines[i].color = Color.white;
                textLines[i].transform.position = new Vector3(0.1f, 0.1f + i * 0.1f, 0);
            }
            textLines[0].text = ev.Player.Nickname;
            textLines[1].text = ev.Player.Role.ToString();
            textLines[2].text = "" + ev.Player.ReferenceHub.serverRoles.RemoteAdmin;
            textLines[3].text = "14"; //Round.ElapsedTime.ToString("mm\\:ss");
            textLines[4].text = "";
        }
        //internal void Update(InteractingDoorEventArgs ev)
        //{
        //    if (player != null)
        //    {
        //        textLines[0].text = player.Nickname;
        //        textLines[1].text = player.Role.ToString();
        //        textLines[2].text = "" + player.ReferenceHub.serverRoles.RemoteAdmin;
        //        textLines[3].text = Round.ElapsedTime.ToString("mm\\:ss");
        //        textLines[4].text = "";
        //    }
        //}
    }
}
