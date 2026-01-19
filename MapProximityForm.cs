using HeroesOE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static HeroesOE.Globals;
using static HOETool.MapObjects;

namespace HOETool
{
	public partial class MapProximityForm : Form
	{
		public HeroesOEMain? main;	// HACK: use adjust controls on main
		public MapProximityForm()
		{
			InitializeComponent();
		}

		private void lbSquads_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateProximityObjectValue(squad_prox[lbSquads.SelectedIndex]);
		}

		private void UpdateProximityObjectValue(MapProximityObject obj)
		{
			current_no = obj.no;

			main.lblAdjust.Text = obj.Text;
			main.txtAdjustValue.Text = current_no.Value.ToString();

			main.udX.Value = obj.node.X;
			main.udZ.Value = obj.node.Z;
			main.lblNode.Text = obj.node.node.ToString();
		}

		private void cmdRefresh_Click(object sender, EventArgs e)
		{
			if (squad_prox.Count > 0)
			{
				// All spawns are flattened as ListBox is filled
				var new_squad = new List<MapProximityObject>();
				foreach (var prox in squad_prox)
				{
					new_squad.Add(prox);
					lbSquads.Items.Add(prox.Text);
					foreach (var spawn in prox.spawns)
					{
						lbSquads.Items.Add(spawn.Text);
						new_squad.Add(spawn);
					}

					prox.spawns = null;
				}

				squad_prox = new_squad;
			}
		}
	}
}
